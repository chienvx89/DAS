using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAS.Domain.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; }

        public int Status { get; set; } = 1;

        [Required]
        public long CreatedBy { get; set; } = 0;

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        public DateTime? UpdatedDate { get; set; }

        public long? UpdatedBy { get; set; }
    }
}