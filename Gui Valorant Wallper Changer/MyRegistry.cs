using Gui_Valorant_Wallper_Changer;
using Microsoft.Win32;

public static class MyRegistry
{
	public const string MyHive = "HKEY_CURRENT_USER";
	public const string MyPath = @"SOFTWARE\ValorantWallPaper";
	public const string MyHiveAndPath = MyHive + @"\" + MyPath;
	public const string MyNameNewWallPaper = "NewWallpaper";
	public const string MyNameTimerDelay = "TimerDelay";
	public const string MyGUILastPosition = "GUILastLocation";

	public static string GetWallPaperPath()
	{
		string WallPaperPath = "";

		RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, true);
		key.CreateSubKey(MyNameNewWallPaper);
		if (key != null)
		{
			WallPaperPath = key.GetValue(MyNameNewWallPaper).ToString();
		}

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
		RegistryKey key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath, true);
			key.SetValue(MyRegistry.MyNameNewWallPaper, value);
			key.Close();
	}

	public static void SetTimerDelay(int value)
	{
		RegistryKey key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath, true);
		key.SetValue(MyRegistry.MyNameTimerDelay, value);
		key.Close();
	}

	public static Point GetGUILastPosition(Size formSize)
	{
		Point lastPosition = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - formSize.Width / 2,
									   Screen.PrimaryScreen.Bounds.Height / 2 - formSize.Height / 2);

		RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
		if (key.GetValue(MyGUILastPosition) != null)
		{
			try
			{
				string[] value = key.GetValue(MyGUILastPosition).ToString().Split(',');

				lastPosition = new Point(int.Parse(value[0]), int.Parse(value[1]));
			}
			catch { }
		}
		return lastPosition;
	}

	public static void SetGUILastPosition(Point point)
	{
		RegistryKey key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath, true);
		key.SetValue(MyRegistry.MyGUILastPosition, point.X + ", " + point.Y);

	}
}