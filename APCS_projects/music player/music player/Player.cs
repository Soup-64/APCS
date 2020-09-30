using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace music_player
{
    public partial class Music : Form
    {
        private string[] Song_list;

        private AudioFileReader Reader;
        private WaveOutEvent Wave_out = new WaveOutEvent();
        private int Current_index = -1;
        private System.Timers.Timer Timer = new System.Timers.Timer();
        private bool playlist_mode;
        private string current_playlist;


        //initialization methods

        public Music()
        {
            Timer.Interval = 1000;
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(Update_time_seeker);
            Wave_out.PlaybackStopped += new System.EventHandler<NAudio.Wave.StoppedEventArgs>(Song_ended);

            InitializeComponent();
        }

        private void Music_Load(object sender, EventArgs e) //fills the list when the form starts
        {
            if (!Directory.Exists("C:/temp/playlists"))
            {
                Directory.CreateDirectory("C:/temp/playlists");
            }

            Show_playlists();

            song_img.Image = Properties.Resources.no_cover;

        }

        private void Init_list(string path)
        {
            if (File.Exists(path))
            {
                string[] contents = File.ReadAllText(path).Split("\n");
                List<string> directory_builder = new List<string>();

                for (int i = 0; i < contents.Length - 1; i++)//intentional since last entry is empty bc of the \n 
                {
                    Console.Write(contents[i]);
                    Console.Write("a");
                    foreach (string item in Directory.GetFiles(contents[i], "*.mp3*", SearchOption.AllDirectories))
                    {
                        directory_builder.Add(item);
                        Console.WriteLine(item);
                    }
                }
                Song_list = directory_builder.ToArray();
            }
        }

        private void Update_list_box()
        {
            if (Song_list != null)
            {

                Song_box.BeginUpdate();
                Song_box.Items.Clear();

                for (int i = 0; i < Song_list.Length; i++)
                {
                    TagLib.File track = TagLib.File.Create(Song_list[i]);
                    if (track.Tag.Title != null)
                    {
                        Song_box.Items.Add(track.Tag.Title);
                    }
                    else
                    {

                        track.Tag.Title = Path.GetFileName(Song_list[i]).Substring(0, Path.GetFileName(Song_list[i]).IndexOf('.'));
                        Song_box.Items.Add(track.Tag.Title);
                        track.Save(); //updates song metadata to include title
                    }
                }
                Song_box.EndUpdate();
            }
        }

        //button/interface events

        private void Songs_DoubleClick(object sender, EventArgs e) //new song selected
        {
            if (playlist_mode)
            {
                current_playlist = Directory.GetFiles("C:/temp/playlists")[Song_box.SelectedIndex];

                Init_list(current_playlist);

                Update_list_box();

                playlist_mode = false;
            }
            else
            {
                if (Song_box.SelectedIndex != Current_index)
                {

                    Console.WriteLine(Song_box.Text);
                    Current_index = Song_box.SelectedIndex;

                    if (Reader != null)
                    {
                        End_audio();
                        Start_audio(Current_index);
                    }
                    else
                    {
                        Start_audio(Current_index);
                    }

                    Update_playing();
                }
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (Reader != null)
            {

                Wave_out.Play();
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (Reader != null)
            {
                Wave_out.Pause();
            }
        }

        private void Backward_Click(object sender, EventArgs e)
        {
            End_audio();

            Current_index = Math.Clamp(Current_index - 1, 0, Song_list.Length);
            Start_audio(Current_index);

            Update_playing();
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            End_audio();
            Current_index = Math.Clamp(Current_index + 1, 0, Song_list.Length);
            Start_audio(Current_index);

            Update_playing();
        }

        private void Move_seeker(object sender, EventArgs e) //skips to the position that matches the seeker
        {
            if (Reader != null && seeker.Value != (int)Reader.CurrentTime.TotalSeconds)
            {
                Console.WriteLine(seeker.Value);
                Reader.Skip(seeker.Value - (int)Reader.CurrentTime.TotalSeconds);
            }
        }

        private void Song_box_drag_drop(object sender, DragEventArgs e)//gets directories or files
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string contents;

            foreach (string file in files)
            {
                if (File.GetAttributes(file).HasFlag(FileAttributes.Directory))//if is folder
                {
                    contents = File.ReadAllText(current_playlist);

                    if (!contents.Contains(file.Replace('\\', '/')))
                    {

                        File.AppendAllText(current_playlist, file.Replace('\\', '/') + "\n"); //duplicate check
                                                                                                 //method also accounts for the file not existing

                        Init_list(current_playlist);

                        Update_list_box();
                    }

                }
            }
        }

        private void Song_box_drag_enter(object sender, DragEventArgs e) //shows the drag and drop visual
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }
       
        //audio playback methods

        private void Start_audio(int index) //inits the reader and wave device
        {
            Wave_out = new WaveOutEvent();
            Reader = new AudioFileReader(Song_list[index]);
            Wave_out.Init(Reader);
            Wave_out.Play();
            Timer.Start();
            ttl_time.Text = Reader.TotalTime.ToString(@"mm\:ss");
            crnt_time.Text = Reader.CurrentTime.ToString(@"mm\:ss");
            seeker.Maximum = (int)Reader.TotalTime.TotalSeconds;
            seeker.Value = 0;
        }

        private void End_audio()  //disposes file reader and wave device
        {
            Wave_out.Stop();
            Wave_out.Dispose();
            Reader.Dispose();

            Timer.Stop();

            //seems to fix the issue with NAudio becoming bloated
            Wave_out = null;
            Reader = null;
        }

        private void Song_ended(object sender, EventArgs e) //autoplay
        {
            if (Reader != null && Reader.Position == Reader.Length)
            {
                BeginInvoke(new Action(() =>
                {
                    Console.WriteLine("ok");
                    End_audio();
                    Current_index = Math.Clamp(Current_index + 1, 0, Song_list.Length);
                    Start_audio(Current_index);
                    Update_playing();
                }));

            }
        }

        //ui update methods

        private void Update_playing()
        {
            TagLib.File Track = TagLib.File.Create(Song_list[Current_index]);
            crnt_Song.Text = Track.Tag.Title;

            if (Track.Tag.Pictures.Length > 0)
            {
                byte[] Img_data = Track.Tag.Pictures[0].Data.Data;

                song_img.Image.Dispose();
                song_img.Image = Image.FromStream(new MemoryStream(Img_data));
            }
            else
            {
                song_img.Image.Dispose();
                song_img.Image = Properties.Resources.no_cover;
            }
        }

        private void Update_time_seeker(object sender, System.Timers.ElapsedEventArgs e) //updates current time and seeker position
        {

            BeginInvoke(new Action(() =>
            {
                if (Reader != null)
                {
                    crnt_time.Text = Reader.CurrentTime.ToString(@"mm\:ss");

                    if (!seeker.Capture) //if not being dragged
                    {
                        seeker.Value = (int)Reader.CurrentTime.TotalSeconds;
                    }
                }
            }));
        }
    
        private void Show_playlists()
        {
            string[] playlists = Directory.GetFiles("C:/temp/playlists");

            playlist_mode = true;

            Song_box.BeginUpdate();

            Song_box.Items.Clear();
            foreach(string path in playlists)
            {
                Song_box.Items.Add(Path.GetFileName(path));
            }

            Song_box.EndUpdate();
        }
    }
}