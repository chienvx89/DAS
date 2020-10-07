using DAS.Domain.Models.DAS;
using DAS.Infrastructure.Contexts;
using System.Collections.Generic;

namespace DAS.MockData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InsertCategoryType();
        }

        private static void InsertCategoryType()
        {
            var ct = new DASContext();
            var data = new List<CategoryType>() {
                  new CategoryType(){ Name = "DM1"},
                      new CategoryType(){ Name = "DM2"},
                          new CategoryType(){ Name = "DM3"},
                              new CategoryType(){ Name = "DM4"},
            };
            ct.CategoryType.AddRange(data);
            ct.SaveChanges();
        }
    }
}