using Microsoft.Win32;

namespace MyRegistry_NameSpace
{
    public static class MyRegistry
    {
        public const string MyHive = "HKEY_CURRENT_USER";
        public const string MyPath = @"SOFTWARE\ValorantWallPaper";
        public const string MyHiveAndPath = MyHive + @"\" + MyPath;
        public const string MyNameNewWallPaper = "NewWallPaper";
        public const string MyNameTimerDelay = "TimerDelay";
        public const string MyQueryPath = @"\\SOFTWARE\\ValorantWallPaper";

        /// <summary>Get the the path of the file or folder selected</summary>
        /// <returns>The full path or null if the key dosen't exist</returns>
        public static string GetWallPaperPath()
        {
			string WallPaperPath = null;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
            key.GetValue(MyNameNewWallPaper);
            if (key != null)
                WallPaperPath = key.GetValue(MyNameNewWallPaper).ToString();
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
    }
}
