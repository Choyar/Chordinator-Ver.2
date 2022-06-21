namespace Chordinator_ver._2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.vsbSample = new System.Windows.Forms.VScrollBar();
            this.picboxSample = new System.Windows.Forms.PictureBox();
            this.vsbarSample2 = new System.Windows.Forms.VScrollBar();
            this.picboxSample2 = new System.Windows.Forms.PictureBox();
            this.labelSample = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.selectedChordBoxSample = new System.Windows.Forms.PictureBox();
            this.candidateChordBoxSample1 = new System.Windows.Forms.PictureBox();
            this.candidateChordBoxSample2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedChordBoxSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidateChordBoxSample1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidateChordBoxSample2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("新細明體", 20F);
            this.numericUpDown1.Location = new System.Drawing.Point(64, 83);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(52, 39);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // vsbSample
            // 
            this.vsbSample.LargeChange = 1;
            this.vsbSample.Location = new System.Drawing.Point(122, 44);
            this.vsbSample.Maximum = 17;
            this.vsbSample.Name = "vsbSample";
            this.vsbSample.Size = new System.Drawing.Size(45, 73);
            this.vsbSample.TabIndex = 2;
            this.vsbSample.Visible = false;
            // 
            // picboxSample
            // 
            this.picboxSample.Location = new System.Drawing.Point(122, 59);
            this.picboxSample.Name = "picboxSample";
            this.picboxSample.Size = new System.Drawing.Size(45, 43);
            this.picboxSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxSample.TabIndex = 3;
            this.picboxSample.TabStop = false;
            this.picboxSample.Visible = false;
            // 
            // vsbarSample2
            // 
            this.vsbarSample2.LargeChange = 1;
            this.vsbarSample2.Location = new System.Drawing.Point(170, 44);
            this.vsbarSample2.Maximum = 17;
            this.vsbarSample2.Name = "vsbarSample2";
            this.vsbarSample2.Size = new System.Drawing.Size(45, 73);
            this.vsbarSample2.TabIndex = 2;
            this.vsbarSample2.Visible = false;
            // 
            // picboxSample2
            // 
            this.picboxSample2.Location = new System.Drawing.Point(170, 59);
            this.picboxSample2.Name = "picboxSample2";
            this.picboxSample2.Size = new System.Drawing.Size(45, 43);
            this.picboxSample2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxSample2.TabIndex = 3;
            this.picboxSample2.TabStop = false;
            this.picboxSample2.Visible = false;
            // 
            // labelSample
            // 
            this.labelSample.Font = new System.Drawing.Font("新細明體", 40F);
            this.labelSample.Location = new System.Drawing.Point(218, 44);
            this.labelSample.Name = "labelSample";
            this.labelSample.Size = new System.Drawing.Size(45, 73);
            this.labelSample.TabIndex = 4;
            this.labelSample.Text = "|";
            this.labelSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSample.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 20F);
            this.button1.Location = new System.Drawing.Point(269, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("新細明體", 20F);
            this.button2.Location = new System.Drawing.Point(269, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "-";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // selectedChordBoxSample
            // 
            this.selectedChordBoxSample.Location = new System.Drawing.Point(123, 153);
            this.selectedChordBoxSample.Name = "selectedChordBoxSample";
            this.selectedChordBoxSample.Size = new System.Drawing.Size(45, 43);
            this.selectedChordBoxSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedChordBoxSample.TabIndex = 3;
            this.selectedChordBoxSample.TabStop = false;
            this.selectedChordBoxSample.Visible = false;
            // 
            // candidateChordBoxSample1
            // 
            this.candidateChordBoxSample1.Location = new System.Drawing.Point(122, 234);
            this.candidateChordBoxSample1.Name = "candidateChordBoxSample1";
            this.candidateChordBoxSample1.Size = new System.Drawing.Size(45, 43);
            this.candidateChordBoxSample1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.candidateChordBoxSample1.TabIndex = 3;
            this.candidateChordBoxSample1.TabStop = false;
            this.candidateChordBoxSample1.Visible = false;
            // 
            // candidateChordBoxSample2
            // 
            this.candidateChordBoxSample2.Location = new System.Drawing.Point(122, 295);
            this.candidateChordBoxSample2.Name = "candidateChordBoxSample2";
            this.candidateChordBoxSample2.Size = new System.Drawing.Size(45, 43);
            this.candidateChordBoxSample2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.candidateChordBoxSample2.TabIndex = 3;
            this.candidateChordBoxSample2.TabStop = false;
            this.candidateChordBoxSample2.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("新細明體", 12F);
            this.button3.Location = new System.Drawing.Point(123, 436);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 42);
            this.button3.TabIndex = 6;
            this.button3.Text = "Play \r\nMelody";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("新細明體", 12F);
            this.button4.Location = new System.Drawing.Point(235, 436);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 42);
            this.button4.TabIndex = 6;
            this.button4.Text = "Play\r\nMelody + chord\r\n";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F);
            this.label1.Location = new System.Drawing.Point(12, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "BPM :";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("新細明體", 20F);
            this.numericUpDown2.Location = new System.Drawing.Point(17, 434);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 39);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 20F);
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Selected:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16F);
            this.label3.Location = new System.Drawing.Point(12, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Candidate:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 490);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelSample);
            this.Controls.Add(this.picboxSample2);
            this.Controls.Add(this.selectedChordBoxSample);
            this.Controls.Add(this.picboxSample);
            this.Controls.Add(this.vsbarSample2);
            this.Controls.Add(this.vsbSample);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.candidateChordBoxSample2);
            this.Controls.Add(this.candidateChordBoxSample1);
            this.Name = "Form1";
            this.Text = "Chordinator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedChordBoxSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidateChordBoxSample1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidateChordBoxSample2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.VScrollBar vsbSample;
        private System.Windows.Forms.PictureBox picboxSample;
        private System.Windows.Forms.VScrollBar vsbarSample2;
        private System.Windows.Forms.PictureBox picboxSample2;
        private System.Windows.Forms.Label labelSample;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox selectedChordBoxSample;
        private System.Windows.Forms.PictureBox candidateChordBoxSample1;
        private System.Windows.Forms.PictureBox candidateChordBoxSample2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}

