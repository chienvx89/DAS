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

        public int Status { get; set; } = 1;

        [Required]
        public long CreatedBy { get; set; } = 0;

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        public DateTime? UpdatedDate { get; set; }

        public long? UpdatedBy { get; set; }
    }
}