
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marble.WebReports.Models
{
    public class UIMenu
    {
        public UIMenu(string menuName)
        {
            this.menuName = menuName;
        }
        public UIMenu()
        {

        }

        private string menuName;

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        private string reportKey;

        public string ReportKey
        {
            get { return reportKey; }
            set { reportKey = value; }
        }
        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        public List<SubMenu> SubMenuList { get; set; } = null;
    }

    public class SubMenu
    {
        public SubMenu(string submenuName, bool isCustomReport, string reportKey)
        {
            this.submenuName = submenuName;
            this.isCustomReport = isCustomReport;
            this.reportKey = reportKey;


            if (isCustomReport)
            {
                href = "/" + "CustomReport?Report=" + reportKey;
            }
            else
            {
                href = "/" + reportKey;
            }

        }
        public SubMenu()
        {

        }
        private string submenuName;
        public string SubMenuName
        {
            get { return submenuName; }
            set { submenuName = value; }
        }

        private string reportKey;
        public string ReportKey
        {
            get { return reportKey; }
            set { reportKey = value; }
        }

        private bool isCustomReport;
        public bool IsCustomReport
        {
            get { return isCustomReport; }
            set { isCustomReport = value; }
        }

        private string href;
        public string Href
        {
            get { return href; }
            set { href = value; }
        }

        private string subclassName;

        public string SubClassName
        {
            get { return subclassName; }
            set { subclassName = value; }
        }

    }
}