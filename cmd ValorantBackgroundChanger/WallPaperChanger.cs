﻿using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

using TimerWallPaper_NameSpace;
using System.Management;
using ProcessWatchEvent_NameSpace;
using WmiKeyChangeEvent_NameSpace;
using MyRegistry_NameSpace;

namespace WallPaperChanger_NameSpace
{
    public class WallPaperChanger
    {
		//File variable
		//private readonly StreamWriter streamWriterDebug = null;

		//Variable use for the application
		private readonly string newTmpNameOfOriginalWallPaper;
        private readonly string valBackgroundDirectory;
		private const string defaultHomeScreenFileName = "Homepage_Ep5_AIII.mp4";

		protected internal ProcessWatch processWatch;
		protected internal WmiKeyChange wmiKeyChange;
		private readonly TimerWallPaper timerNextWallPaper;
        private readonly List<string> alreadyUsedWallPaper = new ();

        public WallPaperChanger(string tmpNameDefaultValBackground)
        {
            //SetGlobaleVariable
			newTmpNameOfOriginalWallPaper = tmpNameDefaultValBackground;
            valBackgroundDirectory = GetValorantHomeBackgroundPath();

            ShowGlobalVariableInformation();

			//create objects
			wmiKeyChange = new((Action<object, EventArrivedEventArgs>)this.WmiWallPaperKeyChange, (Action<object, EventArrivedEventArgs>)this.WmiTimerKeyChange);
			processWatch = new((Action)this.ValorantStart, (Action)this.ValorantStop);
			timerNextWallPaper = new TimerWallPaper(this.TimerEventNextWallPaper);

			if (ValorantIsRunning())
            {
                if (!NewWallPaperIsSet())
                    SetWallPaper();
                if (GetWallPaperType() == "folder")
                    timerNextWallPaper.StartTimer();
            }
            else
            {
                UnnameOriginalWallPaper();
            }
		}

        /// <summary> Check if the orignal wallPaper is renamed </summary>
        private bool OriginalWallPaperIsNamed()
        {
            bool isRenamed = false;
            foreach (string file in Directory.GetFiles(valBackgroundDirectory))
            {
                if (Path.GetFileName(file) == newTmpNameOfOriginalWallPaper)
                {
                    isRenamed = true;
                    break;
                }
            }
            return isRenamed;
        }

        /// <summary> Check if the new wallpaper is set </summary>
        private bool NewWallPaperIsSet()
        {
            bool isSet = false;
            if (OriginalWallPaperIsNamed())
                if (File.Exists(Path.Combine(valBackgroundDirectory, defaultHomeScreenFileName)))
                    isSet = true;
            return isSet;
        }

        ///<summary>Verify if Valorant is runing</summary>
        static bool ValorantIsRunning()
        {
            return Process.GetProcessesByName("valorant").Length == 0? false : true;
        }

        ///<summary>Change the valorant wallPaper</summary>
        private void SetWallPaper()
        {
            string WallPaperPath = MyRegistry.GetWallPaperPath();

            string selectedWallPaper = "";
            string fileType = GetWallPaperType();

            if (fileType == "folder")
            {
                selectedWallPaper = SelectRandomNewWallPaperFromFolder(WallPaperPath);
            }
            else if (fileType == "mp4File")
            {
                selectedWallPaper = WallPaperPath;
            }

            if (selectedWallPaper != "")
            {
                if (!OriginalWallPaperIsNamed())
                    NameOriginalWallPaper();
                try
                {
                    File.Copy(selectedWallPaper, Path.Join(valBackgroundDirectory, defaultHomeScreenFileName), true);
                    Console.Write("The new wallPaper is : ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(Path.GetFileNameWithoutExtension(selectedWallPaper));
				}
                catch
                {
					Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Exception when changing the wallpaper");
				}
                finally
                {
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("\"\n");
				}
            }
        }

        ///<summary>Determine wich type of file has been selected then set the background with the selected file</summary>
        /// <returns>Possible (mp4File, folder, null)</returns>
        static string GetWallPaperType()
        {
            string fileType = "";
            string wallPaperPath = MyRegistry.GetWallPaperPath();
            if (Directory.Exists(wallPaperPath))
                fileType = "folder";
            else if (File.Exists(wallPaperPath) && Path.GetExtension(wallPaperPath) == ".mp4")
                fileType = "mp4File";
            else if (wallPaperPath == null){ }

            return fileType;
        }

        ///<summary>Select a random file from a directory</summary>
        ///<returns>The path of the random file or null if there's no valid elements</returns>
        private string SelectRandomNewWallPaperFromFolder(string wallPaperDirectoryPath)
        {
            List<string> validFiles = new(Directory.GetFiles(wallPaperDirectoryPath, "*.mp4"));
            string selectedFile = null;

            //if there is any wallPaper to use
            if (validFiles.Count != 0)
            {
                foreach (string file in alreadyUsedWallPaper)
                    validFiles.Remove(file);

                //if all the file have been use
                if (validFiles.Count == 0)
                {
                    validFiles = Directory.GetFiles(wallPaperDirectoryPath, "*.mp4").ToList();
                    if (validFiles.Count > 1)
                    validFiles.Remove(alreadyUsedWallPaper.Last());
                    alreadyUsedWallPaper.Clear();
                }

                Random r = new ();
                selectedFile = validFiles[r.Next(validFiles.Count)];

                if (selectedFile != null)
                {
                    if (!alreadyUsedWallPaper.Contains(selectedFile))
                    {
                        alreadyUsedWallPaper.Add(selectedFile);
                    }
                }
            }
            return selectedFile;
        }

        ///<summary>Set the name of the original wallPaper to default</summary>
        private void UnnameOriginalWallPaper()
        {
            try
            {
                if (OriginalWallPaperIsNamed())
                {
                    File.Move(valBackgroundDirectory + newTmpNameOfOriginalWallPaper, valBackgroundDirectory + defaultHomeScreenFileName, true);
                    Console.WriteLine("The default wallpaper as been replaced");
                }
            }
            catch
            {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Exception while replacing the default wallpaper");
				Console.ForegroundColor = ConsoleColor.White;
			}
        }

        ///<summary>Change the name of the original wallPaper</summary>
        private void NameOriginalWallPaper()
        {
            if (File.Exists(valBackgroundDirectory + defaultHomeScreenFileName) && !OriginalWallPaperIsNamed())
                File.Move(valBackgroundDirectory + defaultHomeScreenFileName, valBackgroundDirectory + newTmpNameOfOriginalWallPaper);
        }

        ///<summary>Return the Absolute path of the background Folder or File selected</summary>
        static string GetValorantHomeBackgroundPath()
        {
            object directory = Registry.GetValue(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\" +
                @"CurrentVersion\Uninstall\Riot Game valorant.live",
                "InstallLocation", null);

            if (directory == null)
            {
                Console.WriteLine("Valorant is not instaled");
                Console.WriteLine("Press on a key to exit");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            return directory + @"/ShooterGame/Content/Movies/Menu/";
        }





        //****************************
        //*       All callback       *
        //****************************

        ///<summary>This methode is call when Valorant as start</summary>
        public void ValorantStart()
        {
            Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("   VALORANT AS BEEN STARTED !   \n");
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

            SetWallPaper();
            if (GetWallPaperType() == "folder")
                timerNextWallPaper.StartTimer();
        }

        ///<summary>This method is call when Valorant as closed</summary>
        public void ValorantStop()
        {
            Console.WriteLine("\nIn method " + MethodBase.GetCurrentMethod().Name);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("   VALORANT AS BEEN CLOSED !   ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            
            UnnameOriginalWallPaper();
            timerNextWallPaper.StopTimer();
        }

        public void TimerEventNextWallPaper(Object stateInfo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Elapsed event was raised at " + DateTime.Now.ToString("HH:mm:ss"));
            Console.ForegroundColor = ConsoleColor.White;
			SetWallPaper();
		}

        public void WmiWallPaperKeyChange(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("it's a " + GetWallPaperType());
            SetWallPaper();

            if (GetWallPaperType() == "folder")
                timerNextWallPaper.StartTimer();
            else
                timerNextWallPaper.StopTimer();
        }

        public void WmiTimerKeyChange(object sender, EventArrivedEventArgs e)
        {
            if (GetWallPaperType() == "folder")
                timerNextWallPaper.StartTimer();
        }





        //******************************
        //* Method to show information *
        //******************************
        private void ShowGlobalVariableInformation()
        {
            //show variable information
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t\t\t" + "Default Variable Value\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Valorant wallPaper directory".PadRight(32) + "\"");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(valBackgroundDirectory);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"\nTemporary wallpaper name".PadRight(34) + "\"");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(newTmpNameOfOriginalWallPaper);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"\nOriginal wallpaper default name".PadRight(34) + "\"");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(defaultHomeScreenFileName);


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(("\"\nThe selected wallpaper type").PadRight(34) + "\"");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(GetWallPaperType());

            Console.ForegroundColor = ConsoleColor.White;
            if (GetWallPaperType() == "mp4File")
                Console.Write(("\"\nThe selected file name").PadRight(34) + "\"");
            else
                Console.Write(("\"\nThe selected directory name").PadRight(34) + "\"");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Path.GetFileName(MyRegistry.GetWallPaperPath()));


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"\nOriginal wallpaper is rename".PadRight(34) + "\"");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(OriginalWallPaperIsNamed());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"\n\n");
        }





        //Not used method

        ///<summary>
        ///Move a File to a sub folder under the file location
        ///<para>Create the folder "FILES NOT ACCEPTED" if it dosen't exist</para> 
        ///</summary>
        static void MoveFileNotValid(string fileName, string directory)
        {
            const string fileNotAccepted = @"FILES NOT ACCEPTED\";
            if (!Directory.Exists(directory + fileNotAccepted))
            {
                Directory.CreateDirectory(directory + fileNotAccepted);
            }

            File.Move(Path.Join(directory, fileName), Path.Join(directory, fileNotAccepted, fileName));
        }

		///<summary>Select a random file from a directory</summary>
		///<returns>The path of the random file or null if there's no valid elements</returns>
		static string SelectRandomWallPaperFromFolder(string wallPaperDirectoryPath)
		{
			string[] validFiles = Directory.GetFiles(wallPaperDirectoryPath, "*.mp4");
			//var notValidFiles = Directory.GetFiles(wallPaperDirectoryPath).Where(name => !name.EndsWith(".mp4"));

			string selectedFile = null;
			if (validFiles.Length != 0)
			{
				Random r = new();
				selectedFile = validFiles[r.Next(0, validFiles.Length)];
			}
			return selectedFile;
		}
	}
}