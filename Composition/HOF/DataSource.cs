using System;
using System.IO;

namespace Composition.HOF
{
	///<summary>Этот класс нельзя менять. Считайте, что он вам дан в виде бинарной зависимости.</summary>
	public class DataSource : IDisposable
	{
		private readonly StreamReader reader;
		public DataSource()
		{
			reader = new StreamReader("process-large-file.txt");
		}

		///<returns>null if no more data</returns>
		public string[] NextData()
		{
			var line = reader.ReadLine();
			return line == null ? null : line.Split(' ');
		}

		public void Dispose()
		{
			reader.Close();
		}
	}
}