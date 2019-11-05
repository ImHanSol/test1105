using System;

enum Direction
{
	Left,
	Right,
	Up,	
	Down,	
}

public interface IMain
{
	void StartMenu(IGameLoop gameLoop, IGame game);
	void DrawTitle();
}

public interface IGameLoop
{
	void Run(IGame game);
}

public interface IGame
{
	void Initialize();
	void DisplayField();
	void DisplayPlayer();
	void InputKey(ConsoleKeyInfo cki);
	bool IsWon();
}



