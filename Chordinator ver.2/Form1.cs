using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;

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

            int val = 0;

            public string GetScale()
            {
                return scaleStrs[val];
            }

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
                val = ((VScrollBar)sender).Maximum - ((VScrollBar)sender).Value;
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
        class chord
        {
            Form1 f;
            PictureBox picbox;
            Bitmap[] chordImgs;
            String[] chordStrs = new string[]
            {"C","D", "E", "F", "G", "A", "bB" ,"Cm","Csm","Dm", "Em", "Fsm", "Gm","Gsm", "Am", "Bm"};
            Point location;

            int val = 0;

            public string Getchord()
            {
                return chordStrs[val];
            }

            public void SetLocation(int x, int y)
            {
                location.X = x;
                location.Y = y;
                picbox.Location = location;
            }
            public chord(Form1 form)
            {
                f = form;
                location = new Point(f.selectedChordBoxSample.Location.X, f.selectedChordBoxSample.Location.Y);
                picbox = new PictureBox();
                picbox.Size = f.picboxSample.Size;
                picbox.Location = f.selectedChordBoxSample.Location;
                picbox.SizeMode = f.selectedChordBoxSample.SizeMode;
                f.Controls.Add(picbox);
                picbox.BringToFront();

                SetImageArray();
                picbox.Image = chordImgs[0];
            }
            private void SetImageArray()
            {
                chordImgs = new Bitmap[chordStrs.Length];
                for (int a = 0; a < chordStrs.Length; a++)
                {
                    chordImgs[a] = new Bitmap($"{chordStrs[a]}.png");
                }
            }
            public void remove()
            {
                try
                {
                    f.Controls.Remove(picbox);
                }
                catch { }
            }
        }
        public class SineWaveProvider32 : WaveProvider32
        {
            int sample;

            public SineWaveProvider32()
            {
                Frequency = 1000;
                Amplitude = 0.15f;          
            }

            public float Frequency { get; set; }
            public float Amplitude { get; set; }

            public override int Read(float[] buffer, int offset, int sampleCount)
            {
                int sampleRate = WaveFormat.SampleRate;
                for (int n = 0; n < sampleCount; n++)
                {
                    buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                    sample++;
                    if (sample >= sampleRate) sample = 0;
                }
                return sampleCount;
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

        private void PlayMelody()
        {
            String[] scaleStrs = new string[]
                {"C","C sharp","D", "D sharp", "E", "F", "F sharp", "G", "G sharp", "A", "A sharp","B" ,"higher C"};

            float[] frequencies = new float[] { 261.63f, 277.18f, 293.66f, 311.13f, 329.63f, 349.23f, 369.99f, 392.00f, 415.30f, 440.00f, 466.16f, 493.88f, 523.25f };
            int beat = (int)(((double)1 / (double)numericUpDown2.Value * 60) * 1000);
            SineWaveProvider32 swp = new SineWaveProvider32();
            swp.SetWaveFormat(16000, 1);
            swp.Frequency = frequencies[0];
            WaveOut wo = new WaveOut();
            wo.Init(swp);
            for (int a = 0; a < melody.Count; a++)
            {
                if (melody[a].GetScale()=="line")
                {
                    Thread.Sleep(beat);
                }
                else if(melody[a].GetScale() == "rest")
                {
                    wo.Stop();
                    Thread.Sleep(beat);
                }
                else
                {
                    wo.Stop();
                    swp.Frequency = (float)frequencies[Array.IndexOf(scaleStrs, melody[a].GetScale())];
                    wo.Play();
                    Thread.Sleep(beat);
                }
                
            }
            wo.Stop();
            wo.Dispose();
            wo = null;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Thread melodyT = new Thread(new ThreadStart(PlayMelody));
            button3.Enabled = false;
            melodyT.Start();
            button3.Enabled = true;
        }
    }
}
