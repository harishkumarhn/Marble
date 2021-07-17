using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marble.WebReports 
{
    public class Report
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string ReportKey { get; set; }
        public string OutputFormat { get; set; }
        public string DBQuery { get; set; }
        public string ReportGroup { get; set; }
        public bool IsActive { get; set; }
        public bool IsCustomReport { get; set; }
    }
}