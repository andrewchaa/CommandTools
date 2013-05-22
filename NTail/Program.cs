using System;
using System.IO;
using System.Linq;
using NTail.Validation;
using Ninject;

namespace NTail
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new NTailModule());

            var validators = kernel.GetAll<IArgumentValidator>();
            if (validators.Any(v => !v.Vaidate(args)))
                return;

            var tailer = kernel.Get<ITailer>();
            tailer.Tail(args[0]);
        }
    }
}
