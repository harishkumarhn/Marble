using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marbale.Reports.Models
{
    public class ReportMenuViewModel
    {
        public string Name { get; set; }
        public Column1 Column1 { get; set; }
        public Column2 Column2 { get; set; }
    }
    public class Column1
    {
        public string DisplayName { get; set; }
        public string URL { get; set; }
    }
    public class Column2
    {
        public string DisplayName { get; set; }
        public string URL { get; set; }
    }
}