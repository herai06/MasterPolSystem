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
    internal class ViewProductsPartnerVM : ViewModelBase
    {
        Partner _currentPartner;
        public Partner CurrentPartner { get => _currentPartner; set => this.RaiseAndSetIfChanged(ref _currentPartner, value); }
        
        List<ProductPartner> _listProductPartners;
        public List<ProductPartner> ListProductPartners { get => _listProductPartners; set => this.RaiseAndSetIfChanged(ref _listProductPartners, value); }

        public ViewProductsPartnerVM(int Id)
        {
            _currentPartner = MainWindowViewModel.myConnection.Partners
                .Include(x => x.IdPartnerTypeNavigation)
                .Include(x => x.ProductPartners).ThenInclude(x => x.IdProductNavigation).FirstOrDefault(x => x.IdPartner == Id);
            ListProductPartners = _currentPartner.ProductPartners.ToList();
        }

        public void ToPageViewPartner()
        {
            MainWindowViewModel.Instance.UC = new ViewPartners();
        }
    }
}
