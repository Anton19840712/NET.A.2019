using Ninject;

namespace NET.A._2019.Gridushko._22
{
    public static class ConfiguringResolver 
    {
        public static void ConfigureResolver(this IKernel kernel)
        {
            kernel.Bind<IRepository>().To<AccountsDbStorage>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IBonusCounter>().To<BonusCounter>();
            kernel.Bind<IGenerator>().To<Generator>();
        }
    }
}