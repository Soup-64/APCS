using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace music_player
{
    public partial class Music : Form
    {
       
        private string[] Song_list = (string[])Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
            "*.mp3*",
            SearchOption.AllDirectories);
        private int last_sel = -1;
        private bool is_playing = false;

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
            //remove this, it is test code
            ListBox lst = (ListBox)sender;
            

            if(lst.SelectedIndex != last_sel)
            {
                
                Console.WriteLine(e.GetType() + "\n" + lst.SelectedIndex + "\n" + lst.Text);
                last_sel = lst.SelectedIndex;

                if(is_playing)
                {
                    //kill prev. song and start a new one
                    //reset slider
                }
                else
                {
                    //start song
                }

            }
        }

        //slider update on un-click

        //more methods for the other buttons
    }
}
