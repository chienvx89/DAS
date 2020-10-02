using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS.Application.Models.ViewModels
{
    public class VMCreateUser
    {
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
