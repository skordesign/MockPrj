using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MockPrj.Models;
using MockPrj.Repositories;

namespace MockPrj.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Pwd { get; set; }
        public string PwdRt { get; set; }
    }
}