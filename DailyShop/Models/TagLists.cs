using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Models
{
    public class TagLists
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag List")]
        public string TagList { get; set; }
    }
}
