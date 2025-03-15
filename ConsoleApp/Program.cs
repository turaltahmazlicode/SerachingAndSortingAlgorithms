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

        public static int InterpolationSearch(List<int> arr, int key)
        {
            int low = 0;
            int high = arr.Count() - 1;
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

        /*for (int i = 0; i * jumpStep < arr2.Length; i++)
            if (key <= arr2[jumpStep * i])
            {
                for (int j = jumpStep * j; j >= jumpStep * (i - 1); i--)
                    if (arr2[j] == key)
                        return j;
                break;
            }*/
        /*                    for (int i = jump; i >= jump - jumpStep; i--)
                                if (arr2[i] == key)
                                    return i;
                            LinearSearch(arr2[(jump - jumpStep)..jump], key, true) :
                                       LinearSearch(arr2[(arr2.Length - 1 - jumpStep)..(arr2.Length - 1)], key, true);
                        }
                        for (int i = arr2.Length - 1; i >= arr2.Length - 1 - jumpStep; i--)
                            if (arr2[i] == key)
                                return i;*/

        static void Main(string[] args)
        {
            //Console.WriteLine(FibofibonacciSearch(new List<int> { -15, 5, 2, 5, 7, 10, 28, 30, 45, 56 }, 10));
            //Console.WriteLine(InterpolationSearch(new List<int> { -15, 5, 2, 5, 7, 10, 28, 30, 45, 56 }, 11));
            Random random = new Random(1);
            for (int length = 1, i = default, j = default, jump = default; length < 10000; length++)
            {
                int[] arr = new int[length];
                for (j = 0; j < length; j++)
                {
                    arr[j] = random.Next(j * 10000, (j + 1) * 10000);
                }
                for (i = 0; i < arr.Length; i++)
                {
                    jump = JumpSearch(arr, arr[i]);
                    if (-1 == jump)
                    {
                        Console.WriteLine("{0} {1} {2}", arr[i], jump, length);
                    }
                    //Console.WriteLine(arr2[i]);
                }
            }
        }
    }
}
