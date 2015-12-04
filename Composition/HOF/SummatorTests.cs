using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Composition.HOF
{
	[TestFixture]
	public class SummatorTests
	{
		[Test]
		public void Process_Input()
		{
			var actualResultFile = new FileInfo("process-result.txt");
			if (actualResultFile.Exists) actualResultFile.Delete();
			Summator.Process();
			FileAssert.AreEqual(new FileInfo("expected-process-result.txt"), actualResultFile);
		}

		[Test]
		[Explicit("Генератор данных. Не нужен для выполнения задания")]
		public void Generate_Input()
		{
			var r = new Random();
			File.WriteAllLines("process-large-file.txt",
				Enumerable.Range(0, 1000).Select(i =>
					string.Join(
						" ",
						Enumerable.Range(0, 4).Select(j => Convert.ToString(r.Next(1000), 16))
						)));
		}
	}
}