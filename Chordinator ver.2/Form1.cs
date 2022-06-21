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
            {"rest","line","C","Cs","D", "Ds", "E", "F", "Fs", "G", "Gs", "A", "As","B" ,"higher C"};
            public Point location;

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
                List<string> sc = new List<string>();
                foreach(note n in f.melody)
                {
                    sc.Add(n.GetScale());
                }
                f.chord_Generate(f.bps,f.melody.Count/f.bps,sc,f.chordLists);
                f.updateCandidateChord();
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
            public PictureBox picbox;
            Bitmap[] chordImgs;
            String[] chordStrs = new string[]
            {"rest","line","C","D", "E", "F", "G", "A", "B" ,
                            "Cm","Dm","Em","Fm","Gm","Am","Bm",
                            "Cs","Ds","Es","Fs","Gs","As",
                            "Csm","Dsm","Esm","Fsm","Gsm","Asm",
                            "Db", "Eb", "Fb", "Gb", "Ab", "Bb" ,
                            "Dbm", "Ebm", "Fbm", "Gbm", "Abm", "Bbm" ,
            };
            Point location;

            int val = 0;

            public void setChord(string input)
            {
                val = Array.IndexOf(chordStrs, input);
                picbox.Image = chordImgs[val];
            }
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
                picbox.Size = f.selectedChordBoxSample.Size;
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
        List<chord> selectedChords = new List<chord>();
        List<chord>[] candidateChords = new List<chord>[3];
        List<string>[] chordLists = new List<string>[3];
        int bps;
        int offsetX;
        Point startLocation;

        private void updateCandidateChord()
        {
            int offsetY = candidateChordBoxSample2.Location.Y - candidateChordBoxSample1.Location.Y;
            for(int a=0;a<3;a++)
            {
                //adjust length
                while (candidateChords[a].Count > melody.Count)
                {
                    candidateChords[a].Last().remove();
                    candidateChords[a].RemoveAt(candidateChords[a].Count - 1);
                }
                while (candidateChords[a].Count < melody.Count)
                {
                    candidateChords[a].Add(new chord(this));
                    candidateChords[a].Last().picbox.Click += candidatePicbox_Click;
                }

                //Fill in the chord
                for(int b=0;b<chordLists[a].Count;b++)
                {
                    candidateChords[a][b].setChord(chordLists[a][b]);
                    candidateChords[a][b].SetLocation(melody[b].location.X, candidateChordBoxSample1.Location.Y + offsetY * a);
                    candidateChords[a][b].picbox.Name = $"cc{a}{b}";
                }
            }
        }

        //apply the selected chord
        private void candidatePicbox_Click(object sender, EventArgs e)
        {
            int a = ((PictureBox)sender).Name[2] - '0';
            int b = Convert.ToInt32(((PictureBox)sender).Name.Substring(3));
            selectedChords[b].setChord(chordLists[a][b]);
        }

        //setup and ready to call chord_Generate
        private void chordPrep()
        {
            List<string> sc = new List<string>();

            foreach (note n in melody)
            {
                sc.Add(n.GetScale());
            }
            chord_Generate(bps, melody.Count / bps, sc, chordLists);
            updateCandidateChord();
        }

        private void chord_Generate(int pai,int count,List<string> input,List<string>[] chordLists)
        {
            for(int a=0;a<3;a++)
            {
                //adjust length
                while (chordLists[a].Count>input.Count)
                {
                    chordLists[a].RemoveAt(chordLists[a].Count - 1);
                }
                while (chordLists[a].Count < input.Count)
                {
                    if(a==0)
                        chordLists[a].Add("C");
                    else if(a==1)
                        chordLists[a].Add("Cm");
                    else if (a == 2)
                        chordLists[a].Add("D");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int a=0;a<3;a++)
            {
                chordLists[a] = new List<string>();
                candidateChords[a] = new List<chord>();
            }

            startLocation = vsbSample.Location;
            offsetX = picboxSample2.Location.X - picboxSample.Location.X;
            bps = (int)numericUpDown1.Value;
            for(int a=0;a<bps;a++)
            {
                melody.Add(new note(this));
                selectedChords.Add(new chord(this));
                selectedChords.Last().picbox.Name = $"s{selectedChords.Count - 1}";
                selectedChords.Last().picbox.Click += selectedPicbox_Click;
            }
            ArrangeMelody();
        }

        private void selectedPicbox_Click(object sender, EventArgs e)
        {
            int num =Convert.ToInt32(((PictureBox)sender).Name.Substring(1));
            selectedChords[num].setChord("rest");
        }

        private void ArrangeMelody()
        {
            ClearBars();
            while(melody.Count%bps!=0)
            {
                melody.Add(new note(this));
                selectedChords.Add(new chord(this));
                selectedChords.Last().picbox.Name = $"s{selectedChords.Count - 1}";
                selectedChords.Last().picbox.Click += selectedPicbox_Click;
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
                selectedChords[a].SetLocation(startLocation.X + offsetX * (a + section), selectedChordBoxSample.Location.Y);
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

            chordPrep();
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
                selectedChords.Add(new chord(this));
                selectedChords.Last().picbox.Name = $"s{selectedChords.Count - 1}";
                selectedChords.Last().picbox.Click += selectedPicbox_Click;
            }
            ArrangeMelody();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for(int a = 0; a < bps; a++)
            {
                melody.Last().remove();
                melody.RemoveAt(melody.Count - 1);
                selectedChords.Last().remove();
                selectedChords.RemoveAt(selectedChords.Count - 1);
            }
            ArrangeMelody();
        }

        private void PlayMelody()
        {
            String[] scaleStrs = new string[]
                {"C","Cs","D", "Ds", "E", "F", "Fs", "G", "Gs", "A", "As","B" ,"higher C"};

            float[] frequencies = new float[] { 261.63f, 277.18f, 293.66f, 311.13f, 329.63f, 349.23f, 369.99f, 392.00f, 415.30f, 440.00f, 466.16f, 493.88f, 523.25f };
            int beat = (int)(((double)1 / (double)numericUpDown2.Value * 60) * 1000);
            SineWaveProvider32 swp = new SineWaveProvider32();
            swp.SetWaveFormat(44100, 1);
            WaveOut wo = new WaveOut();
            wo.Init(swp);
            for (int a = 0; a < melody.Count; a++)
            {
                //play melody
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
                    swp.Frequency = frequencies[Array.IndexOf(scaleStrs, melody[a].GetScale())];
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
            melodyT.Start();
            timer1.Interval = (int)(((double)1 / (double)numericUpDown2.Value * 60) * 1000)*melody.Count;
            button3.Enabled = false;
            button4.Enabled = false;
            timer1.Enabled = true;
            
        }

        private void PlayMpChord()
        {
            int beat = (int)(((double)1 / (double)numericUpDown2.Value * 60) * 1000);
            float[] frequencies = new float[] { 261.63f, 277.18f, 293.66f, 311.13f, 329.63f, 349.23f, 369.99f, 392.00f, 415.30f, 440.00f, 466.16f, 493.88f, 523.25f };
            float[] chordFrequencies = new float[] { 261.63f, 277.18f, 293.66f, 311.13f, 329.63f, 349.23f, 369.99f, 392.00f, 415.30f, 440.00f, 466.16f, 493.88f, 523.25f, 554.37f, 587.33f , 622.25f , 659.26f , 698.46f , 739.99f };

            String[] scaleStrs = new string[]
                {"C","Cs","D", "Ds", "E", "F", "Fs", "G", "Gs", "A", "As","B" ,"higher C"};
            
            //setup melody player
            SineWaveProvider32 swpMelody = new SineWaveProvider32();
            swpMelody.SetWaveFormat(44100, 1);
            WaveOut woMelody = new WaveOut();
            woMelody.Init(swpMelody);

            //setup chord players
            SineWaveProvider32[] swpChord = new SineWaveProvider32[3];
            WaveOut[] woChord = new WaveOut[3];
            for (int a=0;a<3;a++)
            {
                swpChord[a] = new SineWaveProvider32();
                swpChord[a].SetWaveFormat(44100, 1);
                swpChord[a].Amplitude = 0.08f;
                woChord[a] = new WaveOut();
                woChord[a].Init(swpChord[a]);
            }


            for (int a = 0; a < melody.Count; a++)
            {
                //play chord
                if (selectedChords[a].Getchord() == "line")
                {
                    //keep playing last note
                }
                else if (selectedChords[a].Getchord() == "rest")
                {
                    for (int b = 0; b < 3; b++)
                    {
                        woChord[b].Stop();
                    }
                }
                else
                {
                    for (int b = 0; b < 3; b++)
                    {
                        woChord[b].Stop();
                    }
                    int val = Array.IndexOf(scaleStrs, selectedChords[a].Getchord().Substring(0, 1));
                    if(selectedChords[a].Getchord().Length>1&& selectedChords[a].Getchord()[1]=='b')
                    {
                        val -= 1;
                    }
                    else if(selectedChords[a].Getchord().Length > 1 && selectedChords[a].Getchord()[1] == 's')
                    {
                        val += 1;
                    }
                    bool major = true;
                    if (selectedChords[a].Getchord()[selectedChords[a].Getchord().Length - 1] == 'm')
                    {
                        major=false;
                    }
                    if(major)
                    {
                        swpChord[0].Frequency = chordFrequencies[val];
                        swpChord[1].Frequency = chordFrequencies[(val + 4) ];
                        swpChord[2].Frequency = chordFrequencies[(val + 4 + 3) ];
                    }
                    else
                    {
                        swpChord[0].Frequency = chordFrequencies[val];
                        swpChord[1].Frequency = chordFrequencies[(val + 3) ];
                        swpChord[2].Frequency = chordFrequencies[(val + 3 + 4) ];
                    }
                    for (int b = 0; b < 3; b++)
                    {
                        woChord[b].Play();
                    }
                }

                //play melody
                if (melody[a].GetScale() == "line")
                {
                    //keep playing last note
                }
                else if (melody[a].GetScale() == "rest")
                {
                    woMelody.Stop();
                }
                else
                {
                    woMelody.Stop();
                    swpMelody.Frequency = (float)frequencies[Array.IndexOf(scaleStrs, melody[a].GetScale())];
                    woMelody.Play();
                }

                Thread.Sleep(beat);
            }
            for (int b = 0; b < 3; b++)
            {
                woChord[b].Stop();
                woChord[b].Dispose();
                woChord[b] = null;
            }
            woMelody.Stop();
            woMelody.Dispose();
            woMelody = null;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Thread chordT = new Thread(new ThreadStart(PlayMpChord));
            chordT.Start();
            timer1.Interval = (int)(((double)1 / (double)numericUpDown2.Value * 60) * 1000) * melody.Count;
            button3.Enabled = false;
            button4.Enabled = false;
            timer1.Enabled = true;
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            timer1.Enabled = false;
        }
    }
}
