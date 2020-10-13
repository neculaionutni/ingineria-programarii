using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Animatie;
using UITimer = System.Windows.Forms.Timer;

namespace Animatie
{
    public class Anim_EventArgs: EventArgs
    {
        int cadru_curent;
        Bitmap cadru_img;
        public Anim_EventArgs(int z, Bitmap b)
        {
            cadru_curent = z;
            cadru_img = b;
        }
        public int index_cadru
        {
            get{ return cadru_curent; }
        }
        public Bitmap img_cadru
        {
            get { return cadru_img; }
        }
    }
    public delegate void Animatie_EventHandler(object sender, Anim_EventArgs e);
    class Animatie
    {
        /*
         * vector de imagini
         * adaugare imagine
         * imagine cuuurenta
         * timer
         * constructor
         * event schimbare cadru curent
         * play
         * stop
         * functie actiune, trece la cadrul urmator
         */
        ArrayList vimag = new ArrayList();
        int imag_curenta;
        UITimer t;

        public void Add_imag(string s)
        {
            vimag.Add(new Bitmap(s));
        }

        public object this[int z]
        {
            get { return vimag[z]; }
        }
        public Animatie(int interval)
        {
            t = new UITimer();
            t.Interval = interval;
            t.Tick += new EventHandler(actiune);
        }
        public event Animatie_EventHandler Schimbare_cadru;
        public event Animatie_EventHandler Terminare_animatie;
        private void actiune(object sender, EventArgs e)
        {
            if (Schimbare_cadru != null)
                Schimbare_cadru(this, new Anim_EventArgs(imag_curenta, (Bitmap)vimag[imag_curenta]));
            imag_curenta++;
            if (imag_curenta == vimag.Count) imag_curenta = 0;
        }
        public void Play()
        {
            imag_curenta = 0;
            t.Start();
        }
        public void Stop()
        {
            t.Stop();
            Terminare_animatie(this, new Anim_EventArgs(imag_curenta, (Bitmap)vimag[imag_curenta]));
        }

    }
}