using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

//написанно примерно за 3 часа
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"C:\Users\skorb\Desktop\StreamWriter.html";
            StreamReader streamReader = new StreamReader(str);
            string textFile = streamReader.ReadToEnd().ToString();


            char br = 'z';
            textFile = textFile.Replace('\n', br); // заменяем коретку на символ z(можно использовать вместо z более специфичный и редкий символ или строку)
            textFile = textFile.Replace("&nbsp", br.ToString()); // так же заменяем все не нужные им знаки

            textFile = textFile.Replace("<", "<z"); //убираем теги, помечая их символом
            textFile = textFile.Replace(">", "z>");

            string[] StringArray = textFile.Split(new char[] { '<', '>' }); // разделяем на строки по символу
            for (int i = 0; i < StringArray.Length; i++) // удаляем не нужные строки с тегами
            {

                if (StringArray[i].StartsWith("z") == true || StringArray[i].EndsWith("z") == true)
                {
                    StringArray[i] = "";
                }
            }
            for (int i = 0; i < StringArray.Length; i++)// выводим всё кроме пустых строк, можно тут в будущем записывать сразу в новый файл. Как итог мы спарсили html-страничку  
            {
                if (StringArray[i] != "")
                {
                    Console.WriteLine(StringArray[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
