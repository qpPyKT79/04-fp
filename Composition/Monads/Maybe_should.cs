using System;
using NUnit.Framework;

namespace Composition.Monads
{
	[TestFixture]
	public class Maybe_should
	{
		[Test]
		public void Create_FromValue()
		{
			var m = Maybe.FromValue(42);

			Assert.That(m.Success, Is.True);
			Assert.That(m.Value, Is.EqualTo(42));
		}

		[Test]
		public void Create_FromError()
		{
			var e = new Exception("123");
			var m = Maybe.FromError<int>(e);

			Assert.That(m.Success, Is.False);
			Assert.That(m.Error, Is.EqualTo(e));
		}
		
		// TODO Maybe Uncomment!
		
		[Test]
		public void Support_Linq_Syntax()
		{
			var res =
			    Maybe.Result(() => int.Parse("1358571172"))
			        .SelectMany(i => Convert.ToString(i, 16), (i, hex) => new {i, hex})
			        .SelectMany(@t => Guid.Parse(@t.hex + @t.hex + @t.hex + @t.hex));

			Assert.That(res.Success, Is.True);
			Assert.That(res.Value, Is.EqualTo(Guid.Parse("50FA26A450FA26A450FA26A450FA26A4")));
		}

		[Test]
		public void Return_Error_If_Error_On_Final_Stage()
		{
			var res =
				from i in Maybe.Result(() => int.Parse("0"))
				from hex in Convert.ToString(i, 16)
				from guid in Guid.Parse(hex + hex + hex + hex)  //Error is here!
				select guid;

			Assert.That(res.Error, Is.InstanceOf<FormatException>());
			Console.WriteLine(res.Error.Message);
		}

		[Test]
		public void Propagate_Error_Through_All_Stages()
		{
			var res =
				from i in Maybe.Result(() => int.Parse("UNPARSABLE")) //Error is here!
				from hex in Convert.ToString(i, 16)
				from guid in Guid.Parse(hex + hex + hex + hex)
				select guid;

			Assert.That(res.Error, Is.InstanceOf<FormatException>());
			Console.WriteLine(res.Error.Message);
		}
		
	}
}