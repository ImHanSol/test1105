using System;

abstract class Point : Color
{
	public virtual char cValue { get; set; }
	public virtual int X { get; set; }
	public virtual int Y { get; set; }

	public Point(char value, int x, int y)
	{
		cValue = value;
		X = x;
		Y = y;
	}

	// 특정 위치에 컬러 표시
	public virtual void Display(ConsoleColor fgColor, ConsoleColor bgColor)
	{
		Console.SetCursorPosition(Y, X);
		ColorDisplay(cValue.ToString(), fgColor, bgColor);
	}

	// 포인트 지우기
	public virtual void Erase(ConsoleColor fgColor, ConsoleColor bgColor)
	{
		Console.SetCursorPosition(Y, X);
		ColorDisplay(" ", fgColor, bgColor);
	}

	// 다른 포인트와의 충돌 확인
	public virtual bool IsCollidingWith(Point p)
	{
		return X == p.X && Y == p.Y;
	}
}