using Decrypt.Criptografia;
using Decrypt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Encrypt.Controllers
{
    public class EncryptController : ApiController
    {
        [Route("api/Encrypt/{login},{senha}")]
        public User Get(string login, string senha)
        {
            var user = new User();
            user.Login = Criptografia.Criptografar(login);
            user.Senha = Criptografia.Criptografar(senha);
            user.Login = user.Login.Replace("/", "{sls}");
            user.Senha = user.Senha.Replace("/", "{sls}");
            user.Login = user.Login.Replace("?", "{qstm}");
            user.Senha = user.Senha.Replace("?", "{qstm}");
            user.Login = user.Login.Replace("+", "{pls}");
            user.Senha = user.Senha.Replace("+", "{pls}");
            user.Key = user.Login + "||" + user.Senha;
            return user;
        }
    }
}
