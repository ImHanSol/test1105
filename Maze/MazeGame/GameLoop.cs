using System;
using System.Threading;
using System.Diagnostics;

class GameLoop : IGameLoop
{
	Stopwatch stopwatch;

	public void Run(IGame game)
	{
		stopwatch = new Stopwatch();

		game.DisplayField();
		stopwatch.Start();
		Thread.Sleep(500);

		Console.SetCursorPosition(0, 25);
		Console.WriteLine("1분안에 도착하세요!");
		
		Console.WriteLine("\nUP   : ↑(W)\t LEFT  : ←(A)");
		Console.WriteLine("DOWN : ↓(S)\t RIGHT : →(D)");
		
		do
		{
			if (Console.KeyAvailable == true)
			{
				game.InputKey(Console.ReadKey(true));
				game.DisplayPlayer();
			}
			Console.WriteLine(DateTime.Now.ToString("mm:ss"));
		} while (!game.IsWon());

		stopwatch.Stop();

		// 타이머가 측정한 최종값
		TimeSpan time = stopwatch.Elapsed;
		string elapsedTime = string.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10);

		Console.WriteLine();
		Console.WriteLine("\n당신은 {0}초만에 도착하였습니다!", elapsedTime);
		if(time.Minutes >= 1)
		{
			Console.WriteLine("1분초과!!!!! 실패!!");
		}
		Console.WriteLine("계속 하시려면 Enter, 종료하시려면 Esc키를 눌러주세요");

		ConsoleKeyInfo key = Console.ReadKey(true);
		if (key.Key == ConsoleKey.Enter)
		{
			Console.Clear();
			game.Initialize();
			Run(game);
		}
		else if (key.Key == ConsoleKey.Escape)
		{
			Environment.Exit(0);			
		}
		else
		{
			Console.Read();
		}

	}

	public void PrintControls()
	{

	}
}
