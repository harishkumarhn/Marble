using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.BusinessObject
{
    public class AppSetting
    {
        private string _caption;
        public string Caption {
            get { return string.IsNullOrWhiteSpace(this._caption) ? this.Name : this._caption; }
            set { _caption = value; }
        }
        public string Value { get; set; }
        public string Name { get; set; }
        public string ScreenGroup { get; set; }
        public string Type { get; set; }
    }
    public class Buttons
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string Tittle { get; set; }
        public string MethodName { get; set; }
        public string Text { get; set; }

    }
}
