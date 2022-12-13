using WallPaperChanger_NameSpace;

//******************************************************
//*Cyan  = variable information                       *
//*Green = Action Information worked correctly        *
//*Red   = Action Information didn't worked correctly *
//*****************************************************

WallPaperChanger wallPaper = new("ThisIsTheOriginalWallpaper.TITOWP");
Thread.Sleep(Timeout.Infinite);


public static class DataContainer
{
	public static bool FileLogs = true;
	public static string FileLogsName = "Logs.txt";
    public static bool ConsoleLogs = true;
}

//if (DataContainer.FileLogs)
//{
//	streamWriterDebug = new("Logs.txt", true);
//	streamWriterDebug.AutoFlush = true;
//		
//	streamWriterDebug.WriteLine("The programme has start at " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
//	streamWriterDebug.WriteLine();
//}