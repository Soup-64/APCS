using System;
using System.IO;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using NAudio.FileFormats;
using TagLib.Mpeg;

namespace music_player
{
    public partial class Music : Form
    {

        private string[] Song_list = (string[])Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
            "*.mp3*",
            SearchOption.AllDirectories);

        private AudioFileReader reader;
        private readonly WaveOutEvent wave_out = new WaveOutEvent();
        private int Current_index = -1;



        public Music()
        {
            InitializeComponent();
            
        }

       

        private void Music_Load(object sender, EventArgs e) //when the form loads
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
                    Song_box.Items.Add(track.Name);
                }
            }
            Song_box.EndUpdate();
        }

        private void Songs_DoubleClick(object sender, EventArgs e) //new song selected
        {
            
            ListBox lst = (ListBox)sender;
            

            if(lst.SelectedIndex != Current_index)
            {
                
                Console.WriteLine(e.GetType() + "\n" + lst.SelectedIndex + "\n" + lst.Text);
                Current_index = lst.SelectedIndex;



                if (reader != null)
                {
                    End_audio();
                    Start_audio(Current_index);

                }
                else
                {
                    Start_audio(0);
                }

            }
        }

        private void Play_Btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("pressed!");
            if (reader != null)
            {
                
                wave_out.Play();
                Console.WriteLine(reader.Position);
            }
        }

        private void Pause_Btn_Click(object sender, EventArgs e)
        {
            if(reader != null)
            {
                wave_out.Pause();
            }
        }

        private void Start_audio(int index)
        {
            reader = new AudioFileReader(Song_list[index]);
            wave_out.Init(reader);
            Console.WriteLine(reader.Position);
            wave_out.Play();
        }

        private void End_audio()
        {
            wave_out.Stop();
            reader.Dispose();
            reader = null;
        }

        private void backward_Click(object sender, EventArgs e)
        {
                End_audio();
                Start_audio(Current_index - 1);
        }

        private void forward_Click(object sender, EventArgs e)
        {
            End_audio();
            Start_audio(Current_index - 1);
        }


        //slider update on un-click

        //more methods for the other buttons
    }
}
