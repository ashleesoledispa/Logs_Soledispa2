using Microsoft.Maui.Controls;
using logs.ViewModels;

namespace logs.Views
{
    public partial class LogsPage : ContentPage
    {
        public LogsPage()
        {
            InitializeComponent();
            (BindingContext as LogsViewModel)?.LoadLogsCommand.Execute(null);
            Title = "Logs";
        }
    }
}
