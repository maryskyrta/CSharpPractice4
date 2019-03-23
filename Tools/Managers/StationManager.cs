using System;

using System.Windows;

namespace CSharpPractice4.Tools.Managers
{
    internal static class StationManager
    {
        public static event Action StopThreads;

        private static DataStorage _dataStorage;

        internal static DataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
