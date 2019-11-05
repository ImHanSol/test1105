using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Maze
{
	public int Height { get; }
	public int Width { get; }
	
	public List<Cell> Cells { get; }
	public List<Cell> Walls { get; }
	Cell currentCell;

	// 재귀 함수 생성을 위한 스택
	Stack<Cell> stack = new Stack<Cell>();

	public ConsoleColor FieldColor { get; }
	public ConsoleColor WallsColor { get; }

	public Maze(int height, int width, ConsoleColor fieldColor, ConsoleColor wallsColor)
	{
		Cells = new List<Cell>();
		Walls = new List<Cell>();

		// 홀수로 바꾸기 (짝수 nono~)
		Height = height % 2 == 0 ? height - 1 : height;
		Width = width % 2 == 0 ? width - 1 : width;

		// 셀 추가
		for (int i = 1; i < Height; i += 2)
		{
			for (int j = 1; j < Width; j += 2)
			{
				Cells.Add(new Cell(i, j));
			}
		}

		// 벽 추가
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				Walls.Add(new Cell(i, j));
			}
		}

		// 컬러 입히기
		FieldColor = fieldColor;
		WallsColor = wallsColor;

		// 항상 첫번째 셀은 (1, 1)
		currentCell = Cells.First();
	}

	public void Create(int latency)
	{
		do
		{
			currentCell.isVisited = true;

			// 이웃셀 중 랜덤하게 다음 셀 고르기
			Cell nextCell = GetNeighbor(currentCell);

			// 확장이 가능한 이웃셀이 하나이상 있을 때 현재 셀이랑 다음 셀 사이의 벽 제거
			if (nextCell != null)
				RemoveWalls(currentCell, nextCell);

			// 현재 셀과 동일한 벽 제거
			foreach (Cell wall in Walls)
			{
				if (wall.X == currentCell.X && wall.Y == currentCell.Y)
				{
					Walls.Remove(wall);
					break;
				}
			}

			currentCell.Display(FieldColor);

			// 사용가능 다음 셀이 있을 때 현재 셀을 스택에 넣고 current옆에 할당
			if (nextCell != null)
			{
				stack.Push(currentCell);
				currentCell = nextCell;
			}
			// 그렇지 않으면 사용 가능 이웃이 하나 이상 있는 셀로 역 추적
			else if (stack.Count > 0)
				currentCell = stack.Pop();

			currentCell.Display(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);

			Thread.Sleep(latency);

			// 현재 셀이 처음으로 돌아오면 알고리즘 수행
		} while (!IsCompleted());

		// 벽 세팅
		foreach (Cell c in Walls)
			c.Display(WallsColor, WallsColor);
	}

	void RemoveWalls(Cell a, Cell b)
	{
		// a, b 사이에 벽 좌표 할당
		int x = (a.X != b.X) ? (a.X > b.X ? a.X - 1 : a.X + 1) : a.X;
		int y = (a.Y != b.Y) ? (a.Y > b.Y ? a.Y - 1 : a.Y + 1) : a.Y;

		// 벽 지우기
		foreach (Cell wall in Walls)
		{
			if (wall.X == x && wall.Y == y)
			{
				Walls.Remove(wall);
				break;
			}
		}

		// 각 셀에 대해 해당하는 벽 비활성화
		if (a.X - b.X == 2)
		{
			a.walls[(int)Direction.Up] = false;
			b.walls[(int)Direction.Down] = false;
		}
		else if (a.X - b.X == -2)
		{
			a.walls[(int)Direction.Down] = false;
			b.walls[(int)Direction.Up] = false;
		}

		if (a.Y - b.Y == 2)
		{
			a.walls[(int)Direction.Left] = false;
			b.walls[(int)Direction.Right] = false;
		}
		else if (a.Y - b.Y == -2)
		{
			a.walls[(int)Direction.Right] = false;
			b.walls[(int)Direction.Left] = false;
		}
	}

	Cell GetNeighbor(Cell cell)
	{
		Random rand = new Random();

		List<Cell> neighbors = new List<Cell>();

		// 사용 가능한 인접 셀 할당
		Cell up = (cell.X - 2 > 0) ? Cells.Find(c => c.X == cell.X - 2 && c.Y == cell.Y) : null;
		Cell right = (cell.Y + 2 < Width - 1) ? Cells.Find(c => c.Y == cell.Y + 2 && c.X == cell.X) : null;
		Cell down = (cell.X + 2 < Height - 1) ? Cells.Find(c => c.X == cell.X + 2 && c.Y == cell.Y) : null;
		Cell left = (cell.Y - 2 > 0) ? Cells.Find(c => c.Y == cell.Y - 2 && c.X == cell.X) : null;

		if (up != null && !up.isVisited)
		{
			neighbors.Add(up);
		}
		if (right != null && !right.isVisited)
		{
			neighbors.Add(right);
		}
		if (down != null && !down.isVisited)
		{
			neighbors.Add(down);
		}
		if (left != null && !left.isVisited)
		{
			neighbors.Add(left);
		}

		// 목록에서 임의의 이웃 반환
		if (neighbors.Count > 0)
		{
			int index = rand.Next(neighbors.Count);
			return neighbors[index];
		}
		// 아니면 반환 x
		return null;
	}

	// 스택이 비어있을 때 미로 완성
	bool IsCompleted()
	{
		return stack.Count == 0;
	}
}