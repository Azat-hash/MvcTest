using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTestProject.Models
{
    /// <summary>
    /// Сущност "Автор"
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name ="Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name ="Имя")]
        [Required(ErrorMessage ="Поле является обязательным")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string LastName { get; set; }

        /// <summary>
        /// Ссылка на класс
        /// </summary>
        public ICollection<Post> Posts { get; set; }
    }
}