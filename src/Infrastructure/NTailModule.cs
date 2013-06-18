using NTail.Domain;
using NTail.Ports;
using NTail.Validation;
using Ninject.Modules;

namespace NTail.Infrastructure
{
    public class NTailModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArgumentValidator>().To<ArgumentMustBeProvidedValidator>();
            Bind<IArgumentValidator>().To<FileMustExistValidator>();
            Bind<ITailer>().To<Tailer>().InSingletonScope();
            Bind<IKeyHandler>().To<KeyHandler>().InSingletonScope();
            Bind<ITailState>().To<TailState>().InSingletonScope();
        }
    }
}
