using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Composition.HOF
{/*
    public static class IEnumExts
    {
        public static IEnumerable<string[]> MySelect(this string[] enumerable, int index)
        {
            if (index % 100 == 0)
                    Console.WriteLine($"processed {index} items");
        }
    }*/
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
			    foreach (var dataLines in DataGenerator(dataSource)) //.MySelect()
			    {
                    c++;
                    PerformIfTrue(c % 100 == 0, Console.WriteLine, $"processed {c} items");
                    Write(writer.WriteLine, $"Sum({string.Join(" ", dataLines)}) = {Convert.ToString(Sum(dataLines), 16)}");
                }
			}
		}

	    private static int Sum(string[] dataLines)=>dataLines.Select(part => Convert.ToInt32(part, 16)).Sum();

	    private static void Write(Action<string> print, string s) => print(s);

        private static IEnumerable<string[]> DataGenerator(DataSource ds)
            => Repeat(ds.NextData).TakeWhile(x => x != null);

	    static IEnumerable<T> Repeat<T>(Func<T> get)
        {
            while (true) yield return get();
        }

        private static void PerformIfTrue(bool condition, Action<string> action, string line)
	    {
	        if (condition)
	            action(line);
	    }
	}
}