using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using FakeItEasy;
using NUnit.Framework;

namespace DIContainer
{
    [TestFixture]
	[UseReporter(typeof(DiffReporter))]
    public class Program_should
    {
	    [Test]
	    public void show_help()
	    {
		    var output = new StringWriter();
		    
			Program.Run(output, "help");

		    Approvals.Verify(output.ToString().Replace("\r", ""));
	    }

		[Test]
		public void show_detailed_help()
		{
			var output = new StringWriter();

			Program.Run(output, "help help");

			Approvals.Verify(output.ToString().Replace("\r", ""));
		}
    }
}