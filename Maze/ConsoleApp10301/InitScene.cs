using System;

class InitScene : IMain
{
	public void StartGame(IGameLoop gameLoop, IGame game)
	{
		Console.CursorVisible = false;

		do
		{
			string key;

			do
			{
				Console.WriteLine("1. New game");
				Console.WriteLine("2. Quit");
				Console.WriteLine("3. Option");
				key = Console.ReadLine();
				Console.Clear();
			} while (key != "1" && key != "2" && key != "3");

			switch (key)
			{
				case "1":
					game.Initialize();
					gameLoop.Run(game);
					break;
				case "2":
					Environment.Exit(0);
					break;
				case "3":
					Option(gameLoop, game);
					break;
			}

			Console.Clear();
		} while (true);
	}

	public void Option(IGameLoop gameLoop, IGame game)
	{
		string key;
		Console.Clear();

		do
		{
			Console.WriteLine("1. Easy");
			Console.WriteLine("2. Normal");
			Console.WriteLine("3. Difficult");
			Console.WriteLine("4. Back");
			key = Console.ReadLine();
			Console.Clear();
		} while (key != "1" && key != "2" && key != "3" && key != "4");

		switch (key)
		{
			case "1":
				game = new Game(9, 13, '@', 10);
				break;
			case "2":
				game = new Game(19, 25, '@', 10);
				break;
			case "3":
				game = new Game(25, 33, '@', 10);
				break;
			case "4":
				StartGame(gameLoop, game);
				break;
		}
	}
}

