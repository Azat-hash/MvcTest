using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTestProject.Models
{
    /// <summary>
    /// Сущность "Категория"
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентикатор
        /// </summary>
        [Display(Name ="Идентикатор")]
        public int Id { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name ="Название")]
        [Required(ErrorMessage ="Поле является обязательным")]
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на класс
        /// </summary>
        public ICollection<Post> Posts { get; set; }
    }
}