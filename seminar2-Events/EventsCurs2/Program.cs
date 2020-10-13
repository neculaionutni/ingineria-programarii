using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCurs2
{
    interface IObservator
    {
        void Notificare();
    }

    interface IObservabil
    {
        void Cupleaza(IObservator o);
        void Decupleaza(IObservator o);
    }
    class Observabil_Impl : IObservabil
    {
        List<IObservator> lobs = new List<IObservator>();
        public void Cupleaza(IObservator o)
        {
            lobs.Add(o);
        }
        public void Decupleaza(IObservator o)
        {
            lobs.Remove(o);
        }
    }
    class Element : Observabil_Impl
    {
        int el;
        public int Valoare_el
        {
            get { return el; }
            set
            {
                if (el != value)
                {
                    el = value;
                    foreach (IObservator o in lobs) o.Notificare();
                }
            }
        }

    }

    class Consola : IObservator
    {
        public void Notificare()
        {
            Console.WriteLine("Element Modificat");
        }
    }

    public partial class Form1 : Form, IObservator
    {
        Element rel = null;
        public Form1()
        {
            InitializeComponenent();
            rel = (Element)frel;
        }

        public void Notificare()
        {
            txt.Text += "Modificat!" + Environment.NewLine;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rel.Valoare_el = Convert.ToInt32(value.Text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Element el = new Element();
            Form1 frm = new Form1(el);
            Consola obc = new Consola();

            el.Cupleaza(obc);
            el.Cupleaza(frm);
            frm.ShowDialog();
            el.Valoare_el = 210;
        }
    }
}
