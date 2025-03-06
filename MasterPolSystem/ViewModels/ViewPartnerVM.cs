using MasterPolSystem.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPolSystem.ViewModels
{
    internal class ViewPartnerVM : ViewModelBase
    {
        List<Partner> _listPartner;
        public List<Partner> ListPartner { get => _listPartner; set => this.RaiseAndSetIfChanged(ref _listPartner, value); }

        public ViewPartnerVM()
        {
            ListPartner = MainWindowViewModel.myConnection.Partners
                .Include(x => x.IdPartnerTypeNavigation)
                .Include(x => x.ProductPartners).ThenInclude(x => x.IdProductNavigation).ToList();
        }

        public void ToPageUpdata(int Id)
        {
            MainWindowViewModel.Instance.UC = new AddAndUpdataPartner(Id);
        }

        public void ToPageAdd()
        {
            MainWindowViewModel.Instance.UC = new AddAndUpdataPartner();
        }

        public void ToPadeHistoty(int Id)
        {
            MainWindowViewModel.Instance.UC = new ViewProductsPartner(Id);
        }
    }
}
