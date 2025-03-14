﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
	public class Purple_5
	{
		public struct Response {
			//поля
			private string _animal;
			private string _character_trait;
			private string _concept;

			//свойства
			public string Animal => _animal;
			public string CharacterTrait => _character_trait;
			public string Concept => _concept;


			//конструктор
			public Response(string animal, string trait , string concept){
				_animal = animal;
				_character_trait = trait;
				_concept = concept;
			}

			//методы
			public int CountVotes(Response[] responses, int questionNumber)
			{
				if (responses == null || responses.Length == 0 || questionNumber < 1 || questionNumber > 3) return 0;


				if(questionNumber == 1)
				{
					return responses.Count(x => x.Animal != null && x.Animal.Length != 0);
				} else if (questionNumber == 2)
				{
					return responses.Count(x => x.CharacterTrait != null && x.CharacterTrait.Length != 0);
				} else if(questionNumber == 3)
				{
					return responses.Count(x => x.Concept != null && x.Concept.Length != 0);
				}
				else
				{
					return 0;
				}
			}

			public void Print()
			{
				Console.WriteLine(this.Animal + " " + this.CharacterTrait + " " + this.Concept);
			}
		}

		public struct Research
		{
			//поля
			private string _name;
			private Response[] _responses;

			//свойства
			public string Name => _name;
			public Response[] Responses => _responses;
			//{
			//	get
			//	{
			//		if(_responses == null)
			//		{
			//			return null;
			//		}
			//		if(_responses.Length == 0)
			//		{
			//			return null;
			//		}
			//		Response[] resps = new Response[_responses.Length];
			//		Array.Copy(_responses, resps, _responses.Length);
			//		return resps;
			//	}
			//}


			//конструкторы
			public Research(string name)
			{
				_name = name;
				_responses = new Response[0];
			}

			//методы
			public void Add(string[] answers)
			{
				if(_responses == null || answers == null || answers.Length != 3)
				{
					return;
				}
				var new_resp = new Response(answers[0], answers[1], answers[2]);
				Array.Resize(ref _responses, _responses.Length + 1);
				_responses[_responses.Length - 1] = new_resp;
			}


			public string[] GetTopResponses(int question)
			{
				if(_responses == null) { return null; }
				if(question == 1)
				{
					return _responses.GroupBy(x => x.Animal).Where(x => x.Key != null && x.Key.Length != 0).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
				
				} else if(question == 2)
				{
					return _responses.GroupBy(x => x.CharacterTrait).Where(x => x.Key != null && x.Key.Length != 0).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
				
				} else if(question == 3)
				{
					return _responses.GroupBy(x => x.Concept).Where(x => x.Key != null && x.Key.Length != 0).OrderByDescending(x => x.Count()).Take(5).Select(x => x.Key).ToArray();
					
				}
				else
				{
					return null;
				}
			}

			public void Print()
			{
				if(_responses == null)
				{
					Console.WriteLine(this.Name+ " Null");
					return;
				}
                
				Console.WriteLine(this.Name);
				int i = 1;
				foreach(var resp in this.Responses)
				{
                    Console.Write(i++ + " ");
					resp.Print();
				}
			}
		}
	}
}
