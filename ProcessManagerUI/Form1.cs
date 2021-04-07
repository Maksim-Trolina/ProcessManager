using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessManagerUI
{
    public partial class Form1 : Form
    {
        private Timer timer;

        private Process service;

        private BackEndService backEnd;

        public Form1()
        {
            InitializeComponent();

            var processesNames = new Dictionary<string, uint>();

            var path = "input.txt";

            var interval = 1000;

            backEnd = new BackEndService(path, processesNames);

            service = backEnd.CreateProcessesNamesService();

            service.Start();

            timer = new Timer()
            {
                Interval = interval
            };

            timer.Tick += new EventHandler(Update);

            timer.Start();

            Update(null, null);
        }

        private void Update(object sender, EventArgs e)
        {
            if (backEnd.IsUpdate())
            {
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            listProcesses.Items.Clear();

            var processesNames = backEnd.processesNames;

            foreach(var processName in processesNames)
            {
                for(var i = 0; i < processName.Value;i++)
                {
                    listProcesses.Items.Add(processName.Key);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            service.Kill();
        }
    }
}
