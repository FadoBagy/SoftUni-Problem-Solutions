namespace AsyncCook
{
    using System.Threading.Tasks;
    using System;
    using System.Threading;

    public class Tasks
    {
        // Asynchronous tasks
        public static async Task HeatThePansAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("The pan is heated!");
        }

        public static async Task UnfreezeMeatAsync()
        {
            await Task.Delay(3000);
            Console.WriteLine("The meat is unfrozen!");
        }

        public static async Task PeelPotatoesAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("The potatoes are peeled!");
        }

        public static async Task CookBurgersAsync()
        {
            await Task.Delay(5000);
            Console.WriteLine("The burgers are cooked!");
        }

        public static async Task FryFriesAsync()
        {
            await Task.Delay(3000);
            Console.WriteLine("The fries are fried!");
        }

        public static async Task PourDrinksAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("The drinks are poured!");
        }

        public static async Task ServeAndEatAsync()
        {
            await Task.Delay(5000);
            Console.WriteLine("Delicious!");
        }

        // Synchronous "tasks"
        public static void HeatThePans()
        {
            Thread.Sleep(2000);
            Console.WriteLine("The pan is heated!");
        }

        public static void UnfreezeMeat()
        {
            Thread.Sleep(3000);
            Console.WriteLine("The meat is unfrozen!");
        }

        public static void PeelPotatoes()
        {
            Thread.Sleep(2000);
            Console.WriteLine("The potatoes are peeled!");
        }

        public static void CookBurgers()
        {
            Thread.Sleep(5000);
            Console.WriteLine("The burgers are cooked!");
        }

        public static void FryFries()
        {
            Thread.Sleep(3000);
            Console.WriteLine("The fries are fried!");
        }

        public static void PourDrinks()
        {
            Thread.Sleep(1000);
            Console.WriteLine("The drinks are poured!");
        }

        public static void ServeAndEat()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Delicious!");
        }
    }
}
