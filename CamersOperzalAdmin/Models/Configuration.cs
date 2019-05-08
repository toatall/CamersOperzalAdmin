using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CamersOperzalAdmin.Models
{
    /// <summary>
    /// Описание конфигурации приложения
    /// </summary>
    [Table("camers_operzal_configuration")]
    public class Configuration
    {
        
        private string _Id;
        /// <summary>
        /// Идентификатор записи (ключ)
        /// </summary>
        [Column("config_id"), Key()]
        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }
        
        private string _Value;
        /// <summary>
        /// Значение параметра
        /// </summary>
        [Column("config_value"), Required()]
        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
        
        private string _Description;
        /// <summary>
        /// Описание
        /// </summary>
        [Column("config_description")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }




    }
}