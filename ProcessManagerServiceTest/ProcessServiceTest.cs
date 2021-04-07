using NUnit.Framework;
using ProcessManagerService;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessManagerServiceTest
{
    public class ProcessServiceTest
    {
        private string path = "test.txt";

        private Dictionary<string, uint> processesNames = new Dictionary<string, uint>();

        [SetUp]
        public void Setup()
        {
            File.WriteAllText(path, string.Empty);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(path);
        }

        [Test]
        public void Start_CheckRunningProcesses_WritingProcessNamesToFile()
        {
            var service = new ProcessService(path, processesNames);

            Task.Run(() => service.Start());

            Thread.Sleep(100);

            string data;

            do
            {
                data = GetDataFromFile();
            }
            while (data == null);

            Assert.IsTrue(data != string.Empty);
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