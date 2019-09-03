using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmSort
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<int> oldList = new List<int>();
            List<int> newList;
            Random random = new Random();

            Console.WriteLine("Original array elements:");
            for (int i = 0; i < 30; i++)
            {
                oldList.Add(random.Next(-90, 500));
                Console.Write(oldList[i] + " ");
            }
            Console.WriteLine();

            newList = MergeSort(oldList);

            Console.WriteLine("Merge Sorted array elements:");
            foreach (int x in newList)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");

            //convert List to array using in Quick Sort method
            int[] array = oldList.ToArray();
            Quick_Sort(array, 0, array.Length - 1);

            Console.WriteLine();

            Console.WriteLine(" Quick Sorted array : ");

            foreach (var item in array)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count<2)
                return unsorted;
            List<int> lhand = new List<int>();
            List<int> rhand = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                lhand.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                rhand.Add(unsorted[i]);
            }
            lhand = MergeSort(lhand);
            rhand = MergeSort(rhand);

            return MergeList(lhand, rhand);
        }
        private static List<int> MergeList(List<int> lhand, List<int> rhand)
        {
            List<int> sortedList = new List<int>();

            // left and right List must be sorted List
            while (lhand.Count > 0 || rhand.Count > 0)
            {
                //compare left hand and right hand
                if (lhand.Count > 0 && rhand.Count > 0)
                {    
                    if (lhand.First() <= rhand.First())
                    {
                        //when left hand <=right hand choose left hand into the sortedList
                        // then remove the number out from left List
                        sortedList.Add(lhand.First());
                        lhand.Remove(lhand.First());
                    }
                    else
                    {
                        //when right hand <=left hand choose right hand into the sortedList
                        // then remove the number out from right List
                        sortedList.Add(rhand.First());
                        rhand.Remove(rhand.First());
                    }
                }
                //the last List is left hand add elements from left hane to sortedList
                else if (lhand.Count > 0)
                {
                    sortedList.Add(lhand.First());
                    lhand.Remove(lhand.First());
                }
                //the last list is right hand add elements from right hane to sortedList
                else if (rhand.Count > 0)
                {
                    sortedList.Add(rhand.First());
                    rhand.Remove(rhand.First());
                }
            }
            return sortedList;
        }
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            //left index < right index(from swith begin to switch end)
            if (left < right)
            {
                // arr is refence type it keep changed result
                int pivot = Partition(arr, left, right);

                if (pivot > 1)// switch again from left hand if finished return to mether begin
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }
        private static int Partition(int[] arr, int left, int right)
        {
            //get switch number by left index
            int pivot = arr[left];

            while (true)
            {
                //ignore less than it from left
                while (arr[left] < pivot)
                {
                    left++;
                }
                //ignore greater than it from right
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
                    //switch numbers in array
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

    }
}
