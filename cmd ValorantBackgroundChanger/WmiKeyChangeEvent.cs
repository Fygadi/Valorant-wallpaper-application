using Microsoft.Win32;
using System.Management;
using System.Security.Principal;

using MyRegistry_NameSpace;

namespace WmiKeyChangeEvent_NameSpace
{
    public class WmiKeyChange
    {
        Action<object, EventArrivedEventArgs> KeyWallPaperChangeCallback;
        Action<object, EventArrivedEventArgs> KeyTimerDelayChangeCallback;
        public WmiKeyChange(Action<object, EventArrivedEventArgs> tmp_KeyWallPaperChangeCallback,
                            Action<object, EventArrivedEventArgs> tmp_KeyTimerDelayChangeCallback)
        {
            KeyWallPaperChangeCallback = tmp_KeyWallPaperChangeCallback;
            KeyTimerDelayChangeCallback = tmp_KeyTimerDelayChangeCallback;

            StartQueryWallPaper();
            StartQueryTimerDelay();
        }

        private void StartQueryWallPaper()
        {
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\nQuery WallPaper");
            try
            {
                WqlEventQuery query = new WqlEventQuery(
                    "SELECT * FROM RegistryValueChangeEvent WHERE " +
                    "Hive = 'HKEY_USERS'" + "AND KeyPath = '" + Path.Join(GetCurentUserSID(), MyRegistry.MyQueryPath) + "'" +
                    "AND ValueName= '" + MyRegistry.MyNameNewWallPaper + "'");

                ManagementEventWatcher watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += new EventArrivedEventHandler(KeyWallPaperChangeCallback);
                watcher.Start();
                Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Start");
				//Console.WriteLine("Waiting for an event...");
			}
            catch (ManagementException managementException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + managementException.Message);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void StartQueryTimerDelay()
        {
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\nQuery TimerDelay");
            try
            {
                WqlEventQuery query = new WqlEventQuery(
                    "SELECT * FROM RegistryValueChangeEvent WHERE " +
                    "Hive = 'HKEY_USERS'" + "AND KeyPath = '" + Path.Join(GetCurentUserSID(), MyRegistry.MyQueryPath) + "'" +
                    "AND ValueName= '" + MyRegistry.MyNameTimerDelay + "'");

                ManagementEventWatcher watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += new EventArrivedEventHandler(KeyTimerDelayChangeCallback);
                watcher.Start();
                
                Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Start\n");
				//Console.WriteLine("Waiting for an event...");
			}
            catch (ManagementException managementException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + managementException.Message);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        ///<summary>
        ///Get the current user SID
        ///(Require administrator permission)
        ///</summary>
        private string GetCurentUserSID()
        {
            string SID = "";
            string currentUserName = WindowsIdentity.GetCurrent().Name.ToString();
            RegistryKey regDir = Registry.LocalMachine;
            
            using (RegistryKey regKey = regDir.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\SessionData", true))
            {
                if (regKey != null)
                {
                    string[] valueNames = regKey.GetSubKeyNames();
                    for (int i = 0; i < valueNames.Length; i++)
                    {
                        using (RegistryKey key = regKey.OpenSubKey(valueNames[i], true))
                        {
                            string[] names = key.GetValueNames();
                            for (int e = 0; e < names.Length; e++)
                            {
                                if (names[e] == "LoggedOnSAMUser")
                                {
                                    if (key.GetValue(names[e]).ToString() == currentUserName)
                                    {
                                        SID = key.GetValue("LoggedOnUserSID").ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return SID;
        }
    }
}