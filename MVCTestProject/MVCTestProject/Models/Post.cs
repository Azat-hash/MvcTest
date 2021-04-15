using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTestProject.Models
{
    /// <summary>
    /// Сущность "Пост"
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name ="Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Название поста
        /// </summary>
        [Display(Name ="Название поста")]
        [Required(ErrorMessage ="Поле является обязательным")]
        public string Name { get; set; }

        /// <summary>
        /// Содержание поста
        /// </summary>
        [Display(Name = "Содержание поста")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string PostContent { get; set; }

        /// <summary>
        /// Название картинки
        /// </summary>
        [Display(Name = "Название картинки")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string ImageName { get; set; } 

        /// <summary>
        /// Картинка в байтах
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Идентификатор автора
        /// </summary>
        [Display(Name = "Идентификатор автора")]
        public int? AuthorId { get; set; }

        /// <summary>
        /// Тематика
        /// </summary>
        [Display(Name ="Тематика")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Ссылка на класс
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Ссылка на класс
        /// </summary>
        public Category Category { get; set; }
    }
}