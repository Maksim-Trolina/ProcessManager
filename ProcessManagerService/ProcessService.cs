using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProcessManagerService
{
    public class ProcessService
    {
        private string path;

        private Dictionary<string, uint> processesNames;

        public ProcessService(string path, Dictionary<string,uint> processesNames)
        {
            this.path = path;

            this.processesNames = processesNames;
        }

        public void Start()
        {
            do
            {
                Update();
            }
            while (true);
        }

        private (Dictionary<string, uint>, string) GetProcessesNames()
        {
            var processes = Process.GetProcesses();

            var namesDict = new Dictionary<string, uint>();

            var namesStr = new StringBuilder();

            foreach (var process in processes)
            {
                var name = process.ProcessName;

                namesStr.Append(name);

                namesStr.Append(' ');

                if (namesDict.ContainsKey(name))
                {
                    namesDict[name]++;
                }
                else
                {
                    namesDict[name] = 1;
                }
            }

            return (namesDict, namesStr.ToString());
        }



        private bool AreEqual(Dictionary<string, uint> dict1, Dictionary<string, uint> dict2)
        {

            return Enumerable.SequenceEqual(dict1.OrderBy(x => x.Key), dict2.OrderBy(x => x.Key));
        }

        private bool WriteProcessesNames(string path, string processesNames)
        {
            try
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write(processesNames);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void Update()
        {
            var (namesDict, namesStr) = GetProcessesNames();

            if (!AreEqual(processesNames, namesDict))
            {
                processesNames = namesDict;

                while (!WriteProcessesNames(path, namesStr)) ;
            }
        }
    }
}
