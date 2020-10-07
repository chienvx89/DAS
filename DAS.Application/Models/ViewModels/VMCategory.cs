﻿using DAS.Application.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DAS.Application.Models.ViewModels
{
    public class VMCategory
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int IdCategoryType { get; set; }

        public int Status { get; set; }

        //public int CreatedBy { get; set; }

        //public DateTime CreateDate { get; set; }

        //public DateTime? UpdatedDate { get; set; }

        //public int? UpdatedBy { get; set; }
    }
}