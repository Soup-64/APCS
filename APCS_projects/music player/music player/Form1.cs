using System;
using System.IO;
using System.Windows.Forms;

namespace music_player
{
    public partial class Music : Form
    {
        private String[] Song_list = (string[])Directory.EnumerateFiles(@"C:\Users\Owner\Desktop\Music_folder");
        private int last_sel = -1;

        public Music()
        {
            InitializeComponent();
        }

       

        private void Music_Load(object sender, EventArgs e)
        {

            Song_box.BeginUpdate();
            for(int i = 0; i < Song_list.Length; i++)
            {
                Song_box.Items.Add(Song_list[i]);
            }
            Song_box.EndUpdate();
        }

        private void Songs_DoubleClick(object sender, EventArgs e)
        {
            //remove this, it is test code
            ListBox lst = (ListBox)sender;
            

            if(lst.SelectedIndex != last_sel)
            {
                
                Console.WriteLine(e.GetType() + "\n" + lst.SelectedIndex + "\n" + lst.Text);
                last_sel = lst.SelectedIndex;
            }
        }
    }
}
