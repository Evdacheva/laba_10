using System;
using System.Collections;
using System.Collections.Generic;


namespace laba10_3
{
    class Program
    {
		public class Graph
		{
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

			public Stack<int> DFS(int start, int end)
			{ 
				var stack = new Stack<int>();

				int[] Path = new int[vertices];

				int[] checkedv = new int[vertices];


				stack.Push(start);
				checkedv[start] = 1;

				while (stack.Count > 0)
				{
					int i = stack.Pop();

					for (int j = vertices - 1; j >= 0; j--)
					{
						if (graph[i + 1].Contains(j + 1) && checkedv[j] == 0)
						{
							checkedv[j] = 1;
							stack.Push(j);
							Path[j] = i;

							if (j == end)
							{
								return backChain(Path, start, end);
							}
						}
					}
				}

				return null;
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
			static void Main(string[] args)
        {
			int[,] matrixAdj = {
				{0,1,1,0,0,0,0,0}, //1
				{1,0,0,0,0,1,1,0}, //2
				{1,0,0,1,0,1,0,1}, //3
				{0,0,1,0,1,0,0,0}, //4
				{0,0,0,1,0,1,0,0}, //5
				{0,1,1,0,1,0,0,0}, //6
				{0,1,0,0,0,0,0,1}, //7
				{0,0,1,0,0,0,1,0}  //8
			};

			var graph = new Graphs(matrixAdj, 8);

			int X = 0; int Y = 0;


			Console.Write("Введите вершину ");
			InitializeAndCheckVar(ref X);

			Console.Write("Введите вершину ");
			InitializeAndCheckVar(ref Y);

			
			var DFS = graph.DFS(X - 1, Y - 1);
				Show_path_in_stack(DFS);
			Console.WriteLine();

			
			var BFS = graph.BFS(X - 1, Y - 1);
				Show_path_in_stack(BFS);
			Console.WriteLine();

			
			
			var graph1 = new Dictionary<int, List<int>>();
			graph1[1] = new List<int> { 2, 3 };
			graph1[2] = new List<int> { 1, 6, 7 };
			graph1[3] = new List<int> { 1, 4, 6, 8 };
			graph1[4] = new List<int> { 3, 5 };
			graph1[5] = new List<int> { 4, 6 };
			graph1[6] = new List<int> { 2, 3, 5 };
			graph1[7] = new List<int> { 2, 8 };
			graph1[8] = new List<int> { 3, 7 };

			var graphLink = new Graphs (graph1, 8);
			var DFS_Link = graphLink.DFS(X - 1, Y - 1);
				Show_path_in_stack(DFS_Link);
			Console.WriteLine();

			
			var BFS_Link = graphLink.BFS(X - 1, Y - 1);
				Show_path_in_stack(BFS_Link);

			Console.ReadKey();
		}

		public static void InitializeAndCheckVar(ref int i)
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

		static void Show_path_in_stack(Stack<int> stack)
		{
			int cnt = 0;
			foreach (int i in stack)
			{
				Console.Write((cnt == 0) ? Convert.ToString(i + 1) : "->" + (i + 1));
				cnt++;
			}
		}
	}
    }
}
