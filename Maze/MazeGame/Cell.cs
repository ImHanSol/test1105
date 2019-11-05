using System;

class Cell : Point
{
	// 4방향 벽
	public bool[] walls;

	public bool isVisited;

	public Cell(int x, int y) : base(' ', x, y)
	{
		walls = new bool[] { true, true, true, true };

		isVisited = false;
	}

	public void Display(ConsoleColor bgColor)
	{
		// 방문하지 않은 셀 표시 X
		if (isVisited)
			Display(Console.ForegroundColor, bgColor);
		else
			Display(Console.ForegroundColor, Console.BackgroundColor);

		// 각 셀 주위에 사용 가능한 벽 표시
		DisplayWalls(bgColor);
	}

	void DisplayWalls(ConsoleColor bgColor)
	{
		Cell c = null;

		for (int i = 0; i < walls.Length; i++)
		{
			if (i == (int)Direction.Up)
				c = new Cell(X - 1, Y);
			else if (i == (int)Direction.Right)
				c = new Cell(X, Y + 1);
			else if (i == (int)Direction.Down)
				c = new Cell(X + 1, Y);
			else if (i == (int)Direction.Left)
				c = new Cell(X, Y - 1);

			// 벽 활성화 - 아무것도 표시하지 않음
			// 벽 비활성화 - 셀로 표시
			if (walls[i])
				c.Display(Console.ForegroundColor, Console.BackgroundColor);
			else
				c.Display(Console.ForegroundColor, bgColor);
		}
	}

	public void Highlight()
	{
		Display(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
	}
}