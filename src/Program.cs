using System.Linq;
using System.Threading.Tasks;
using NTail.Domain;
using NTail.Infrastructure;
using NTail.Ports;
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

            var keyHandler = kernel.Get<IKeyHandler>();
            Task.Factory.StartNew(keyHandler.Handle);


            var tailState = kernel.Get<ITailState>();
            
            var highlighter = new ErrorHighlighter(new WarnHighlighter(new PlainWriter()));
            var tailer = args.Length == 1 ? new Tailer(highlighter, tailState) : 
                                 new Tailer(new KeywordHighlighter(highlighter, args[1]), tailState);
            tailer.Tail(args[0]);

        }

    }
}
