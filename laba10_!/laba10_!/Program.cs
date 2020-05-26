using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace laba10__
{
    class Program
    {
        struct Time
        {
            public DateTime dateTime;
            public TimeSpan timeSpan;

            public Time(DateTime d, TimeSpan t)
            {
                dateTime = d;
                timeSpan = t;
            }
        }
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

            using (StreamWriter text = new StreamWriter(path, false))
            {
                Console.WriteLine("Сортировка - слиянием (по возрастанию)");
                foreach (int selection in Merge(array))
                {
                    text.Write(selection + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - слиянием (отсортированного массива по возрастанию)");
                foreach (int selection in Merge(array_ascending))
                {
                    text.Write(selection + " ");
                }
                Console.WriteLine();
                text.WriteLine();

                Console.WriteLine("Сортировка - слиянием (отсортированного массива по убыванию)");
                foreach (int selection in Merge(array_descending))
                {
                    text.Write(selection + " ");
                }
                Console.WriteLine();
                text.WriteLine();



                System.Console.WriteLine("Пирамидальная сортировка: ");
                foreach (double x in array)
                {
                    System.Console.Write(x + " ");

                }
                PyramidSorting.sorting(array, array.Length);
                System.Console.WriteLine("\n\nПирамидальная сортировка по возрастанию:");
                foreach (double x in array)
                {
                    System.Console.Write(x + " ");

                }
                


                Console.WriteLine("Быстрая сортировка");
                Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort(array)));
            }

            Check(path);
            Console.ReadKey();
        }

        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            DateTime start = DateTime.Now;
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);
            DateTime finish = DateTime.Now;
            TimeSpan time_interval = finish - start;
            Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, maxIndex, pivotIndex);
            return array;
        }

        static int[] QuickSort(int[] array)
        {
           
            return QuickSort(array, 0, array.Length - 1);
        }




        static void Check(string path)
        {

            using (StreamReader textReader = new StreamReader(path))
            {
                bool data_checking = true;
                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    line = textReader.ReadLine();
                    if (line != null)
                    {
                        string[] nums = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < nums.Length - 1; i++)
                        {
                            if (Convert.ToInt32(nums[i]) < Convert.ToInt32(nums[i++]))
                            {
                                data_checking = false;
                                break;
                            }
                        }
                    }

                }
                if (data_checking)
                {
                    Console.WriteLine("Сортировка всех функций прошла успешно");
                }
                else
                {
                    Console.WriteLine("Сортировка прошла неудачно");
                }

            }


        }


        static int[] Merge(int[] nums)
                {
                    DateTime start = DateTime.Now;
                    int l = 1;
                    int r = 1;
                    int mid = 1;
                    int[] temp = new int[r - l + 1];

                    int i = l, j = mid + 1;
                    int k = 0;

                    for (k = 0; k < temp.Length; k++)
                    {
                        if (i > mid)
                        {
                            temp[k] = nums[j++];
                        }
                        else if (j > r)
                        {
                            temp[k] = nums[i++];
                        }
                        else
                        {
                            temp[k] = (nums[i] < nums[j]) ? nums[i++] : nums[j++];
                        }
                    }

                    // Copy temp array to original array
                    k = 0;
                    i = l;
                    while (k < temp.Length && i <= r)
                    {
                        nums[i++] = temp[k++];
                    }
                    DateTime finish = DateTime.Now;
                    TimeSpan time_interval = finish - start;
                    Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, k, i);

                    return nums;
                }
            }
        }
        class PyramidSorting
        {
            //add 1 element to the pyramid
            static int add2pyramid(int [] arr, int i, int N)
            {
                DateTime start = DateTime.Now;
                int imax;
                int buf;
                if ((2 * i + 2) < N)
                {
                    if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                    else imax = 2 * i + 1;
                }
                else imax = 2 * i + 1;
                if (imax >= N) return i;
                if (arr[i] < arr[imax])
                {
                    buf = arr[i];
                    arr[i] = arr[imax];
                    arr[imax] = buf;
                    if (imax < N / 2) i = imax;
                }
                DateTime finish = DateTime.Now;
                TimeSpan time_interval = finish - start;
                Console.WriteLine("Время сортировки:{0};\n Количество сравнений:{1};\n Количество обменов:{2}", time_interval, i, imax);
                return i;
            }
            public static void sorting(int [] arr, int len)
            {
                //step 1: building the pyramid
                for (int i = len / 2 - 1; i >= 0; --i)
                {
                    long prev_i = i;
                    i = add2pyramid(arr, i, len);
                    if (prev_i != i) ++i;
                }

                //step 2: sorting
                int buf;
                for (int k = len - 1; k > 0; --k)
                {
                    buf = arr[0];
                    arr[0] = arr[k];
                    arr[k] = buf;
                    int i = 0, prev_i = -1;
                    while (i != prev_i)
                    {
                        prev_i = i;
                        i = add2pyramid(arr, i, k);
                    }
                }
              
            }

        }
       

       


    

