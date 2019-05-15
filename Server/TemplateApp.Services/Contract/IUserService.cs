using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models;

namespace TemplateApp.Services.Contract
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
