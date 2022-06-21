using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chordinator_ver._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        class note
        {
            Form1 f;
            PictureBox picbox;
            VScrollBar vsbar;
            Bitmap[] scaleImgs;
            String[] scaleStrs = new string[]
            {"rest","line","C","C sharp","D", "D sharp", "E", "F", "F sharp", "G", "G sharp", "A", "A sharp","B" ,"higher C"};
            Point location;
            public void SetLocation(int x,int y)
            {
                location.X = x;
                location.Y = y;
                vsbar.Location = location;
                int yoff = f.picboxSample.Location.Y - f.vsbSample.Location.Y;
                picbox.Location = new Point(location.X, location.Y + yoff);
            }
            public note(Form1 form)
            {
                f = form;
                location = new Point(f.vsbSample.Location.X, f.vsbSample.Location.Y);
                vsbar = new VScrollBar();
                vsbar.Size = f.vsbSample.Size;
                vsbar.Location = f.vsbSample.Location;
                vsbar.LargeChange = 1;
                picbox = new PictureBox();
                picbox.Size = f.picboxSample.Size;
                picbox.Location = f.picboxSample.Location;
                picbox.SizeMode = f.picboxSample.SizeMode;
                f.Controls.Add(vsbar);
                f.Controls.Add(picbox);
                picbox.BringToFront();

                SetImageArray();
                picbox.Image = scaleImgs[0];
                vsbar.Maximum = scaleStrs.Length - 1;
                vsbar.Value = vsbar.Maximum;
                vsbar.Minimum = 0;

                vsbar.Scroll += Vsbar_Scroll;
            }

            private void Vsbar_Scroll(object sender, ScrollEventArgs e)
            {
                int val = ((VScrollBar)sender).Maximum - ((VScrollBar)sender).Value;
                picbox.Image = scaleImgs[val];
            }

            private void SetImageArray()
            {
                scaleImgs = new Bitmap[scaleStrs.Length];
                for (int a = 0; a < scaleStrs.Length; a++)
                {
                    scaleImgs[a] = new Bitmap($"{scaleStrs[a]}.png");
                }
            }

            public void remove()
            {
                try
                {
                    f.Controls.Remove(picbox);
                    f.Controls.Remove(vsbar);
                }
                catch { }
            }

        }

        List<note> melody = new List<note>();
        List<Label> bars = new List<Label>();
        int bps;
        int offsetX;
        Point startLocation;
        private void Form1_Load(object sender, EventArgs e)
        {
            startLocation = vsbSample.Location;
            offsetX = picboxSample2.Location.X - picboxSample.Location.X;
            bps = (int)numericUpDown1.Value;
            for(int a=0;a<bps;a++)
            {
                melody.Add(new note(this));
            }
            ArrangeMelody();
        }
        private void ArrangeMelody()
        {
            ClearBars();
            while(melody.Count%bps!=0)
            {
                melody.Add(new note(this));
            }
            int section = 0;
            for(int a=0;a<melody.Count;a++)
            {
                if(a!=0&&a%bps==0)
                {
                    setbar(a+section);
                    section++;
                }
                melody[a].SetLocation(startLocation.X + offsetX * (a + section),startLocation.Y);
            }
            setbar(melody.Count + section);
            bars.Last().Text = "||";
            button1.Location = new Point(startLocation.X + offsetX * (melody.Count + section + 1), startLocation.Y);
            button2.Location = new Point(startLocation.X + offsetX * (melody.Count + section + 1), startLocation.Y+button1.Height+1);
            if(melody.Count>bps)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        private void ClearBars()
        {
            foreach(Label l in bars)
            {
                Controls.Remove(l);
            }
            bars.Clear();
        }
        private void setbar(int num)
        {
            Label l = new Label();
            l.Text = "|";
            l.AutoSize = false;
            l.Font = labelSample.Font;
            l.Size = labelSample.Size;
            l.Location = new Point(startLocation.X + offsetX * num, startLocation.Y);
            l.TextAlign = labelSample.TextAlign;
            Controls.Add(l);
            bars.Add(l);
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bps = (int)numericUpDown1.Value;
            ArrangeMelody();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for(int a=0;a<bps;a++)
            {
                melody.Add(new note(this));
            }
            ArrangeMelody();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for(int a = 0; a < bps; a++)
            {
                melody.Last().remove();
                melody.RemoveAt(melody.Count - 1);
            }
            ArrangeMelody();
        }
    }
}
