using System;
using Ninject.Modules;
using PRI_NaszSamochod.MobileAuthentication;

namespace PRI_NaszSamochód
{
    /// <summary>
    /// Handling dependency injection using Ninject
    /// </summary>
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IKeysHolder>().To<KeysHolder>();
        }
    }
}