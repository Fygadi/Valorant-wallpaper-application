using Microsoft.Win32;

public static class MyRegistry
{
	public const string MyHive = "HKEY_CURRENT_USER";
	public const string MyPath = @"SOFTWARE\ValorantWallPaper";
	public const string MyHiveAndPath = MyHive + @"\" + MyPath;
	public const string MyNameNewWallPaper = "NewWallpaper";
	public const string MyNameTimerDelay = "TimerDelay";

	public static string GetWallPaperPath()
	{
		string WallPaperPath = null;

		RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, true);
		key.CreateSubKey(MyNameNewWallPaper);
		if (key != null)
		{
			WallPaperPath = key.GetValue(MyNameNewWallPaper).ToString();
			Console.WriteLine("WallPaperPath = " + WallPaperPath);
		}
		else Console.WriteLine("WallPaperPath = NULL");

		return WallPaperPath;
	}

	/// <summary>Get the the timer delay</summary>
	/// <returns>In ms the delay selected or null if there's no delay"/></returns>
	public static int GetTimerDelay()
	{
		int timerDelay;
		RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
		timerDelay = Convert.ToInt32(key.GetValue(MyNameTimerDelay));

		return timerDelay;
	}

	public static void SetWallPaperPath(string value)
	{
		RegistryKey key = Registry.CurrentUser.OpenSubKey(MyRegistry.MyPath, true);
		if (key != null)
		{
			key.SetValue(MyRegistry.MyNameNewWallPaper, value);
			key.Close();
		}
		else
		{
			key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath);
			key.SetValue(MyRegistry.MyNameNewWallPaper, value);
			key.Close();
		}
	}

	public static void SetTimerDelay(int value)
	{
		RegistryKey key = Registry.CurrentUser.OpenSubKey(MyRegistry.MyPath, true);
		if (key != null)
		{
			key.SetValue(MyRegistry.MyNameTimerDelay, value);
			key.Close();
		}
		else
		{
			key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath);
			key.SetValue(MyRegistry.MyNameTimerDelay, value);
			key.Close();
		}
	}
}