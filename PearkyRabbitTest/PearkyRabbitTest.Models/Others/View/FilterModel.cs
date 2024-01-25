using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Others.View
{
    public class FilterModel
    {
        public int First { get; set; }
        [Range(1, Int32.MaxValue)]
        public int Rows { get; set; }
        public string? SortField { get; set; }
        public int? SortOrder { get; set; }
        public string? GlobalFilter { get; set; }
    }
}
