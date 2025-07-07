using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace logs.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        public ObservableCollection<string> Logs { get; } = new();
        public ICommand LoadLogsCommand { get; }

        public LogsViewModel()
        {
            LoadLogsCommand = new RelayCommand(OnLoadLogs);
        }

        private void OnLoadLogs()
        {
            Logs.Clear();
            var path = Path.Combine(FileSystem.AppDataDirectory, "LOGS_SOLEDISPA.txt");
            if (!File.Exists(path)) return;
            foreach (var line in File.ReadAllLines(path))
                Logs.Add(line);
        }
    }
}
