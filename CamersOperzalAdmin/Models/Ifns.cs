using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CamersOperzalAdmin.Models
{
    /// <summary>
    /// Описание Инспекции
    /// </summary>
    [Table("camers_operzal_ifns")]
    public class Ifns
    {
                
        private string _IfnsCode;
        /// <summary>
        /// Код Инспекции
        /// </summary>
        [Column("ifns_cod"), Key(), MinLength(4), MaxLength(4), Display(Name = "Код инспекции"), Required]
        public string IfnsCode 
        {
            get 
            {
                return this._IfnsCode;
            }
            set
            {
                this._IfnsCode = value;
            }        
        }
        
        private string _IfnsName;
        /// <summary>
        /// Наименование Инспекции
        /// </summary>
        [Column("ifns_name"), Required, Display(Name = "Наименование инспекции")]
        public string IfnsName 
        {
            get 
            {
                return this._IfnsName;
            }
            set
            {
                this._IfnsName = value;
            }
        }
        
        private int _Order;
        /// <summary>
        /// Порядок сортировки
        /// </summary>
        [Column("order"), Display(Name = "Сортировка")]
        public int Order 
        {
            get
            {
                return this._Order;
            }
            set
            {
                this._Order = value;
            }
        }

        
        private ICollection<General> _Generals;
        /// <summary>
        /// Камеры текущей Инспекции
        /// </summary>
        [Association("_Generals", "IfnsCode", "IfnsCode")]
        public ICollection<General> Generals
        {
            get
            {
                return this._Generals;
            }
            set
            {
                this._Generals = value;
            }
        }


        /// <summary>
        /// Приведение текущих камер от EntitySet к IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<General> NumerableGeneral()
        {
            return this.Generals;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Ifns()
        {
            this._Generals = new HashSet<General>();
        }
        
    }
}