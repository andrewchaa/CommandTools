using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTail.Validation;
using Ninject.Modules;

namespace NTail
{
    public class NTailModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArgumentValidator>().To<ArgumentMustBeProvidedValidator>();
            Bind<IArgumentValidator>().To<FileMustExistValidator>();
        }
    }
}
