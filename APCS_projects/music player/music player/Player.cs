using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using music_player.Properties;
using NAudio.Wave;

namespace music_player
{
    public partial class Music : Form
    {
        private string[] Song_list;

        private AudioFileReader reader;
        private readonly WaveOutEvent Wave_out = new WaveOutEvent();
        private int Current_index = -1;
        private System.Timers.Timer timer = new System.Timers.Timer();

        
        //initialization methods

        public Music()
        {
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Update_time_seeker);
            Wave_out.PlaybackStopped += new System.EventHandler<NAudio.Wave.StoppedEventArgs>(Song_ended);

            InitializeComponent();
            init_list();
        }

        private void Music_Load(object sender, EventArgs e) //fills the list when the form starts
        {
            
            Song_box.BeginUpdate();
            for(int i = 0; i < Song_list.Length; i++)
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

            song_img.Image = Properties.Resources.no_cover;
        }

        //button events

        private void Songs_DoubleClick(object sender, EventArgs e) //new song selected
        {            

            if(Song_box.SelectedIndex != Current_index)
            {
                
                Console.WriteLine(Song_box.Text);
                Current_index = Song_box.SelectedIndex;

                if (reader != null)
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

        private void Play_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                
                Wave_out.Play();
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if(reader != null)
            {
                Wave_out.Pause();
            }
        }

        private void Backward_Click(object sender, EventArgs e)
        {
            End_audio();
            
            Current_index = Math.Clamp(Current_index-1, 0, Song_list.Length);
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

        //audio playback methods

        private void Start_audio(int index) //inits the reader and wave device
        {
            reader = new AudioFileReader(Song_list[index]);
            Wave_out.Init(reader);
            Wave_out.Play();
            timer.Start();
            ttl_time.Text = reader.TotalTime.ToString(@"mm\:ss");
            crnt_time.Text = reader.CurrentTime.ToString(@"mm\:ss");
            seeker.Maximum = (int)reader.TotalTime.TotalSeconds;
            seeker.Value = 0;
        }

        private void End_audio()  //disposes file reader and wave device
        {
            Wave_out.Dispose();
            reader.Dispose();
            reader = null;
            timer.Stop();
        }

        private void Song_ended(object sender, EventArgs e) //autoplay
        {
            if (reader.Position == reader.Length)
            {
                BeginInvoke(new Action(() => 
                //I really don't know exactly what this does but it fixes a threading issue with the event interacting with the ui method
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
                song_img.Image = Image.FromStream(new MemoryStream(Img_data)); //needs to be properly disposed
            }
            else
            {
                song_img.Image = Properties.Resources.no_cover;
            }
        }
        
        private void Update_time_seeker(object sender, System.Timers.ElapsedEventArgs e) //updates current time and seeker position
        {
            
            BeginInvoke(new Action(() =>
            {
                if (reader != null)
                {
                    crnt_time.Text = reader.CurrentTime.ToString(@"mm\:ss");

                    if (!seeker.Capture) //if not being dragged
                    {
                        seeker.Value = (int)reader.CurrentTime.TotalSeconds;
                    }
                }
            }));
        }

        private void Move_seeker(object sender, EventArgs e) //skips to the position that matches the seeker
        {
            if(reader != null && seeker.Value != (int)reader.CurrentTime.TotalSeconds)
            {
                Console.WriteLine(seeker.Value);
                reader.Skip(seeker.Value - (int)reader.CurrentTime.TotalSeconds);
            }
        }

        private void Song_box_drag_drop(object sender, DragEventArgs e)//gets directories or files
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            foreach (string file in files)
            {
                if (File.GetAttributes(file).HasFlag(FileAttributes.Directory))//if is folder
                {
                    if (File.Exists("C:/temp/paths.txt"))
                    {
                        using(StreamWriter writer = new StreamWriter("C:/temp/paths.txt"))
                        {
                            Console.WriteLine(file);
                            writer.WriteLine(file);//needs to append, not rewrite
                        }
                    }
                }
            }
        }

        private void init_list()
        {
            if (File.Exists("C:/temp/paths.txt"))
            {
                string contents = File.ReadAllText("C:/temp/paths.txt");
                Console.WriteLine(contents);
            }
            else
            {
                File.WriteAllText("C:/temp/paths.txt", null);
            }

            Song_list = new string[0];
        }

        private void Song_box_drag_enter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }
    }
}
