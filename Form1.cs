using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Steganography_Wav
{
    public partial class Form1 : Form
    {
        SoundPlayer player;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnHide.Enabled = false;
            btnStegano.Enabled = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            try
            {
                player = new SoundPlayer();
                player.SoundLocation = textBox1.Text;
                player.Load();
                player.Play();
                btnPlay.Enabled = false;
                btnStop.Enabled = true;

            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
            btnPlay.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnStegano_Click(object sender, EventArgs e)
        {

            byte[] bytes = File.ReadAllBytes(textBox1.Text);
        }
    }
}
