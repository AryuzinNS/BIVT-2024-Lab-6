using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Purple_4.Sportsman[] spm = new Purple_4.Sportsman[5];
            Purple_4.Group gp = new Purple_4.Group("Группа");
            string[] names = new string[] { "Polina", "Savelii", "Ekaterina", "Dmitri", "Dmitri" };
            string[] sn = new string[] { "Луговая", "Козлов", "Жаркова", "Иванов", "Полевой" };
            double[] time = new double[] { 422.64, 142.05, 185.23, 294.32, 79.26 };
            for(int i = 0; i < 5; ++i)
            {
                spm[i] = new Purple_4.Sportsman(names[i], sn[i]);
                spm[i].Run(time[i]);
            }
            gp.Add(spm);
            gp.Print();

            Purple_4.Group g2 = new Purple_4.Group(gp);
            g2.Print();
            g2.Sort();
            g2.Print();
        }
    }
}
