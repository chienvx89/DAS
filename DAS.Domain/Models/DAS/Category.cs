using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAS.Domain.Models.DAS
{
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        public int IdCategoryType { get; set; }

        public int Status { get; set; } = 1;

        [Required]
        public int CreatedBy { get; set; } = 0;

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }
    }
}