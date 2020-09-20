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
            this.Song_box = new System.Windows.Forms.ListBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.crnt_tme = new System.Windows.Forms.Label();
            this.ttl_Stmp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.play_Btn = new System.Windows.Forms.Button();
            this.pause_Btn = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.backward = new System.Windows.Forms.Button();
            this.crnt_Song = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Song_box
            // 
            this.Song_box.FormattingEnabled = true;
            this.Song_box.Location = new System.Drawing.Point(10, 10);
            this.Song_box.Name = "Song_box";
            this.Song_box.Size = new System.Drawing.Size(238, 394);
            this.Song_box.TabIndex = 0;
            this.Song_box.Tag = "cum";
            this.Song_box.DoubleClick += new System.EventHandler(this.Songs_DoubleClick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(253, 328);
            this.trackBar1.Maximum = 200;
            this.trackBar1.MinimumSize = new System.Drawing.Size(429, 0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(429, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 0;
            // 
            // crnt_tme
            // 
            this.crnt_tme.AutoSize = true;
            this.crnt_tme.Location = new System.Drawing.Point(253, 354);
            this.crnt_tme.Name = "crnt_tme";
            this.crnt_tme.Size = new System.Drawing.Size(30, 13);
            this.crnt_tme.TabIndex = 2;
            this.crnt_tme.Text = "xx:xx";
            // 
            // ttl_Stmp
            // 
            this.ttl_Stmp.AutoSize = true;
            this.ttl_Stmp.Location = new System.Drawing.Point(652, 354);
            this.ttl_Stmp.Name = "ttl_Stmp";
            this.ttl_Stmp.Size = new System.Drawing.Size(30, 13);
            this.ttl_Stmp.TabIndex = 3;
            this.ttl_Stmp.Text = "xx:xx";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(316, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 303);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // play_Btn
            // 
            this.play_Btn.Location = new System.Drawing.Point(326, 384);
            this.play_Btn.Name = "play_Btn";
            this.play_Btn.Size = new System.Drawing.Size(64, 20);
            this.play_Btn.TabIndex = 5;
            this.play_Btn.Text = "Play";
            this.play_Btn.UseVisualStyleBackColor = true;
            this.play_Btn.Click += new System.EventHandler(this.Play_Btn_Click);
            // 
            // pause_Btn
            // 
            this.pause_Btn.Location = new System.Drawing.Point(547, 384);
            this.pause_Btn.Name = "pause_Btn";
            this.pause_Btn.Size = new System.Drawing.Size(64, 20);
            this.pause_Btn.TabIndex = 5;
            this.pause_Btn.Text = "Pause";
            this.pause_Btn.UseVisualStyleBackColor = true;
            this.pause_Btn.Click += new System.EventHandler(this.Pause_Btn_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(617, 384);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(64, 20);
            this.forward.TabIndex = 5;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // backward
            // 
            this.backward.Location = new System.Drawing.Point(256, 384);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(64, 20);
            this.backward.TabIndex = 5;
            this.backward.Text = "Backwardw";
            this.backward.UseVisualStyleBackColor = true;
            this.backward.Click += new System.EventHandler(this.backward_Click);
            // 
            // crnt_Song
            // 
            this.crnt_Song.AutoSize = true;
            this.crnt_Song.Location = new System.Drawing.Point(447, 388);
            this.crnt_Song.Name = "crnt_Song";
            this.crnt_Song.Size = new System.Drawing.Size(16, 13);
            this.crnt_Song.TabIndex = 7;
            this.crnt_Song.Text = "...";
            // 
            // Music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(797, 433);
            this.Controls.Add(this.crnt_Song);
            this.Controls.Add(this.backward);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.pause_Btn);
            this.Controls.Add(this.play_Btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ttl_Stmp);
            this.Controls.Add(this.crnt_tme);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Song_box);
            this.MinimumSize = new System.Drawing.Size(431, 39);
            this.Name = "Music";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Music_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Song_box;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label crnt_tme;
        private System.Windows.Forms.Label ttl_Stmp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button play_Btn;
        private System.Windows.Forms.Button pause_Btn;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button backward;
        private System.Windows.Forms.Label crnt_Song;
    }
}

