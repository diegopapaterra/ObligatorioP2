using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public class Usuario
    {


        #region Atributos

        private string username;
        private string password;
        private string role;

        #endregion

        #region Propertys

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                username = value;
            }
        }

        public string DatosUsuario
        {
            get {
                return this.role + " - " + this.username;
            }
        }

        #endregion

        #region Constructor

        public Usuario(string username, string password, string role)
        {

            this.Username = username;
            this.password = password;
            this.role = role;

        }

        #endregion

        #region Métodos
        public string validarPassword(string password)
        {
            string resultado = "";
            if (this.password == password){
                resultado = this.role;
            }
            return resultado;
        }

        public void modificarUsuario(string password)
        {
            this.password = password;
           
        }


        #endregion



    }
}
