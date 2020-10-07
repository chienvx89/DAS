using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS.Application.Models.ViewModels
{
    public class VMCreateCategory
    {
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        [Required]
        public int IdCategoryType { get; set; }

        //public string Description { get; set; }
    }
}