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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample2)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelSample);
            this.Controls.Add(this.picboxSample2);
            this.Controls.Add(this.picboxSample);
            this.Controls.Add(this.vsbarSample2);
            this.Controls.Add(this.vsbSample);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Chordinator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxSample2)).EndInit();
            this.ResumeLayout(false);

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
    }
}

