using System;

namespace ConwaysGameOfLife
{
	public class ConsoleUi
	{
		public ConsoleUi(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		private readonly int width;
		private readonly int height;
		private static readonly ConsoleColor[] colors =
		{
			ConsoleColor.Black,  
			ConsoleColor.DarkGray, 
			ConsoleColor.Gray, 
			ConsoleColor.White
		};

		public void Update(Game field)
		{
			var oldColor = Console.BackgroundColor;
			try
			{
				Console.SetCursorPosition(0, 0);
				for (int y = 0; y < height; y++)
				{
					for (int x = 0; x < width; x++)
					{
						var age = field.GetAge(x, y);
						Console.BackgroundColor = colors[Math.Min(age, colors.Length - 1)];
						Console.Write(' ');
					}
					Console.WriteLine();
				}
			}
			finally
			{
				Console.BackgroundColor = oldColor;
			}
		}

		public void Update(Point point, int age)
		{
			Console.SetCursorPosition(point.X, point.Y);
			Console.BackgroundColor = colors[Math.Min(age, colors.Length - 1)];
			Console.Write(' ');
		}
	}
}