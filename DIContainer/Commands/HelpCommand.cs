using System;

namespace DIContainer.Commands
{
	public class HelpCommand : BaseCommand
	{
		private readonly CommandLineArgs args;
		private readonly Lazy<ICommand[]> commands;

		public HelpCommand(CommandLineArgs args, Lazy<ICommand[]> commands)
		{
			this.args = args;
			this.commands = commands;
		}

		//[Help("lists available commands")]
		public void Run()
		{
			foreach (var command in commands.Value)
			{
				Writer.WriteLine(command.Name);
			}
		}

		//[Help("display help for specified command")]
		public void Run(string commandName)
		{
			
		}

		public override void Execute()
		{
			Run();
		}
	}
}