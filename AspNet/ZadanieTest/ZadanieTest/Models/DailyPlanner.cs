using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadanieTest.Models
{
    public class Datebook   
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Запись")]
        public string Name { get; set; }

        [Display(Name = "Тема записи")]
        public string Tema { get; set; }

        [Display(Name = "Время начала")]
        public string TimeBegin { get; set; }

        [Display(Name = "Время окончания")]
        public string TimeEnd { get; set; }

        [Display(Name = "Адрес")]
        public string Adres { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; }
        
    }
    public class Tip
    {
        public Tip()
        {
            datebooks = new HashSet<Datebook>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Тип записи")]
        public string Name { get; set; }
        public ICollection<Datebook> datebooks { get; set; }
    }
}