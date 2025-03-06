using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPolSystem.ViewModels;

namespace MasterPolSystem;

public partial class ViewPartners : UserControl
{
    public ViewPartners()
    {
        InitializeComponent();
        DataContext = new ViewPartnerVM();
    }
}