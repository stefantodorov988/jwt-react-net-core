using System;
using System.Collections.Generic;
using System.Text;
using TemplateApp.Data.Models.Base;

namespace TemplateApp.Data.Models
{
    public class UniqueClick : Entity
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public int IpAdressId { get; set; }

        public IpAdress IpAdress { get; set; }

        public int ClickCounter { get; set; }
    }
}
