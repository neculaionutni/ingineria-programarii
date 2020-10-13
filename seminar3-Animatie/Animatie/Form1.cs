using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animatie
{
    public partial class Form1 : Form
    {
        Animatie anim;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            anim = new Animatie(500);
            string cale = Path.Combine(
                Path.GetDirectoryName(this.GetType().Assembly.Location),
                "Pamant");
            for(int i=1; i<=15; i++)
            {
                string fisier = Path.Combine(cale, "c" + i + ".jpg");
                anim.Add_imag(fisier);
            }
            anim.Schimbare_cadru += new Animatie_EventHandler(Form_schimbare_cadru);
        }

        public void Form_schimbare_cadru(object sender, Anim_EventArgs e)
        {
            pictureBox2.Image = e.img_cadru;
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            anim.Play();
        }

    }
}
