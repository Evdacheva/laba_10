using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace laba10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 0;
            string path = @"C:\Users\HP\source\repos\laba10_!\sorted.dat";
            int[] array = new int[100];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 30);
            }


            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            int[] array_ascending = array;
            int[] array_descending = new int[array.Length];
            for (int i = array.Length - 1; i > -1; i--)
            {
                array_descending[i] = array_ascending[i];
            }

            int cnt = 0;
            int swap = 0;
            TimeSpan time = new TimeSpan();
            QuickSortAlgoritm quickSort = new QuickSortAlgoritm();
            MergeSortAlgoritm mergeSort = new MergeSortAlgoritm();
            HeapSortAlgoritm heapSort = new HeapSortAlgoritm();

            Console.WriteLine("QuickSort");
            var arr = quickSort.QuickSort((int[])randomValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив сгенерированный случайным образом\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);

            Console.WriteLine("QuickSort");
            arr = quickSort.QuickSort((int[])descendingValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив по убыванию\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);

            Console.WriteLine("QuickSort");
            arr = quickSort.QuickSort((int[])ascendingValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив  по возростанию\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);
            Console.WriteLine("\n\n");



            Console.WriteLine("MergeSort");
            mergeSort.MergeSort((int[])randomValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив сгенерированный случайным образом\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);

            mergeSort.MergeSort((int[])descendingValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив сгенерированный по убыванию\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);

            mergeSort.MergeSort((int[])ascendingValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив по возростанию\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);
            Console.WriteLine("\n\n");


            Console.WriteLine("HeapSort");
            heapSort.HeapSort((int[])randomValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив сгенерированный случайным образом\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);

            heapSort.HeapSort((int[])descendingValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив по убыванию\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);

            heapSort.HeapSort((int[])ascendingValue.Clone(), ref cnt, ref swap, ref time);
            Console.Write($"Массив  по возростанию\nЗатраченное время на сортировку - {time} \nколичество сравнений - {cnt} \nколичество перестановок - {swap}\n");
            writeInFile(arr);
        }


        private static void check_File_Sorting()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                int cnt = lenght;
                while (true)
                {
                    if (reader.PeekChar() > -1)
                    {
                        if (reader.ReadInt32() <= reader.ReadInt32())
                        {
                            cnt -= 2;
                            continue;
                        }
                    }
                    else
                    {
                        if (cnt == 0)
                        {
                            Console.WriteLine("Массив отсортерован");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Массив не отсортерован");
                            break;
                        }
                    }
                }
            }
        }
        private static void writeInFile(int[] arr)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var item in arr)
                {
                    writer.Write(item);
                }
            }
            check_File_Sorting();
            Console.WriteLine("\n");
        }
       //=================================================================================================================================================
    
        public class QuickSortAlgoritm
  {
    public static void Swap(ref int elem1, ref int elem2)
    {
      var temp = elem1;
      elem1 = elem2;
      elem2 = temp;
    }

    private static int Partition(int[] array, int minIndex, int maxIndex, ref int cnt, ref int swap)
    {
      var pivot = minIndex - 1;
      for (var i = minIndex; i < maxIndex; i++)
      {
        cnt++;
        if (array[i] < array[maxIndex])
        {
          pivot++;
          swap++;
          Swap(ref array[pivot], ref array[i]);
        }
      }

      pivot++;
      swap++;
      Swap(ref array[pivot], ref array[maxIndex]);
      return pivot;
    }

    private static int[] QuickSort(int[] array, int minIndex, int maxIndex, ref int cnt, ref int swap, ref TimeSpan time)
    {
      DateTime dateTime = DateTime.Now;
      DateTime dateTime1 = DateTime.Now;

      if (minIndex >= maxIndex)
      {
        dateTime1 = DateTime.Now;
        time = dateTime1 - dateTime;
        return array;
      }

      var pivotIndex = Partition(array, minIndex, maxIndex, ref cnt, ref swap);
      QuickSort(array, minIndex, pivotIndex - 1, ref cnt, ref swap, ref time);
      QuickSort(array, pivotIndex + 1, maxIndex, ref cnt, ref swap, ref time);

      dateTime1 = DateTime.Now;
      time = dateTime1 - dateTime;
      return array;
    }

    public int[] QuickSort(int[] array, ref int cnt, ref int swap, ref TimeSpan time)
    {

      return QuickSort(array, 0, array.Length - 1, ref cnt, ref swap, ref time);

    }


  }

  public class MergeSortAlgoritm
  {
    private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex, ref int cnt, ref int swap)
    {
      var left = lowIndex;
      var right = middleIndex + 1;
      var tempArray = new int[highIndex - lowIndex + 1];
      var index = 0;
      cnt++;
      while ((left <= middleIndex) && (right <= highIndex))
      {
        cnt++;
        if (array[left] < array[right])
        {
          tempArray[index] = array[left];
          left++;
        }
        else
        {
          tempArray[index] = array[right];
          right++;
        }

        index++;
      }

      for (var i = left; i <= middleIndex; i++, swap++)
      {

        tempArray[index] = array[i];
        index++;
      }

      for (var i = right; i <= highIndex; i++, swap++)
      {
        tempArray[index] = array[i];
        index++;
      }

      for (var i = 0; i < tempArray.Length; i++, swap++)
      {
        array[lowIndex + i] = tempArray[i];
      }
    }

    private static int[] MergeSort(int[] array, int lowIndex, int highIndex, ref int cnt, ref int swap, ref TimeSpan time)
    {
      DateTime dateTime = DateTime.Now;
      if (lowIndex < highIndex)
      {
        var middleIndex = (lowIndex + highIndex) / 2;
        MergeSort(array, lowIndex, middleIndex, ref cnt, ref swap, ref time);
        MergeSort(array, middleIndex + 1, highIndex, ref cnt, ref swap, ref time);
        Merge(array, lowIndex, middleIndex, highIndex, ref cnt, ref swap);
      }
      DateTime dateTime1 = DateTime.Now;
      time = dateTime1 - dateTime;
      return array;
    }

    public int[] MergeSort(int[] array, ref int cnt, ref int swap, ref TimeSpan time)
    {
      return MergeSort(array, 0, array.Length - 1, ref cnt, ref swap, ref time);
    }
  }


  public class HeapSortAlgoritm
  {
    private static void Swap(ref int elem1, ref int elem2)
    {
      var temp = elem1;
      elem1 = elem2;
      elem2 = temp;
    }
    public void HeapSort(int[] arr, ref int cnt, ref int swap, ref TimeSpan time)
    {
      int n = arr.Length;

      for (int i = n / 2 - 1; i >= 0; i--)
      {
        Heapify(arr, n, i, ref cnt, ref swap, ref time);
      }

      for (int i = n - 1; i >= 0; i--)
      {
        swap++;
        Swap(ref arr[0], ref arr[i]);
        Heapify(arr, i, 0, ref  cnt, ref  swap, ref  time);
      }
    }


    private void Heapify(int[] arr, int n, int i, ref int cnt, ref int swap, ref TimeSpan time)
    {
      int largest = i;
      int left = 2 * i + 1; 
      int right = 2 * i + 2;
      cnt++;
      if (left < n && arr[left] > arr[largest])
      {
        largest = left;

      }
      cnt++;
      if (right < n && arr[right] > arr[largest])
      {
        largest = right;
      }
      cnt++;
      if (largest != i)
      {
        swap++;
        Swap(ref arr[i], ref arr[largest]);
        Heapify(arr, n, largest, ref cnt, ref swap, ref time);
      }
    }

  }
    
    
    
    
    }


}
    