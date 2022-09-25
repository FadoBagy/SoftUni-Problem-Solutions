namespace AsyncCook
{
    public class SyncCooker
    {
        public static void Work() {
            Tasks.HeatThePans();
            Tasks.UnfreezeMeat();
            Tasks.PeelPotatoes();
            Tasks.CookBurgers();
            Tasks.FryFries();
            Tasks.PourDrinks();
            Tasks.ServeAndEat();
        }
    }
}
