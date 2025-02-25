using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _filled;

            //свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public double[] Marks
            {
                get
                {
                    if (_marks == null) { return null; }
                    double[] marks = new double[7];
                    Array.Copy(_marks, marks, marks.Length);
                    return marks;
                }
            }

            public int[] Places
            {
                get
                {
                    if (_places == null) { return null; }
                    int[] places = new int[7];
                    Array.Copy(_places, places, places.Length);
                    return places;
                }
            }

            public int Score
            {
                get
                {
                    if (_places == null)
                    {
                    	return 0;
                    }
                    var score = _places.Sum();
                    return score;
                }

            }
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _filled = 0;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = 0;
                    _places[i] = 0;
                }
            }

            // методы
            public void Evaluate(double result)
            {
                if (_filled > 6 || _marks == null)
                {
                    return;
                }
                _marks[_filled] = result;
                _filled++;
            }

            public static void SetPlaces(Participant[] array)
            {
                if (array == null || array.Length == 0) { return; }
                if (array.Any(x => x._marks == null || x._places == null)) { return; }
                if (array.Any(x => x._filled < 6)) { return; }
                for (int i = 0; i < 7; i++)
                {
                    var sortedarr = array.Where(x => x.Marks != null && x.Places != null).OrderByDescending(x => x.Marks[i]).ToArray();
                    for (int j = 0; j < sortedarr.Length; j++)
                    {
                        sortedarr[j]._places[i] = j + 1;

                    }
                    if (i == 6)
                    {
                        sortedarr = sortedarr.Concat(array.Where(x => x.Marks == null)).ToArray();
                        Array.Copy(sortedarr, array, array.Length);
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length < 2) { return; }
                Participant[] sortedarr = array.OrderBy(x => x.Score).ThenBy(x => x.Places.Min()).ThenByDescending(x => x.Marks.Sum()).ToArray();

                Array.Copy(sortedarr, array, array.Length);
            }

            public void Print()
            {
                int topplace = this.Places.Min();
                if (topplace == 0)
                {
                    return;
                }
                Console.WriteLine(this.Name + " " + this.Surname + " " + this.Score + " " + topplace + " " + this.Marks.Sum());
            }
        }
    }
}
