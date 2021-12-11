using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Лабараторная_работа_6_задание_2
{
    public partial class Form1 : Form
    {
        Form2 form2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string text = textBox1.Text;

            var text1 = new List<string>();

            string pattern = @"\b(\w+\s\w+[.]\w+[.])\s[-]\s(\w+\d)\s[c][m]\b";
            Regex regex = new Regex(pattern, RegexOptions.Multiline);
            Match output = regex.Match(text);

            while(output.Success)
            {
                if (Convert.ToInt32(output.Groups[2].Value) > 190)
                {
                    text1.Add(output.Groups[1].Value);
                }
                output = output.NextMatch();
            }

            text = string.Empty;

            for (int i = 0; i < text1.Count; i++)
            {
                text = text + text1[i] + ' ' + ';' + ' ';
            }


            form2.label2.Text = text;


            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
        }
    }
}
