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

        static void Main(string[] args)
        {
            //Console.WriteLine(FibofibonacciSearch(new List<int> { -15, 5, 2, 5, 7, 10, 28, 30, 45, 56 }, 10));
            Console.WriteLine(InterpolationSearch(new List<int> { -15, 5, 2, 5, 7, 10, 28, 30, 45, 56 }, 11));
        }
    }
}
