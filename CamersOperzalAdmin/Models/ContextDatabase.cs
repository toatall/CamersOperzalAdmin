using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Entity;


namespace CamersOperzalAdmin.Models
{
    /// <summary>
    /// Контекст
    /// </summary>
    public class ContextDatabase : DbContext
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        public ContextDatabase()
            : base("SERVICESConnectionString")
        {
        }

        /// <summary>
        /// Данные из таблицы camers_operzal_general
        /// с информацией о камерах
        /// </summary>
        public virtual DbSet<General> TGeneral { get; set; }

        /// <summary>
        /// Данные из таблицы camers_operzal_ifns
        /// с информацией о Инспекциях
        /// </summary>
        public virtual DbSet<Ifns> TIfns { get; set; }

        /// <summary>
        /// Данные из таблицы camers_operzal_configuration
        /// с настройками ПО
        /// </summary>
        public virtual DbSet<Configuration> TConfiguration { get; set; }       

    }
}