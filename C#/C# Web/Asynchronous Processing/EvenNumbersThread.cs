internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int startNumber = numbers[0];
        int endNumber = numbers[1];
        var thread = new Thread(() =>
        {
            PrintEvenNumbers(startNumber, endNumber);
        });
        thread.Start();
        Console.WriteLine("Working...");
        thread.Join();
        Console.WriteLine("Thread finished working!");
    }

    public static void PrintEvenNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}