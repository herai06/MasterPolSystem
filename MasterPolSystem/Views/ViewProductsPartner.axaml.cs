using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPolSystem.ViewModels;

namespace MasterPolSystem;

public partial class ViewProductsPartner : UserControl
{
    public ViewProductsPartner(int Id)
    {
        InitializeComponent();
        DataContext = new ViewProductsPartnerVM(Id);
    }
}