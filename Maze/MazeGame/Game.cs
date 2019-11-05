using System;

class Game : IGame
{
	public int Height { get; }
	public int Width { get; }
	public char PlayerSym { get; }
	public int GenSpeed { get; }

	Maze Maze;
	Player player;

	Cell Start { get; }
	Cell End { get; }

	public Game(int height, int width, char playerSym, int genSpeed)
	{
		Height = height;
		Width = width;
		PlayerSym = playerSym;
		GenSpeed = genSpeed;

		Initialize();

		Start = new Cell(1, 1);
		End = new Cell(Height - 2, Width - 2);
	}

	public void Initialize()
	{
		Maze = new Maze(Height, Width, ConsoleColor.Gray, ConsoleColor.Black);
		player = new Player(PlayerSym, Maze.Walls);
	}

	public void DisplayField()
	{
		Maze.Create(GenSpeed);

		Start.Display(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
		End.Display(ConsoleColor.Red, ConsoleColor.Red);
	}

	public void DisplayPlayer()
	{
		player.Display(ConsoleColor.Yellow, ConsoleColor.DarkBlue);
	}

	public void InputKey(ConsoleKeyInfo cki)
	{
		player.Erase(Maze.FieldColor, Maze.FieldColor);
		player.InputKey(cki);
	}

	public bool IsWon()
	{
		return player.IsCollidingWith(End);
	}
}