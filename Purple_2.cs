﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
	public class Purple_2
	{
		public struct Participant
		{
			// поля
			private string _name;
			private string _surname;
			private int _dictance;
			private int[] _marks;

			// свойства
			public string Name { get { return _name; } }
			public string Surname { get { return _surname; } }
			public int Distance { get { return _dictance; } }
			public int[] Marks
			{
				get
				{
					if (_marks == null) { return null; }
					int[] marks = new int[5];
					Array.Copy(_marks, marks, marks.Length);
					return marks;
				}
			}

			public int Result
			{
				get
				{
					if(_marks == null) { return 0; }
					int total_points = _marks.Sum() - _marks.Max() - _marks.Min();
					int pts_for_dst = 60;
					if (_dictance > 120)
					{
						pts_for_dst += (_dictance - 120) * 2;
					}
					else if (_dictance < 120)
					{
						pts_for_dst -= (120 - _dictance) * 2;
					}
					if (pts_for_dst < 0)
					{
						pts_for_dst = 0;
					}
					total_points += pts_for_dst;
					return total_points;

				}
			}

			// конструкторы
			public Participant(string name, string surname)
			{
				_name = name;
				_surname = surname;
				_dictance = 0;
				_marks = new int[5];
				for (int i = 0; i < _marks.Length; i++)
				{
					_marks[i] = 0;
				}
			}

			// методы
			public void Jump(int distance, int[] marks)
			{
				if (this.Distance != 0) return;
				if (marks == null ) return;
				if (marks.Length != 5) return;
				_dictance = distance;

				_marks = marks;
			}

			public static void Sort(Participant[] array)
			{
				if(array == null) { return; }
				Participant[] sorted = array.OrderByDescending(x => x.Result).ToArray();
				Array.Copy(sorted, array, sorted.Length);
			}

			public void Print()
			{
				Console.WriteLine(this.Name + " " + this.Surname + " " + this.Result);
			}

		}
	}
}
