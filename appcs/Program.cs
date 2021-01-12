using System;
using System.Collections.Generic;

namespace mabf
{
    class Program
    {
        static Dictionary<string, List<string>> declarings = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> associatinons = new Dictionary<string, List<string>>();

        static List<string> devices = new List<string>()
            {
                "SLB-01", "SLB-02", "SLB-03"
            };

        static List<string> firmwares = new List<string>()
            {
                "FW-01", "FW-02"
            };

        static List<string> patients = new List<string>()
            {
                "User-01", "User-02", "User-02"
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Devices :");
            devices.ForEach(device => Console.WriteLine(device));
            Console.WriteLine("\nFirmwares :");
            firmwares.ForEach(firmware => Console.WriteLine(firmware));
            Console.WriteLine("\nPatients :");
            patients.ForEach(patient => Console.WriteLine(patient));
            bool exit = false;
            while (exit == false)
            {
                ShowData();
                ShowMenu();

                int val = Convert.ToInt32(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        Declare();
                        break;
                    case 2:
                        Associate();
                        break;
                    case 3:
                        Disassociate();
                        break;
                    case 4:
                        ShowData();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private static void ShowMenu() {
            Console.WriteLine("***************************");
            Console.WriteLine("\nVeuillez choisir le num de la fonctionnalité :");
            Console.WriteLine("\t1) Déclarer device avec Firmware. \n\t2) Associer device avec Patient. \n\t3) Dissocier device pour Patient. \n\t4) Maj Firmware \n\t5) exit \n");
        }
        private static void ShowData()
        {
            foreach (KeyValuePair<string, List<string>> declaring in declarings)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Firmware: " + declaring.Key);
                declaring.Value.ForEach(x => Console.WriteLine("\tDevice: "+x));
            }
            foreach (KeyValuePair<string, List<string>> association in associatinons)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Patient " + association.Key);
                association.Value.ForEach(x => Console.WriteLine("\tDevice: "+x));
            }
        }
        private static void Declare()
        {
            Console.WriteLine("Enter device :");
            string deviceName = Console.ReadLine();
            Console.WriteLine("Enter firmware :");
            string firmwareName = Console.ReadLine();
            if (declarings.ContainsKey(firmwareName))
            {
                var firmwareDevices = declarings.GetValueOrDefault(firmwareName);
                if (firmwareDevices.Contains(deviceName))
                {
                    Console.WriteLine("(" + firmwareName + ", " + deviceName + ") is already associated !");
                }
                else
                {
                    firmwareDevices.Add(deviceName);
                    Console.WriteLine("(" + firmwareName + ", " + deviceName + ") is successefuly associated !");
                }
            }
            else
            {
                declarings.Add(firmwareName, new List<string>()
                {
                    deviceName
                });
                Console.WriteLine("(" + firmwareName + ", " + deviceName + ") is successefuly associated !");

            }
        }

        private static void Associate()
        {
            Console.WriteLine("Enter device :");
            string deviceName = Console.ReadLine();
            Console.WriteLine("Enter patient :");
            string patientName = Console.ReadLine();
            if (associatinons.ContainsKey(patientName))
            {
                var patientDevices = associatinons.GetValueOrDefault(patientName);
                if (patientDevices.Contains(deviceName))
                {
                    Console.WriteLine("(" + patientName + ", " + deviceName + ") is already associated !");
                }
                else
                {
                    patientDevices.Add(deviceName);
                    Console.WriteLine("(" + patientName + ", " + deviceName + ") is successefuly associated !");
                }
            }
            else
            {
                associatinons.Add(patientName, new List<string>()
                {
                    deviceName
                });
                Console.WriteLine("(" + patientName + ", " + deviceName + ") is successefuly associated !");

            }
        }

        private static void Disassociate()
        {
            Console.WriteLine("Enter device :");
            string deviceName = Console.ReadLine();
            Console.WriteLine("Enter patient :");
            string patientName = Console.ReadLine();
            bool notAssociated = true;
            if (associatinons.ContainsKey(patientName))
            {
                var patientDevices = associatinons.GetValueOrDefault(patientName);
                if (patientDevices.Contains(deviceName))
                {
                    patientDevices.Remove(deviceName);
                    notAssociated = false;
                }
            }
            if (notAssociated == true)
            {
                Console.WriteLine("You can't disassociate (" + patientName + ", " + deviceName + ") because they are not associated!");
            }
            else
            {
                Console.WriteLine("(" + patientName + ", " + deviceName + ") is successefuly disassociated !");

            }
        }
        
    }
}
