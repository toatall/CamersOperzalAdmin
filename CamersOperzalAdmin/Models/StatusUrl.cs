using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CamersOperzalAdmin.Models
{
    /// <summary>
    /// Проверка состояния url адреса (ping)
    /// </summary>
    public class StatusUrl
    {
        // url адрес
        private string _Url;
        private string _User;
        private string _Password;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Url">Ссылка для проверки состояния</param>
        /// <param name="User">Имя пользователя для аутентефикации</param>
        /// <param name="Password">Пароль пользователя для аутентефикации</param>
        public StatusUrl(string Url, string User = null, string Password = null)
        {
            this._Url = Url;
            this._User = User;
            this._Password = Password;
        }


        /// <summary>
        /// Проверка состояния адреса Url
        /// </summary>
        /// <returns>Результат проверки состояния ссылки Url (true|false)</returns>
        public bool Status()
        {
            try
            {
                HttpWebRequest Web = (HttpWebRequest)WebRequest.Create(this._Url);
                if (this._User != null && this._Password != null)
                {
                    NetworkCredential credentail = new NetworkCredential(this._User, this._Password);
                    Web.Credentials = credentail;
                }
                Web.Timeout = 1000;
                Web.AllowAutoRedirect = false;
                Web.Method = "HEAD";

                using (var responce = Web.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }           
        }


    }
}