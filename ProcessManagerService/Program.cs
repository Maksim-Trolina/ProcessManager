using System.Collections.Generic;
using System.IO;


namespace ProcessManagerService
{
    class Program
    {
        static void Main(string[] args)
        {
            var processesNames = new Dictionary<string, uint>();

            var path = "input.txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
            }

            var service = new ProcessService(path, processesNames);

            service.Start();
        }

    }
}
