using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _index_of_jump;
            // свойствы
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) { return null; }
                    double[] cfs = new double[_coefs.Length];
                    Array.Copy(_coefs, cfs, _coefs.Length);
                    return cfs;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) { return null; }
                    int[,] mks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < mks.GetLength(0); ++i)
                    {
                        for (int j = 0; j < mks.GetLength(1); ++j)
                        {
                            mks[i, j] = _marks[i, j];
                        }
                    }
                    return mks;
                }
            }

            public double TotalScore
            {
                get
                {
                    double sm = 0, sall = 0;
                    int mi = 1000, ma = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            sm += _marks[i, j];
                            if (_marks[i, j] >= ma)
                            {
                                ma = _marks[i, j];
                            }
                            if (_marks[i, j] <= mi)
                            {
                                mi = _marks[i, j];
                            }
                        }
                        sm -= mi;
                        sm -= ma;
                        sm *= _coefs[i];
                        sall += sm;
                        sm = 0;
                        mi = 1000;
                        ma = 0;
                    }
                    return sall;
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                };
                _index_of_jump = 0;
            }

            //методы
            public void SetCriterias(double[] coefs)
            {
                _coefs = coefs;
            }

            public void Jump(int[] marks)
            {
                if (_index_of_jump > 3)
                {
                    return;
                }
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[_index_of_jump, i] = marks[i];
                }
                _index_of_jump += 1;
            }

            public static void Sort(Participant[] array)
            {

                for (int i = 1; i < array.Length; i++)
                {
                    Participant k = array[i];
                    int j = i - 1;
                    while (j >= 0 && array[j].TotalScore < k.TotalScore)
                    {
                        array[j + 1] = array[j];
                        array[j] = k;
                        j--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(this.Name + " " + this.Surname + " " + this.TotalScore);

            }
        }
    }
}
