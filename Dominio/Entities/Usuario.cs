
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public Usuario(string nome,string email,string password ) { 

            Nome = nome;
            Email = email;
            Password = password;

        }


      
    }
}
