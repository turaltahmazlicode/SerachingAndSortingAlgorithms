namespace ConsoleApp
{
    internal class Program
    {
        public static List<int>? GetFibofibonacciNumbers(int arrayLenght)
        {
            int f0 = 0, f1 = 1;
            List<int> fibNumbers = new List<int>() { 0, 1 };
            while (arrayLenght >= f1)
            {
                f1 += f0;
                f0 = f1 - f0;
                fibNumbers.Add(f1);
            }
            return fibNumbers;
        }
        public static int FibofibonacciSearch(List<int> array, int element)
        {
            List<int>? fiboSequence = GetFibofibonacciNumbers(array.Count());
            int fiboShiftingIndex = fiboSequence.Count();
            int offset = -1;
            int fm, fm1, fm2, arrayIndex;
            do
            {
                fm = fiboSequence[fiboShiftingIndex - 1];
                fm1 = fiboSequence[fiboShiftingIndex - 2];
                fm2 = fiboSequence[fiboShiftingIndex - 3];
                arrayIndex = offset + fm2 < array.Count() - 1 ? offset + fm2 : array.Count() - 1;
                if (array[arrayIndex] < element)
                {
                    offset = arrayIndex;
                    fiboShiftingIndex--;
                    continue;
                }
                fiboShiftingIndex -= 2;
            } while (fm > 3);
            if (array[arrayIndex] == element)
                return arrayIndex;
            return -1;
        }
        public static int InterpolationSearch(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;
            int pos;
            while (low <= high && key >= arr[low] && key <= arr[high])
            {
                pos = low + ((key - arr[low]) * (high - low)) / (arr[high] - arr[low]);
                if (arr[pos] == key)
                {
                    return pos;
                }
                if (arr[pos] < key)
                {
                    low = pos + 1;
                    continue;
                }
                if (arr[pos] > key)
                {
                    high = pos - 1;
                    continue;
                }
            }
            return -1;
        }
        public static int ReversedLinearSearch(ref int[] arr, int key, int start, int end)
        {
            for (int i = end; i >= start; i--)
                if (arr[i] == key)
                    return i;
            return -1;
        }

        public static int JumpSearch(int[] arr, int key)
        {
            int jumpStep = (int)Math.Round(Math.Sqrt(arr.Count()));
            for (int jump = jumpStep; jump < arr.Length; jump += jumpStep)
            {
                if (key <= arr[jump])
                {
                    int index = ReversedLinearSearch(ref arr, key, jump - jumpStep, jump);
                    if (index != -1)
                        return index;
                    break;
                }
            }
            return ReversedLinearSearch(ref arr, key, arr.Length - jumpStep, arr.Length - 1);
        }

        /*for (int j = 0; j * jumpStep < arr2.Length; j++)
            if (key <= arr2[jumpStep * j])
            {
                for (int j = jumpStep * j; j >= jumpStep * (j - 1); j--)
                    if (arr2[j] == key)
                        return j;
                break;
            }*/
        /*                    for (int j = jump; j >= jump - jumpStep; j--)
                                if (arr2[j] == key)
                                    return j;
                            LinearSearch(arr2[(jump - jumpStep)..jump], key, true) :
                                       LinearSearch(arr2[(arr2.Length - 1 - jumpStep)..(arr2.Length - 1)], key, true);
                        }
                        for (int j = arr2.Length - 1; j >= arr2.Length - 1 - jumpStep; j--)
                            if (arr2[j] == key)
                                return j;*/


        static void BubbleSort(int[] arr, int n)
        {
            int temp;
            bool isSorted;
            for (int i = 0, j; i < arr.Length - 1; i++)
            {
                isSorted = true;
                for (j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSorted = false;
                    }
                }
                if (isSorted)
                    break;
            }
        }

        static int BinarySearch(int[] arr, int n)
        {
            int low = 0, high = arr.Length - 1, mid;
            for (int i = 0; i < 7; i++)
            {
                mid = (low + high) / 2;
                if (arr[mid] == n)
                    return mid;
                if (n < arr[mid])
                {
                    high = mid;
                    continue;
                }
                low = mid;
            }
            return -1;
        }

        static void Main(string[] args)
        {

            int[] arr = { 1, 2, 3 };
            //Console.WriteLine(FibofibonacciSearch(new List<int> { -15, 5, 2, 5, 7, 10, 28, 30, 45, 56 }, 10));
            //Console.WriteLine(InterpolationSearch(new List<int> { -15, 5, 2, 5, 7, 10, 28, 30, 45, 56 }, 11));
            //Random random = new Random(1);
            //for (int length = 1, j = default, j = default, jump = default; length < 10000; length++)
            //{
            //    int[] arr = new int[length];
            //    for (j = 0; j < length; j++)
            //    {
            //        arr[j] = random.Next(j * 10000, (j + 1) * 10000);
            //    }
            //    for (j = 0; j < arr.Length; j++)
            //    {
            //        jump = JumpSearch(arr, arr[j]);
            //        if (-1 == jump)
            //        {
            //            Console.WriteLine("{0} {1} {2}", arr[j], jump, length);
            //        }
            //        //Console.WriteLine(arr2[j]);
            //    }
            //}
            BinarySearch([1], 1);
        }
    }
}
