
using Decrypt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Decrypt.Controllers
{
    public class DecryptController : ApiController
    {
        [Route("api/Decrypt/{login},{senha}")]
        public User Get(string login, string senha)
        {
            var user = new User();
            login = login.Replace("{sls}", "/");
            senha = senha.Replace("{sls}", "/");
            login = login.Replace("{qstm}", "?");
            senha = senha.Replace("{qstm}", "?");
            login = login.Replace("{pls}", "+");
            senha = senha.Replace("{pls}", "+");
            user.Login = Criptografia.Criptografia.Descriptografar(login);
            user.Senha = Criptografia.Criptografia.Descriptografar(senha);
            //user.Key = Criptografia.Criptografia.Criptografar(login) + "//" + Criptografia.Criptografia.Criptografar(senha);
            return user;
        }
    }
}
