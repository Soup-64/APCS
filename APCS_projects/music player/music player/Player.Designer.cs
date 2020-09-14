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
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Song_box
            // 
            this.Song_box.FormattingEnabled = true;
            this.Song_box.ItemHeight = 15;
            this.Song_box.Location = new System.Drawing.Point(12, 12);
            this.Song_box.Name = "Song_box";
            this.Song_box.Size = new System.Drawing.Size(277, 454);
            this.Song_box.Sorted = true;
            this.Song_box.TabIndex = 0;
            this.Song_box.Tag = "cum";
            this.Song_box.DoubleClick += new System.EventHandler(this.Songs_DoubleClick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(295, 379);
            this.trackBar1.Maximum = 200;
            this.trackBar1.MinimumSize = new System.Drawing.Size(500, 0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(500, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 0;
            // 
            // crnt_tme
            // 
            this.crnt_tme.AutoSize = true;
            this.crnt_tme.Location = new System.Drawing.Point(295, 409);
            this.crnt_tme.Name = "crnt_tme";
            this.crnt_tme.Size = new System.Drawing.Size(34, 15);
            this.crnt_tme.TabIndex = 2;
            this.crnt_tme.Text = "xx:xx";
            // 
            // ttl_Stmp
            // 
            this.ttl_Stmp.AutoSize = true;
            this.ttl_Stmp.Location = new System.Drawing.Point(761, 409);
            this.ttl_Stmp.Name = "ttl_Stmp";
            this.ttl_Stmp.Size = new System.Drawing.Size(34, 15);
            this.ttl_Stmp.TabIndex = 3;
            this.ttl_Stmp.Text = "xx:xx";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(369, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // play_Btn
            // 
            this.play_Btn.Location = new System.Drawing.Point(450, 443);
            this.play_Btn.Name = "play_Btn";
            this.play_Btn.Size = new System.Drawing.Size(75, 23);
            this.play_Btn.TabIndex = 5;
            this.play_Btn.Text = "Play";
            this.play_Btn.UseVisualStyleBackColor = true;
            // 
            // pause_Btn
            // 
            this.pause_Btn.Location = new System.Drawing.Point(531, 443);
            this.pause_Btn.Name = "pause_Btn";
            this.pause_Btn.Size = new System.Drawing.Size(75, 23);
            this.pause_Btn.TabIndex = 5;
            this.pause_Btn.Text = "Pause";
            this.pause_Btn.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(720, 443);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(930, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pause_Btn);
            this.Controls.Add(this.play_Btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ttl_Stmp);
            this.Controls.Add(this.crnt_tme);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Song_box);
            this.MinimumSize = new System.Drawing.Size(500, 39);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}

