using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProcessManagerUI
{
    public class BackEndService
    {
        private string path;

        public Dictionary<string, uint> processesNames { get; private set; }

        public BackEndService(string path, Dictionary<string,uint> processesNames)
        {
            this.path = path;

            this.processesNames = processesNames;
        }

        public bool IsUpdate()
        {
            string data;

            do
            {
                data = GetDataFromFile();
            }
            while (data == null);


            var currentProcessesNames = CreateDictionary(data);

            if (!AreEqual(currentProcessesNames, processesNames))
            {
                processesNames = currentProcessesNames;

                return true;
            }

            return false;
        }

        public Process CreateProcessesNamesService()
        {
            var serviceName = "ProcessManagerService.exe";

            var pathToService = Path.GetFullPath(serviceName);

            pathToService = pathToService.Replace("ProcessManagerUI", "ProcessManagerService");

            pathToService = pathToService.Replace("net5.0-windows", "net5.0");

            var service = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = pathToService,
                    CreateNoWindow = true
                }
            };

            return service;
        }

        private Dictionary<string, uint> CreateDictionary(string str)
        {
            var names = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var dict = new Dictionary<string, uint>();

            foreach (var name in names)
            {
                if (dict.ContainsKey(name))
                {
                    dict[name]++;
                }
                else
                {
                    dict[name] = 1;
                }
            }

            return dict;
        }

        private bool AreEqual(Dictionary<string, uint> dict1, Dictionary<string, uint> dict2)
        {
            return Enumerable.SequenceEqual(dict1.OrderBy(x => x.Key), dict2.OrderBy(x => x.Key));
        }

        private string GetDataFromFile()
        {
            try
            {
                using (var sr = new StreamReader(path))
                {
                    var data = sr.ReadToEnd();

                    return data;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
