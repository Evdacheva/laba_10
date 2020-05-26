using System;

namespace lsba10_2
{
	class Program
	{
		
		public static void Main(string[] args)
			{
				var rnd = new Random();
				int[] arr = new int[100];
				for (int i = 0; i < arr.Length; i++)
				{
					int rndMoney = rnd.Next(0, 7);
					MoneyGenerator(arr, i, rndMoney);
					Console.Write(arr[i] + " ");
				}
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("Отсортированный методом - подсчёта");

				CountingSort(arr, 0, arr.Length - 1);

				foreach (int sortedMoney in arr)
				{
					
					Console.Write(sortedMoney + " ");
				}

				Console.ReadKey();
			}

			public static void MoneyGenerator(int[] arr, int i, int rndMoney)
			{
				const int Dollars_1 = 0;
				const int Dollars_2 = 1;
				const int Dollars_5 = 2;
				const int Dollars_10 = 3;
				const int Dollars_20 = 4;
				const int Dollars_50 = 5;
				const int Dollars_100 = 6;

				switch (rndMoney)
				{
				case Dollars_1:
						arr[i] = 1;
						break;
					case Dollars_2:
						arr[i] = 2;
						break;
					case Dollars_5:
						arr[i] = 5;
						break;
					case Dollars_10:
						arr[i] = 10;
						break;
					case Dollars_20:
						arr[i] = 20;
						break;
					case Dollars_50:
						arr[i] = 50;
						break;
					case Dollars_100:
						arr[i] = 100;
						break;
					default:
						break;
				}
			}

			public static void CountingSort(int[] arr, int left, int right)
			{
				int min = 0, max = 0;

				for (int i = left; i <= right; i++)
				{
					if (arr[i] < min)
					{
						min = arr[i];
					}
					else if (arr[i] > max)
					{
						max = arr[i];
					}
				}

				int bn = max - min + 1;

				int[] buckets = new int[bn];

				for (int i = left; i <= right; i++)
				{
					buckets[arr[i] - min]++;
				}

				int index = 0;
				for (int i = min; i <= max; i++)
				{
					for (int j = 0; j < buckets[i - min]; j++)
					{
						arr[index++] = i;
					}
				}
			}
		}
	}

