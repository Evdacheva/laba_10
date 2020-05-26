using System;
using System.Collections.Generic;


namespace laba10_4
{
	class Program
	{
		public class Graph
		{
			//взяли из третьего задания;
			private int vertices = 0;

			Dictionary<int, List<int>> graph = null;

			public Graph(Dictionary<int, List<int>> dictionary, int num)
			{
				graph = dictionary;
				vertices = num;
			}

			public Stack<int> backChain(int[] p, int start, int end)
			{
				int pos = end;

				var path_stack = new Stack<int>();
				path_stack.Push(pos);

				while (pos != start)
				{
					pos = p[pos];
					path_stack.Push(pos);
				}

				return path_stack;
			}
			public Stack<int> BFS(int startPos, int endPos)
			{
				var q = new Queue<int>();

				// array for tracking path
				int[] vPath = new int[vertices];

				int[] checkedv = new int[vertices];

				q.Enqueue(startPos);
				checkedv[startPos] = 1;

				while (q.Count > 0)
				{
					int i = q.Dequeue();

					for (int j = 0; j < vertices; j++)
					{
						if (graph[i + 1].Contains(j + 1) && checkedv[j] == 0)
						{
							checkedv[j] = 1;
							q.Enqueue(j);
							vPath[j] = i;

							if (j == endPos)
							{
								return backChain(vPath, startPos, endPos);
							}
						}
					}


				}
				return null;
			}
		}
		static void Main(string[] args)
		{
			int[,] array = {
				{-1,40,80,-1,-1,-1,-1,-1}, //1
				{40,-1,-1,-1,-1,150,80,-1}, //2 
				{80,-1,-1,60,-1,40,-1,150}, //3 
				{-1,-1,60,-1,120,-1,-1,-1}, //4
				{-1,-1,-1,120,-1,50,-1,-1}, //5
				{-1,150,40,-1,50,-1,-1,-1}, //6
				{-1,80,-1,-1,-1,-1,-1,150}, //7
				{-1,-1,150,-1,-1,-1,150,-1}  //8
			};


			var graph = new Graph(array, 8);


			int i = 0;
			InitializeAndCheckVar(ref i);

			

			var dictionary_of_distance = new Dictionary<string, int>();


			for (int j = 0; j < 8; j++)
			{

				if (!dictionary_of_distance.ContainsKey(i + " " + j + 1))
				{
					if (i != j + 1)
					{
						var stackBFS = graph.BFS(i - 1, j);
						how_path_in_stack(stackBFS);
						Console.WriteLine();
						AddToDitionary(stackBFS, array, ref dictionary_of_distance, i);
					}

				}

			}

			foreach (KeyValuePair<string, int> keyValue in dictionary_of_distance)
			{
				if (keyValue.Value <= 200)
					Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
			}
			Console.ReadKey();
		}

		static void AddToDitionary(Stack<int> stack, int[,] a, ref Dictionary<string, int> dict, int start_pos)
		{
			int prev_num = -1;

			int sum = 0;
			foreach (int i in stack)
			{
				if (prev_num == -1)
					prev_num = i;
				else
				{
					sum += a[prev_num, i];
					prev_num = i;
					dict[(start_pos) + " " + (i + 1)] = sum;
				}
			}
		}

		static void InitializeAndCheckVar(ref int i)
		{
			bool Pass = false;
			while (!Pass)
			{
				try
				{
					i = Convert.ToInt32(Console.ReadLine());
					if (i > 0 && i <= 8)
						Pass = true;
					else
						Console.WriteLine("Значение неверное");
				}
				catch
				{
					Console.WriteLine("Значение неверное");
				}
			}
		}

		static void how_path_in_stack(Stack<int> stack)
		{
			int cnt = 0;
			foreach (int i in stack)
			{
				Console.WriteLine((cnt == 0) ? Convert.ToString(i + 1) : "->" + (i + 1));
				cnt++;
			}
		}


	}
}
		



