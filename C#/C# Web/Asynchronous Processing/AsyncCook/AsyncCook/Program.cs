namespace AsyncCook
{
    using System.Threading.Tasks;

    internal class Program
    {
        static async Task Main()
        {
            await AsyncCooker.Work();
            // SyncCooker.Work();
            // await AllAtOnceCooker.Work();
        }
    }
}
