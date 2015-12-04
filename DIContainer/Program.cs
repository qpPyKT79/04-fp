using System;
using System.IO;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;

namespace DIContainer
{
    public class Program
    {
        private readonly CommandLineArgs arguments;
        private readonly ICommand[] commands;

        public Program(CommandLineArgs arguments, params ICommand[] commands)
        {
            this.arguments = arguments;
            this.commands = commands;
        
        }

        static void Main(string[] args)
        {
	        Run(Console.Out, args);
        }

	    public static void Run(TextWriter textWriter, params string[] args)
	    {
		    var container = new StandardKernel();
		    container.Bind<CommandLineArgs>().ToConstant(new CommandLineArgs(args));
		    container.Bind<TextWriter>().ToConstant(textWriter);
		    container.Bind(c => c.FromThisAssembly().Select(typeof (ICommand).IsAssignableFrom).BindAllInterfaces());
		    container.Get<Program>().Run();
	    }

	    public void Run()
        {
            if (arguments.Command == null)
            {
                Console.WriteLine("Please specify <command> as the first command line argument");
                return;
            }
            var command = commands.FirstOrDefault(c => c.Name.Equals(arguments.Command, StringComparison.InvariantCultureIgnoreCase));
            if (command == null)
                Console.WriteLine("Sorry. Unknown command {0}", arguments.Command);
            else
                command.Execute();
        }
    }
}
