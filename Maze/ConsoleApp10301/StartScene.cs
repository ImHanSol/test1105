using System;
using System.Threading;

class StartScene: IMain
{
	private string[,] title = {
	 {" "," "," "," ","M","M"," "," "," "," "," ","M","M"," "," "," "," "," "," "," "," "," "," ","A","A","A","A","A","A","A","A"," "," "," "," "," ","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z"," "," "," "," "," "," ","E","E","E","E","E","E","E","E","E","E","E","E"},
	 {" "," "," ","M","M","M","M"," "," "," ","M","M","M","M"," "," "," "," "," "," "," "," ","A","A","A"," "," "," "," ","A","A","A"," "," "," "," "," "," "," "," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," ","E","E","E","E"," "," "," "," "," "," "," "," "," "},
	 {" "," "," ","M","M","M","M"," "," "," ","M","M","M","M"," "," "," "," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," "," "," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," ","E","E","E"," "," "," "," "," "," "," "," "," "," "," "},
	 {" ","M","M"," "," "," "," ","M","M","M"," "," "," "," ","M","M"," "," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," "," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," ","E","E"," "," "," "," "," "," "," "," "," "," "," "," "},
	 {" ","M","M"," "," "," "," ","M","M","M"," "," "," "," ","M","M"," "," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," "," ","E","E"," "," "," "," "," "," "," "," "," "," "," "," "},
	 {"M","M"," "," "," "," "," "," ","M"," "," "," "," "," "," ","M","M"," "," "," "," ","A","A","A","A","A","A","A","A","A","A","A","A"," "," "," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," "," "," ","E","E","E","E","E","E","E","E","E","E","E","E","E","E"},
	 {"M","M"," "," "," "," "," "," ","M"," "," "," "," "," "," ","M","M"," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," "," "," "," ","E","E"," "," "," "," "," "," "," "," "," "," "," "," "},
	 {"M","M"," "," "," "," "," "," ","M"," "," "," "," "," "," ","M","M"," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," "," "," "," "," ","E","E"," "," "," "," "," "," "," "," "," "," "," "," "},
	 {"M","M"," "," "," "," "," "," "," "," "," "," "," "," "," ","M","M"," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," "," "," "," "," "," ","E","E","E"," "," "," "," "," "," "," "," "," "," "," "},
	 {"M","M"," "," "," "," "," "," "," "," "," "," "," "," "," ","M","M"," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," "," ","Z","Z","Z"," "," "," "," "," "," "," "," "," "," "," "," "," ","E","E","E","E","E"," "," "," "," "," "," "," "," "," "},
	 {"M","M"," "," "," "," "," "," "," "," "," "," "," "," "," ","M","M"," "," "," "," ","A","A"," "," "," "," "," "," "," "," ","A","A"," "," "," ","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z","Z"," "," "," "," "," ","E","E","E","E","E","E","E","E","E","E","E","E","E"},
	 {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
	 };

	private int TitleShowingSpeed = 10; 
	private int XCenterPos = Console.WindowWidth / 2;
	private int YCenterPos = Console.WindowHeight / 2;
	private int XDisance = 35; // title 시작글자와 XCenterPos까지의 거리

	public void DrawTitle()
	{
		Console.WriteLine();
		for (int i = 0; i < title.GetLength(0); i++)
		{
			for (int index = 0; index < XCenterPos - XDisance; index++)
			{			
				Console.Write(" ");
			}
			for (int i1 = 0; i1 < title.GetLength(1); i1++)
			{
				Console.CursorVisible = false;
				if (title[i, i1] == "M")
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}
				if (title[i, i1] == "A")
				{				
					Console.ForegroundColor = ConsoleColor.Green;
				}
				if (title[i, i1] == "Z")
				{					
					Console.ForegroundColor = ConsoleColor.Yellow;
				}
				if (title[i, i1] == "E")
				{					
					Console.ForegroundColor = ConsoleColor.DarkCyan;
				}
				if (title[i, i1] != " ")
				{
					Thread.Sleep(TitleShowingSpeed);
				}

				Console.Write(title[i, i1]);
				Console.ResetColor();
			}
			Console.WriteLine();
		}
	}

	public void StartMenu(IGameLoop gameLoop, IGame game)
	{
		Console.CursorVisible = false;
		do
		{
			string key;

			do
			{
				DrawTitle();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.SetCursorPosition(XCenterPos - 5, YCenterPos + 1);
				Console.WriteLine("1. New game");
				Console.SetCursorPosition(XCenterPos - 5, YCenterPos + 2);
				Console.WriteLine("2. Quit");

				Console.ResetColor();
				key = Console.ReadLine();
				Console.Clear();
			} while (key != "1" && key != "2");

			switch (key)
			{
				case "1":
					game.Initialize();
					gameLoop.Run(game);
					break;
				case "2":
					Environment.Exit(0);
					break;
			}

			Console.Clear();
		} while (true);
	}
}

