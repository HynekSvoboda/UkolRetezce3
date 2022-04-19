using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UkolRetezce3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            label1.Text = "Počet slov: ";
            label2.Text = "Počet cifer: ";
            label3.Text = "Počet písmen: ";
            label4.Text = "Nejdelší slovo: ";
            label5.Text = "Upraveno: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string retezec=textBox1.Text;
            string trimed = retezec.Trim();
            int pocetslov=trimed.Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Length;
            string[] slova = trimed.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            char[] pismena = textBox1.Text.ToCharArray();
            string cisla = "0123456789";
            string nejvetsi = "";
            int pocetcifer = 0, pocetpismen = 0;
            foreach(string c in slova)
            {
                if(nejvetsi.Length<c.Length)
                {
                    nejvetsi = c;
                }
            }
            foreach (char c in trimed)
            {
                if (cisla.Contains(c))
                {
                    pocetcifer++;
                }
                if (c !=' ' &&((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                {
                    pocetpismen++;
                }
            }
            try
            {
                string posledni = trimed[trimed.Length - 1].ToString();
                string upraveni;

                if (trimed.Length % 2 == 0)
                {
                    upraveni = trimed.Insert(trimed.Length / 2, posledni);
                }
                else
                {
                    upraveni = trimed.Insert((trimed.Length - 1) / 2, posledni);
                }

                label1.Text = "Počet slov: " + pocetslov.ToString();
                label2.Text = "Počet cifer: " + pocetcifer.ToString();
                label3.Text = "Počet písmen: " + pocetpismen.ToString();
                label4.Text = "Nejdelší slovo: " + nejvetsi;
                label5.Text = "Upraveno: " + upraveni;
            }
            catch
            {
                MessageBox.Show("Něco se pokazilo","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("V TextBox je dán řetězec slov. Slova jsou oddělena jednou mezerou.\nSpočítejte:\n-počet slov\n- počet cifer\n- počet písmen\n- nejdelší slovo\n- vložení posledního znaku doprostřed(Má - li zadaný řetězec lichý počet znaků, pak poslední znak vložte před prostřední znak. (Např. “ABCDEF” -> “ABCFDEF”, “ABC” -> “ACBC”)).\nPo stisku tlačítka údaje zobrazte do komponent Label.","INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
