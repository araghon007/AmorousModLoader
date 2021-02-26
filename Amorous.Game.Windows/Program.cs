using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Xna.Framework;
using SDL2;

public static class Program
{
	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern void AddDllDirectory(string newDirectory);

	[STAThread]
	public static void Main(string[] args)
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
		Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

        SetDefaultDllDirectories(4096);
        AddDllDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Environment.Is64BitProcess ? "x64" : "x86"));

		//Initializes logger
        _X6x9OC0TR5nhrrlKOc4hs3rbcWG._2yEsnTDA78XAQWbRmJumBkwidEr();

		FNALoggerEXT.LogInfo = Log.LogInfo;
		FNALoggerEXT.LogWarn = Log.LogWarn;
		FNALoggerEXT.LogError = Log.LogError;

		Environment.SetEnvironmentVariable("FNA_OPENGL_DISABLE_LATESWAPTEAR", "1");
		try
		{
			bool safeMode = args.Contains("-safemode");
			if (args.Contains("-disablesound"))
			{
				Environment.SetEnvironmentVariable("FNA_AUDIO_DISABLE_SOUND", "1");
			}
			using (MainGame mainGame = new MainGame(safeMode))
			{
				mainGame.Run();
			}
		}
		catch (Exception e)
		{
            ReportException(e);
		}
	}

	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool SetDefaultDllDirectories(uint directoryFlags);

	private static void ReportException(Exception e)
	{
        _X6x9OC0TR5nhrrlKOc4hs3rbcWG._jZsmDCE0PKmlrwTs5ijDiYaTEVB($"Unhandled exception: {e}");

		string errorMessage = $"{e.GetType().FullName}: {e.Message}\n\n";
		SDL.SDL_MessageBoxData messageBox;
		messageBox = new SDL.SDL_MessageBoxData
		{
			flags = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_ERROR,
			title = "Oh no, a crash!",
			message = errorMessage,
			numbuttons = 1,
			buttons = new SDL.SDL_MessageBoxButtonData[]
			{
				new SDL.SDL_MessageBoxButtonData
				{
					flags = SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT,
					buttonid = 0,
					text = "OK"
				}
			}
		};
		SDL.SDL_ShowMessageBox(ref messageBox, out _);
	}

	private static class Log
	{
		internal static void LogInfo(string message)
		{
            _X6x9OC0TR5nhrrlKOc4hs3rbcWG._q7sB0qiKf99xCTHUXkcw1xQgLZi(message);
		}

		internal static void LogWarn(string message)
		{
            _X6x9OC0TR5nhrrlKOc4hs3rbcWG._Vn58wKkFjvJAJpkokKtqcJQ0wmm(message);
		}

		internal static void LogError(string message)
		{
            _X6x9OC0TR5nhrrlKOc4hs3rbcWG._jZsmDCE0PKmlrwTs5ijDiYaTEVB(message);
		}

	}
}