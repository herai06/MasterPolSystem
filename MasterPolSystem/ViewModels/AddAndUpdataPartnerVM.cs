using Avalonia.Controls;
using MasterPolSystem.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPolSystem.ViewModels
{
    internal class AddAndUpdataPartnerVM : ViewModelBase
    {
        public AddAndUpdataPartnerVM()
        {
            _titlePage = "Добавление данных нового партнёра";
            _currentPartner = new Partner { IdPartnerTypeNavigation = new PartnerType() };
        }

        public AddAndUpdataPartnerVM(int Id)
        {
            _titlePage = "Редактирование данных о партнёре";
            _currentPartner = MainWindowViewModel.myConnection.Partners
                .Include(x => x.IdPartnerTypeNavigation)
                .Include(x => x.ProductPartners).ThenInclude(x => x.IdProductNavigation).FirstOrDefault(x => x.IdPartner == Id);
            ProductPartners = CurrentPartner.ProductPartners.ToList();
        }

        public void ToPageViewPartners()
        {
            MainWindowViewModel.Instance.UC = new ViewPartners();
        }

        string _titlePage;
        public string TitlePage { get => _titlePage; set => this.RaiseAndSetIfChanged(ref _titlePage, value); }

        Partner? _currentPartner;
        public Partner? CurrentPartner { get => _currentPartner; set => this.RaiseAndSetIfChanged(ref _currentPartner, value); }
        
        List<ProductPartner> _productPartners;
        public List<ProductPartner> ProductPartners { get => _productPartners; set => this.RaiseAndSetIfChanged(ref _productPartners, value); }

        public List<PartnerType> ListPartnerTypes => MainWindowViewModel.myConnection.PartnerTypes.ToList();

        public async void AddPartner(int Id)
        {
            if (CurrentPartner.Name == null || CurrentPartner.IdPartnerTypeNavigation.Name == null || CurrentPartner.DirectorFullName == null || CurrentPartner.Email == null || CurrentPartner.Phone == null || CurrentPartner.Inn == null || CurrentPartner.LegalAddress == null)
            {
                MessageBoxManager.GetMessageBoxStandard("Сообщение", "Заполните все поля!", ButtonEnum.Ok).ShowAsync();
            }
            else
            {
                if (CurrentPartner.IdPartner == 0)
                {
                    MainWindowViewModel.myConnection.Partners.Add(CurrentPartner);
                    MainWindowViewModel.myConnection.SaveChanges();
                    MainWindowViewModel.Instance.UC = new ViewPartners();
                    MessageBoxManager.GetMessageBoxStandard("Успех", "Партнёр зарегистрирован!", ButtonEnum.Ok).ShowAsync();
                }
                else
                {
                    MainWindowViewModel.myConnection.SaveChanges();
                    MainWindowViewModel.Instance.UC = new ViewPartners();
                    MessageBoxManager.GetMessageBoxStandard("Успех", "Изменённые данные сохранены!", ButtonEnum.Ok).ShowAsync();
                }
                
            }
        }



    }
}
