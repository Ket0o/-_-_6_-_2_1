//Вьюгин К.В. - 187 cm - 70 kg
//Киреев В.В. - 200 cm - 30 kg
//Булкин П.В. - 300 cm - 300 kg
//Папкин П.П. - 100 cm - 10 kg
//Третяков К.В. - 187 cm - 70 kg
//Стерлингов В.В. - 191 cm - 30 kg
//Сидоров П.В. - 199 cm - 300 kg
//Петров П.П. - 100 cm - 10 kg
//Синичкин К.В. - 187 cm - 70 kg
//Медведев В.В. - 201 cm - 30 kg
//Погонин П.П. - 100 cm - 10 kg
//Штефан П.В. - 211 cm - 300 kg


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
        Form2 form2 = null;  // для обращения

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string text = textBox1.Text;  // Берем текст из textBox1 1 формы

            var text1 = new List<string>();  // Создаем список типа строки

            string pattern = @"\b(\w+\s\w+[.]\w+[.])\s[-]\s(\w+\d)\s[c][m]\b";  // Присваиваем строку (символ @ нужен чтобы символы в regex были видны неизменно )
            Regex regex = new Regex(pattern, RegexOptions.Multiline /*чтобы читалось построчно*/);  // Создаем переменную regex класса regex( строка, интсрукция на языке регулярный выражений)
            Match output = regex.Match(text);  // принимает строку text к которой надо приминить регулярные выражения и возвращает коллекцию найденых сообщений

            while(output.Success)  // пока есть к чему прминить, то
            {
                if (Convert.ToInt32(output.Groups[2].Value) > 190)  // Извлекаем нужную часть текста о обрабатываем в отдельности от всего текста(строки)
                {
                    text1.Add(output.Groups[1].Value);  // Фамилии в список 
                }
                output = output.NextMatch();  // Следующая строка, но про старое сравнение не забывает 
            }

            text = string.Empty;  // ПУстая строка

            for (int i = 0; i < text1.Count; i++)  // цикл создания строки
            {
                text = text + text1[i] + ' ' + ';' + ' ';
            }


            form2.label2.Text = text;  // Вывод на 2 форму(предварительно в дизайне открыли лейбл как паблик)


            form2.ShowDialog();  // показываем 2 форму
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();  // Для обращения ко 2 форме (даем имя для этого)
        }
    }
}
