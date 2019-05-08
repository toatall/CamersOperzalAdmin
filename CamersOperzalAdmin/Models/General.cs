using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamersOperzalAdmin.Models
{

    /// <summary>
    /// Описание представления о камере
    /// </summary>    
    [Table("camers_operzal_general")]
    public class General
    {
        
        private int _Id;
        /// <summary>
        /// Идентификатор камеры
        /// </summary>
        [Column("id"), Key(), Display(Name="ИД")]
        public int Id 
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
           
        private string _IfnsCode;
        /// <summary>
        /// Код ИФНС
        /// </summary>
        [Column("ifns_code"), Display(Name="Код инспекции"), Required()]
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
        
        private string _CameraImgLnk;
        /// <summary>
        /// Ссылка на изображение с камеры
        /// </summary>
        [Column("camera_img_link"), Display(Name="Ссылка на изображение"), Required()]
        public string CameraImgLink 
        { 
            get
            {
                return this._CameraImgLnk;
            }
            set
            {
                this._CameraImgLnk = value;
            }
        }
        
        private string _CameraImgFile;
        /// <summary>
        /// Путь для сохранения файла
        /// </summary>
        [Column("camera_img_file"), Display(Name="Ссылка на файл"), Required()]
        public string CameraImgFile
        {
            get
            {
                return this._CameraImgFile;
            }
            set
            {
                this._CameraImgFile = value;
            }
        }
                       
        private bool _CameraDisable;
        /// <summary>
        /// Призак отключения камеры (например, во время ремонта или монтажа)
        /// </summary>
        [Column("camera_disable"), Display(Name="Камера отключена")]
        public bool CameraDisable 
        { 
            get
            {
                return this._CameraDisable;
            }
            set
            {
                this._CameraDisable = value;
            }
        }

        /// <summary>
        /// Описание состояния отключения камеры (да/нет)
        /// </summary>       
        public string CameraDisableText
        {
            get
            {
                if (this._CameraDisable == true)
                {
                    return "Да";
                }
                return "Нет";
            }
        }
                
        private string _CameraDisableDescription;
        /// <summary>
        /// Сообщение в случае отключения камеры
        /// </summary>
        [Column("camera_disable_description"), Display(Name="Описание в случае отключения камеры")]
        public string CameraDisableDescription 
        { 
            get
            {
                return this._CameraDisableDescription;
            }
            set
            {
                this._CameraDisableDescription = value;
            }
        }
        
        private string _CameraAuthUser;
        /// <summary>
        /// Имя пользователя, в случае аутентефикации, для доступа к камере
        /// </summary>
        [Column("camera_user"), Display(Name="Имя пользователя камеры")]
        public string CameraAuthUser 
        { 
            get
            {
                return this._CameraAuthUser;
            }
            set
            {
                this._CameraAuthUser = value;
            }
        }
                       
        private string _CameraAuthPassword;
        /// <summary>
        /// Пароль пользователя, в случае аутентефикации, для доступа к камере
        /// </summary>
        [Column("camera_password"), Display(Name="Пароль камеры")]
        public string CameraAuthPassword 
        { 
            get
            {
                return this._CameraAuthPassword;
            }
            set
            {
                this._CameraAuthPassword = value;
            }
        }
        
        private Ifns _Ifns;
        /// <summary>
        /// Ссылка на Инспекцию, которой соответствует текущая камера
        /// </summary>
        [Association("_Ifns", "IfnsCode", "IfnsCode"), Display(Name="Инспекция")]
        public Ifns Ifns
        {
            get
            {
                return this._Ifns;
            }
            set
            {
                this._Ifns = value;
            }
        }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public General()
        {            
        }
    }
}