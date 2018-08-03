using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decrypt.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Key { get; set; }
    }
}