namespace AsyncCook
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AllAtOnceCooker
    {
        public static async Task Work()
        {
            var tasks = new List<Task>
            {
                Tasks.HeatThePansAsync(),
                Tasks.UnfreezeMeatAsync(),
                Tasks.PeelPotatoesAsync(),
                Tasks.CookBurgersAsync(),
                Tasks.FryFriesAsync(),
                Tasks.PourDrinksAsync(),
                Tasks.ServeAndEatAsync()
            };

            await Task.WhenAll(tasks);
        }
    }
}