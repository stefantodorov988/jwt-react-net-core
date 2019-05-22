using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models.Base;

namespace TemplateApp.Data.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
