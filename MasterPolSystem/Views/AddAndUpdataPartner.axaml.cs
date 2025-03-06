using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPolSystem.ViewModels;

namespace MasterPolSystem;

public partial class AddAndUpdataPartner : UserControl
{
    public AddAndUpdataPartner()
    {
        InitializeComponent();
        DataContext = new AddAndUpdataPartnerVM();
    }
    public AddAndUpdataPartner(int Id)
    {
        InitializeComponent();
        DataContext = new AddAndUpdataPartnerVM(Id);
    }

    private void Binding(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
    }
}