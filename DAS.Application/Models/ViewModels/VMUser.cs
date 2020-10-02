using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Application.Models.ViewModels
{
    public class VMUser
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Description { get; set; }

        public int Status { get; set; } = 1;

        public long CreatedBy { get; set; } = 0;

        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        public DateTime? UpdatedDate { get; set; }

        public long? UpdatedBy { get; set; }
    }
}