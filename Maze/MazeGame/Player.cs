using System;
using System.Collections.Generic;
using System.Linq;

class Player : Point
{
	List<Cell> walls;

	public Player(char value, List<Cell> walls) : base(value, 1, 1)
	{
		this.walls = walls;
	}

	public void InputKey(ConsoleKeyInfo cki)
	{
		switch (cki.Key)
		{
			case ConsoleKey.D:
			case ConsoleKey.RightArrow:
				Y += 1;
				if (IsCollidingWithWall())
					Y -= 1;
				break;
			case ConsoleKey.A:
			case ConsoleKey.LeftArrow:
				Y -= 1;
				if (IsCollidingWithWall())
					Y += 1;
				break;
			case ConsoleKey.S:
			case ConsoleKey.DownArrow:
				X += 1;
				if (IsCollidingWithWall())
					X -= 1;
				break;
			case ConsoleKey.W:
			case ConsoleKey.UpArrow:
				X -= 1;
				if (IsCollidingWithWall())
					X += 1;
				break;
		}
	}

	// 벽 리스트에 플레이어 좌표가 포함되어 있는지 확인
	bool IsCollidingWithWall()
	{
		return walls.Any(c => c.IsCollidingWith(this));
	}
}
