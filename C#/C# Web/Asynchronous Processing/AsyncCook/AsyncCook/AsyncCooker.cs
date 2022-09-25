namespace AsyncCook
{
    using System.Threading.Tasks;

    public class AsyncCooker
    {
        public static async Task Work()
        {
            await Task.WhenAll(
                Tasks.HeatThePansAsync(),
                Tasks.UnfreezeMeatAsync(),
                Tasks.PeelPotatoesAsync());

            await Task.WhenAll(
                Tasks.CookBurgersAsync(),
                Tasks.FryFriesAsync(),
                Tasks.PourDrinksAsync());

            await Tasks.ServeAndEatAsync();
        }
    }
}
