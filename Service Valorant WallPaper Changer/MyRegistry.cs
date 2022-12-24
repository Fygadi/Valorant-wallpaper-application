using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Service_Valorant_WallPaper_Changer
{
	public static class MyRegistry
	{
		public const string MyHive = "HKEY_CURRENT_USER";
		public const string MyPath = @"SOFTWARE\ValorantWallPaper";
		public const string MyHiveAndPath = MyHive + @"\" + MyPath;
		public const string MyKeyNewWallPaper = "NewWallPaper";
		public const string MyKeyTimerDelay = "TimerDelay";
		public const string MyKeyValorantDefaultWallPapers = "ValorantDefaultWallPapers";

		public const string MyQueryPath = @"\\SOFTWARE\\ValorantWallPaper";

		/// <summary>Get the the path of the file or folder selected</summary>
		/// <returns>The full path or null if the key dosen't exist</returns>
		public static string GetWallPaperPath()
		{
			string WallPaperPath = null;

			RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
			key.GetValue(MyKeyNewWallPaper);
			if (key != null)
				WallPaperPath = key.GetValue(MyKeyNewWallPaper).ToString();
			return WallPaperPath;
		}

		/// <summary>Get the the timer delay</summary>
		/// <returns>In ms the delay selected or null if there's no delay"/></returns>
		public static int GetTimerDelay()
		{
			int timerDelay;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
			timerDelay = Convert.ToInt32(key.GetValue(MyKeyTimerDelay));

			return timerDelay;
		}

		public static void SetDefaultValorantWallPapers(string[] wallpapers = null)
		{
			string value = "";

			if (wallpapers != null)
			{
				for (int i = 0; i < wallpapers.Length; i++)
				{
					value += Path.GetFileNameWithoutExtension(wallpapers[i]);

					if (i < wallpapers.Length - 1)
						value += "|";
				}
			}

			RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, true);
			key = Registry.CurrentUser.CreateSubKey(MyPath);
			key.SetValue(MyKeyValorantDefaultWallPapers, value);
			key.Close();

			Console.WriteLine("string out = " + value);

			//set value in registy
		}

		public static void GetDefaultValorantWallPapers()
		{
			int timerDelay;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
			timerDelay = Convert.ToInt32(key.GetValue(MyKeyTimerDelay));
		}
	}
}
