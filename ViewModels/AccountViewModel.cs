using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MockPrj.Models;
using MockPrj.Repositories;

namespace MockPrj.ViewModels
{
    public class AccountViewModel : Account
    {
        public string RoleName { get; set; }
    }
}