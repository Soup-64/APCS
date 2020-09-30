namespace music_player
{
    partial class Music
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Music));
            this.Song_box = new System.Windows.Forms.ListBox();
            this.seeker = new System.Windows.Forms.TrackBar();
            this.crnt_time = new System.Windows.Forms.Label();
            this.ttl_time = new System.Windows.Forms.Label();
            this.song_img = new System.Windows.Forms.PictureBox();
            this.play_Btn = new System.Windows.Forms.Button();
            this.pause_Btn = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.backward = new System.Windows.Forms.Button();
            this.crnt_Song = new System.Windows.Forms.TextBox();
            this.Add_playlist = new System.Windows.Forms.Button();
            this.Remove_playlist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seeker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.song_img)).BeginInit();
            this.SuspendLayout();
            // 
            // Song_box
            // 
            this.Song_box.AllowDrop = true;
            this.Song_box.FormattingEnabled = true;
            this.Song_box.ItemHeight = 15;
            this.Song_box.Location = new System.Drawing.Point(10, 34);
            this.Song_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Song_box.Name = "Song_box";
            this.Song_box.Size = new System.Drawing.Size(277, 454);
            this.Song_box.TabIndex = 0;
            this.Song_box.DragDrop += new System.Windows.Forms.DragEventHandler(this.Song_box_drag_drop);
            this.Song_box.DragEnter += new System.Windows.Forms.DragEventHandler(this.Song_box_drag_enter);
            this.Song_box.DoubleClick += new System.EventHandler(this.Songs_DoubleClick);
            // 
            // seeker
            // 
            this.seeker.Location = new System.Drawing.Point(295, 378);
            this.seeker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.seeker.Maximum = 100;
            this.seeker.MinimumSize = new System.Drawing.Size(500, 0);
            this.seeker.Name = "seeker";
            this.seeker.Size = new System.Drawing.Size(500, 45);
            this.seeker.TabIndex = 1;
            this.seeker.TickFrequency = 0;
            this.seeker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_seeker);
            // 
            // crnt_time
            // 
            this.crnt_time.AutoSize = true;
            this.crnt_time.Location = new System.Drawing.Point(295, 408);
            this.crnt_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.crnt_time.Name = "crnt_time";
            this.crnt_time.Size = new System.Drawing.Size(34, 15);
            this.crnt_time.TabIndex = 2;
            this.crnt_time.Text = "xx:xx";
            // 
            // ttl_time
            // 
            this.ttl_time.AutoSize = true;
            this.ttl_time.Location = new System.Drawing.Point(761, 408);
            this.ttl_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ttl_time.Name = "ttl_time";
            this.ttl_time.Size = new System.Drawing.Size(34, 15);
            this.ttl_time.TabIndex = 3;
            this.ttl_time.Text = "xx:xx";
            // 
            // song_img
            // 
            this.song_img.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.song_img.Location = new System.Drawing.Point(380, 12);
            this.song_img.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.song_img.Name = "song_img";
            this.song_img.Size = new System.Drawing.Size(350, 346);
            this.song_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.song_img.TabIndex = 4;
            this.song_img.TabStop = false;
            // 
            // play_Btn
            // 
            this.play_Btn.Location = new System.Drawing.Point(380, 443);
            this.play_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.play_Btn.Name = "play_Btn";
            this.play_Btn.Size = new System.Drawing.Size(75, 23);
            this.play_Btn.TabIndex = 5;
            this.play_Btn.Text = "Play";
            this.play_Btn.UseVisualStyleBackColor = true;
            this.play_Btn.Click += new System.EventHandler(this.Play_Click);
            // 
            // pause_Btn
            // 
            this.pause_Btn.Location = new System.Drawing.Point(638, 443);
            this.pause_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pause_Btn.Name = "pause_Btn";
            this.pause_Btn.Size = new System.Drawing.Size(75, 23);
            this.pause_Btn.TabIndex = 5;
            this.pause_Btn.Text = "Pause";
            this.pause_Btn.UseVisualStyleBackColor = true;
            this.pause_Btn.Click += new System.EventHandler(this.Pause_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(720, 443);
            this.forward.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 23);
            this.forward.TabIndex = 5;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // backward
            // 
            this.backward.Location = new System.Drawing.Point(299, 443);
            this.backward.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(75, 23);
            this.backward.TabIndex = 5;
            this.backward.Text = "Backward";
            this.backward.UseVisualStyleBackColor = true;
            this.backward.Click += new System.EventHandler(this.Backward_Click);
            // 
            // crnt_Song
            // 
            this.crnt_Song.Location = new System.Drawing.Point(463, 442);
            this.crnt_Song.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.crnt_Song.Name = "crnt_Song";
            this.crnt_Song.ReadOnly = true;
            this.crnt_Song.Size = new System.Drawing.Size(167, 23);
            this.crnt_Song.TabIndex = 6;
            // 
            // Add_playlist
            // 
            this.Add_playlist.Location = new System.Drawing.Point(10, 5);
            this.Add_playlist.Name = "Add_playlist";
            this.Add_playlist.Size = new System.Drawing.Size(75, 23);
            this.Add_playlist.TabIndex = 7;
            this.Add_playlist.Text = "Add";
            this.Add_playlist.UseVisualStyleBackColor = true;
            // 
            // Remove_playlist
            // 
            this.Remove_playlist.Location = new System.Drawing.Point(91, 5);
            this.Remove_playlist.Name = "Remove_playlist";
            this.Remove_playlist.Size = new System.Drawing.Size(75, 23);
            this.Remove_playlist.TabIndex = 8;
            this.Remove_playlist.Text = "Remove";
            this.Remove_playlist.UseVisualStyleBackColor = true;
            // 
            // Music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(851, 500);
            this.Controls.Add(this.Remove_playlist);
            this.Controls.Add(this.Add_playlist);
            this.Controls.Add(this.crnt_Song);
            this.Controls.Add(this.backward);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.pause_Btn);
            this.Controls.Add(this.play_Btn);
            this.Controls.Add(this.song_img);
            this.Controls.Add(this.ttl_time);
            this.Controls.Add(this.crnt_time);
            this.Controls.Add(this.seeker);
            this.Controls.Add(this.Song_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "Music";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Music_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seeker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.song_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Song_box;
        private System.Windows.Forms.TrackBar seeker;
        private System.Windows.Forms.Label crnt_time;
        private System.Windows.Forms.Label ttl_time;
        private System.Windows.Forms.PictureBox song_img;
        private System.Windows.Forms.Button play_Btn;
        private System.Windows.Forms.Button pause_Btn;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button backward;
        private System.Windows.Forms.TextBox crnt_Song;
        private System.Windows.Forms.Button Add_playlist;
        private System.Windows.Forms.Button Remove_playlist;
    }
}

