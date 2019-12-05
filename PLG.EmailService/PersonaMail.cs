using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PLG.EmailService
{
    /// <summary>
    /// Persona Mail es una Clase que representa la direccion de correo electronico 
    /// </summary>
    public class PersonaMail
    {
        private string _nombre;
        private string _email;
        /// <summary>
        ///     Instancia de la Clase usando un nombre y email específico
        /// </summary>
        /// <param name="nombre">
        ///     Nombre asociado con el email.
        /// </param>
        /// <param name="email">
        ///     Email al que se enviará el correo
        /// </param>
        public PersonaMail(string nombre, string email)
        {
            this.Nombre = nombre;
            this.Email = email;
        }
        /// <summary>
        /// Instancia de la Clases usando el email. 
        /// Por defecto el nombre queda en Blanco.
        /// </summary>
        /// <param name="email">
        ///     Email al que se enviará el correo
        /// </param>
        public PersonaMail(string email)
        {
            this.Nombre = string.Empty;
            this.Email = email;
        }
        /// <summary>
        ///     Obtiene el Nombre para mostrar.
        /// </summary>
        public string Nombre { 
            get { 
                return _nombre; 
            }
            set {
                _nombre = value;
            } 
        }
        /// <summary>
        ///     Obtiene el Email para mostrar.
        /// </summary>
        public string Email {
            get {
                return _email;
            }
            set
            {
                // Valido que el email no este en blanco.
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email no puede estar vacio");
                }else if (!this.IsEmailValido(value))
                {
                    throw new FormatException("El Email ingresado es invalido");
                }
                else
                {
                    _email = value;
                }
            }
        }
        /// <summary>
        ///     Metodo que valida que el email ingresado sea uno válido
        /// </summary>
        /// <param name="email">
        ///     Email que se va ha validar
        /// </param>
        /// <returns>
        ///     Retorna un Booleano. 
        ///     Valor True si el Email es válido
        /// </returns>
        private Boolean IsEmailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
