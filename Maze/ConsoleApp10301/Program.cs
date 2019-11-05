using System;

class Program
{
	static void Main(string[] args)
	{
		Console.CursorVisible = false;

		StartScene initScene = new StartScene();
		IGameLoop gameLoop = new GameLoop();

		IGame game = new Game(5, 9, '@', 5); //25 51

		initScene.StartMenu(gameLoop, game);
	}
}

