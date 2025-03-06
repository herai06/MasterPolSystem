using Avalonia;
using MasterPolSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterPolSystem.Models;

public partial class Partner
{

    public string Discount
    {
        get
        {
            double? sum = 0;
            int answer = 0;
            List<ProductPartner> productPartners = MainWindowViewModel.myConnection.ProductPartners.ToList();
            foreach (ProductPartner recotd in productPartners)
            {
                if (IdPartner == recotd.IdPartner)
                {
                    sum += recotd.ProductQuantity;
                }
            }
            
            if (sum > 10000 && sum < 50000) answer = 5;
            else if (sum > 50000 && sum < 300000) answer = 10;
            else if (sum > 300000) answer = 15;

            return answer.ToString() + "%";
        }
    }
}
