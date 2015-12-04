using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Composition.HOF
{
	public class Summator
	{
		/*
		Отрефакторите код.
			1. Отделите максимум логики от побочных эффектов.
			2. Создайте нужные вам методы.
			3. Сделайте так, чтобы максимум кода оказалось внутри универсальных методов, потенциально полезных в других местах программы.
		*/
		public static void Process()
		{
			using (var dataSource = new DataSource())
			using (var writer = new StreamWriter("process-result.txt"))
			{
				var c = 0;
				while (true)
				{
					var s = dataSource.NextData();
					if (s == null) break;
					c++;
					if (c % 100 == 0)
						Console.WriteLine("processed {0} items", c);
					var sum = s.Select(part => Convert.ToInt32(part, 16)).Sum();
					writer.WriteLine("Sum({0}) = {1}", string.Join(" ", s), Convert.ToString(sum, 16));
				}
			}
		}
	}
}