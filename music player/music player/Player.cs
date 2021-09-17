using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace music_player
{
    public partial class Music : Form
        //this is an older program and I'm well aware that it is far from being good quality
    {
        private string[] Song_list;

        private AudioFileReader Reader; //reads file data
        private readonly WaveOutEvent Wave_out = new WaveOutEvent(); //plays audio

        private int Current_index = -1; //current song being played

        private readonly System.Timers.Timer Timer = new System.Timers.Timer(); //used to trigger the updates for the ui
        private string current_playlist; //playlist in use, needed for the drag and drop


        //initialization methods

        public Music() //constructor
        {


            InitializeComponent();

            if (!Directory.Exists("C:/temp/playlists"))
            {
                Directory.CreateDirectory("C:/temp/playlists");
            }

            Timer.Interval = 1000;
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(Update_time_seeker);
            Wave_out.PlaybackStopped += new System.EventHandler<NAudio.Wave.StoppedEventArgs>(Song_ended);

            Show_playlists();

            song_img.Image = Properties.Resources.no_cover;
        }

        private void Init_list(string path) //inits Song_list
        {
            if (File.Exists(path))
            {
                string[] contents = File.ReadAllText(path).Split("\n");
                List<string> directory_builder = new List<string>();

                for (int i = 0; i < contents.Length - 1; i++)//intentional since last entry is empty bc of the \n 
                {
                    foreach (string item in Directory.GetFiles(contents[i], "*.mp3*", SearchOption.AllDirectories))
                    {
                        directory_builder.Add(item);
                    }
                }
                Song_list = directory_builder.ToArray();
            }
        }
      
        private void Update_song_list() //refreshes the list of songs
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

        private void List_DoubleClick(object sender, EventArgs e) //play selected song
        {
            if (Song_list[Song_box.SelectedIndex].EndsWith(".txt"))
            {
                current_playlist = Directory.GetFiles("C:/temp/playlists")[Song_box.SelectedIndex];

                Init_list(current_playlist);

                Update_song_list();

                Add_playlist.Enabled = false;
                Rename_playlist.Enabled = false;
                Remove_playlist.Enabled = false;
                Back.Enabled = true;
            }
            else
            {

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

        private void Play_Song(object sender, EventArgs e)//play song if paused
        {
            if (Reader != null)
            {

                Wave_out.Play();
            }
        }

        private void Pause_Song(object sender, EventArgs e)//pause song
        {
            if (Reader != null)
            {
                Wave_out.Pause();
            }
        }

        private void Skip_forward(object sender, EventArgs e)//skip backward one song
        {
            if (Reader != null)
            {
                End_audio();

                Current_index = Math.Clamp(Current_index - 1, 0, Song_list.Length);
                Start_audio(Current_index);

                Update_playing();
            }
        }

        private void Skip_backward(object sender, EventArgs e)//skip forward one song
        {
            if (Reader != null)
            {
                End_audio();
                Current_index = Math.Clamp(Current_index + 1, 0, Song_list.Length);
                Start_audio(Current_index);

                Update_playing();
            }
        }

        private void Move_seeker(object sender, EventArgs e) //skips to the position that matches the seeker
        {
            if (Reader != null && seeker.Value != (int)Reader.CurrentTime.TotalSeconds) 
                //if seeker does not math position (can only desync if user moves it)
            {
                Reader.Skip(seeker.Value - (int)Reader.CurrentTime.TotalSeconds);
            }
        }

        private void Song_box_drag_drop(object sender, DragEventArgs e)//adds dropped folder directories to current playlist
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string contents;

            foreach (string folder_dir in files)
            {

                if (File.GetAttributes(folder_dir).HasFlag(FileAttributes.Directory))//if is folder
                {
                    contents = File.ReadAllText(current_playlist); 
                    //gets all dirs in current playlist

                    if (!contents.Contains(folder_dir.Replace('\\', '/'))) 
                        //if current playlist does not already contain the same directory
                    {

                        File.AppendAllText(current_playlist, folder_dir.Replace('\\', '/') + "\n"); //writes directory path to playlist
                                                                                              //method also accounts for the file not existing
                        Init_list(current_playlist);

                        Update_song_list();
                    }
                    //note: the replace() thing fixes the slashes in the directory so C# reads it correctly
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

        //for playlist menu

        private void Create_playlist(object sender, EventArgs e) //makes new playlist
        {
            if (!File.Exists("C:/temp/playlists/new playlist.txt")) //prevents overwritting a pre existing "new playlist"
            {
                File.Create("C:/temp/playlists/new playlist.txt").Dispose();
                Show_playlists();
            }
        }

        private void Delete_playlist(object sender, EventArgs e) //removes selected playlist
        {
            File.Delete(Song_list[Song_box.SelectedIndex]);

            Show_playlists();
        }

        private void Back_Click(object sender, EventArgs e) //goes back to playlist menu
        {
            if (Reader != null)
            {
                End_audio();
            }
            Show_playlists();

            current_playlist = null;

            Add_playlist.Enabled = true;
            Rename_playlist.Enabled = true;
            Remove_playlist.Enabled = true;
            Back.Enabled = false;

            GC.Collect();
        }

        private void Rename_Click(object sender, EventArgs e)//renames playlist
        {
            if (Song_box.SelectedIndex > -1)
            {
                try
                {
                    File.Move(Song_list[Song_box.SelectedIndex], "c:/temp/playlists/" + name_input.Text + ".txt");
                }
                catch (IOException)
                {
                    MessageBox.Show("Name taken!");
                }
                name_input.Clear();

                Show_playlists();
            }
        }

        //audio playback methods

        private void Start_audio(int index) //inits the reader and wave device
        {
            Reader = new AudioFileReader(Song_list[index]);
            Wave_out.Init(Reader);
            Wave_out.Play();
            Timer.Start();

            //inits timer and ui
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

            Reader = null;
        }

        private void Song_ended(object sender, EventArgs e) //autoplay
        {
            if (Reader != null && Reader.Position == Reader.Length) //sneaky way of determining if the song was ended by the user or not
            {
                BeginInvoke(new Action(() =>
                {
                    End_audio();
                    Current_index = Math.Clamp(Current_index + 1, 0, Song_list.Length);
                    Start_audio(Current_index);
                    Update_playing();
                }));

            }
        }

        //ui update methods

        private void Update_playing() //updates ui when song is changed
        {
            //control
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
            //model + control
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

        //for playlist menu

        private void Show_playlists() //displays a list of available playlists
        {
            Song_list = Directory.GetFiles("C:/temp/playlists");

            Song_box.BeginUpdate();

            Song_box.Items.Clear();
            foreach (string path in Song_list)
            {
                Song_box.Items.Add(Path.GetFileName(path.Substring(0, path.LastIndexOf(".txt"))));
            }

            Song_box.EndUpdate();
        }


    }
}
