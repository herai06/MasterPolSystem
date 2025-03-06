using Avalonia.Controls;
using MasterPolSystem.Models;
using ReactiveUI;

namespace MasterPolSystem.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;
        public MainWindowViewModel() { Instance = this; }

        public static MasterPolContext myConnection = new MasterPolContext();

        UserControl _uc = new ViewPartners();
        public UserControl UC { get => _uc; set => this.RaiseAndSetIfChanged(ref _uc, value); }
    }
}
