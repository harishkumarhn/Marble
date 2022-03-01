using Marbale.BusinessObject.SiteSetup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marble.Business
{
    public class PrinterBL
    {
        SiteSetupBL siteSetup = new SiteSetupBL();
        
        public string GetHTMLPreview(int headerId)
        {
            var previewItems = siteSetup.GetPrintTemplates(headerId);
            List<string> sections = new List<string>();
            foreach (var item in previewItems)
            {
                if (!sections.Any(x => x.ToLower() == item.Section.ToLower()))
                {
                    sections.Add(item.Section);
                }
            }
            string tableBody = "";

            foreach (var section in sections)
            {
                var rowsBySection = previewItems.Where(x => x.Section == section.ToString()).OrderBy(o => o.Sequence).ToList();
               // int productRowCount = previewItems.Where(x => x.Section.ToLower() == "product").OrderBy(o => o.Sequence).ToList().Count;
               // int totalRowCount = previewItems.Where(x => x.Section.ToLower() == "total").OrderBy(o => o.Sequence).ToList().Count;

                foreach (var row in rowsBySection)
                {
                    string style = "";
                    switch (row.Section.ToLower())
                    {
                        case "header":
                            this.GetTableBodyRow(ref tableBody, row, ref style);
                            break;
                        case "product":
                            tableBody = tableBody + "<tr>";
                            if (!string.IsNullOrWhiteSpace(row.Col1Data))
                            {
                                style = GetStyle(row, 1);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:40%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col1Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col2Data))
                            {
                                style = GetStyle(row, 2);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col2Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col3Data))
                            {
                                style = GetStyle(row, 3);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col3Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col4Data))
                            {
                                style = GetStyle(row, 4);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col4Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col5Data))
                            {
                                style = GetStyle(row, 5);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col5Data + "</td>";
                            }
                            tableBody = tableBody + "</tr>";
                            //productRowCount--;
                            //if (productRowCount <= 0)
                            //{
                            //    tableBody = "<table width='100%'>" + tableBody + "</table>";
                            //}
                            break;
                        case "total":
                            tableBody = tableBody + "<tr>";
                            if (!string.IsNullOrWhiteSpace(row.Col1Data))
                            {
                                style = GetStyle(row, 1);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:40%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col1Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col2Data))
                            {
                                style = GetStyle(row, 2);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col2Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col3Data))
                            {
                                style = GetStyle(row, 3);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col3Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col4Data))
                            {
                                style = GetStyle(row, 4);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col4Data + "</td>";
                            }
                            if (!string.IsNullOrWhiteSpace(row.Col5Data))
                            {
                                style = GetStyle(row, 5);
                                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                                tableBody = tableBody + "<td " + style + ">" + row.Col5Data + "</td>";
                            }
                            tableBody = tableBody + "</tr>";
                            //totalRowCount--;                            
                            break;
                        case "footer":
                            this.GetTableBodyRow(ref tableBody, row, ref style);
                            //GetHeaderOrFooter(ref printHTML, row, ref style);
                            break;
                        default:
                            break;
                    }
                }
                
            }
            //if (!string.IsNullOrWhiteSpace(printHTML)) { printHTML = "<div style=''>" + printHTML + "</div>"; }

            // printHTML = printHTML + this.BasicStyle();
            string html = "<table width='100%'>" + tableBody + "</table>" + this.BasicStyle();

            return html;
        }

        private void GetTableBodyRow(ref string printHTML, ReceiptPrintTemplate row, ref string style)
        {
            int colCount = 0;
            if (!string.IsNullOrWhiteSpace(row.Col1Data)) colCount++;
            if (!string.IsNullOrWhiteSpace(row.Col2Data)) colCount++;
            if (!string.IsNullOrWhiteSpace(row.Col3Data)) colCount++;
            if (!string.IsNullOrWhiteSpace(row.Col4Data)) colCount++;
            if (!string.IsNullOrWhiteSpace(row.Col5Data)) colCount++;

            string width = (100 / colCount) + "%";

            string tableBody = "<tr>";
            if (!string.IsNullOrWhiteSpace(row.Col1Data))
            {
                style = GetStyle(row, 1);
                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:"+ width + ";'";
                tableBody = tableBody + "<td " + style + ">" + row.Col1Data + "</td>";
            }
            if (!string.IsNullOrWhiteSpace(row.Col2Data))
            {
                style = GetStyle(row, 2);
                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:" + width + ";'";
                tableBody = tableBody + "<td " + style + ">" + row.Col2Data + "</td>";
            }
            if (!string.IsNullOrWhiteSpace(row.Col3Data))
            {
                style = GetStyle(row, 3);
                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:" + width + ";'";
                tableBody = tableBody + "<td " + style + ">" + row.Col3Data + "</td>";
            }
            if (!string.IsNullOrWhiteSpace(row.Col4Data))
            {
                style = GetStyle(row, 4);
                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:" + width + ";'";
                tableBody = tableBody + "<td " + style + ">" + row.Col4Data + "</td>";
            }
            if (!string.IsNullOrWhiteSpace(row.Col5Data))
            {
                style = GetStyle(row, 5);
                if (!string.IsNullOrWhiteSpace(style)) style = "style='" + style + "width:20%;'";
                tableBody = tableBody + "<td " + style + ">" + row.Col5Data + "</td>";
            }
            printHTML = tableBody + "</tr>";
        }
       

        private string GetStyle(ReceiptPrintTemplate template, int columnNumber)
        {
            string style = "";
            switch (columnNumber)
            {
                case 1:
                    if (!string.IsNullOrWhiteSpace(template.Col1Alignment))
                    {
                        style = style + getAlignmentOrVisiblity(template.Col1Alignment) + ";";
                    }
                    break;
                case 2:
                    if (!string.IsNullOrWhiteSpace(template.Col2Alignment))
                    {
                        style = style + getAlignmentOrVisiblity(template.Col2Alignment) + ";";
                    }
                    break;
                case 3:
                    if (!string.IsNullOrWhiteSpace(template.Col3Alignment))
                    {
                        style = style + getAlignmentOrVisiblity(template.Col3Alignment) + ";";
                    }
                    break;
                case 4:
                    if (!string.IsNullOrWhiteSpace(template.Col4Alignment))
                    {
                        style = style + getAlignmentOrVisiblity(template.Col4Alignment) + ";";
                    }
                    break;
                case 5:
                    if (!string.IsNullOrWhiteSpace(template.Col5Alignment))
                    {
                        style = style + getAlignmentOrVisiblity(template.Col5Alignment) + ";";
                    }
                    break;
                default: break;

            }
            if (!string.IsNullOrWhiteSpace(template.FontName))
            {
                style = style + "font-family:" + template.FontName + ";";
            }
            if (template.FontSize > 0)
            {
                style = style + "font-size:" + template.FontSize.ToString() + ";";
            }
            return style;
        }
        private string getAlignmentOrVisiblity(string alignment)
        {
            string value;
            switch (alignment.ToLower())
            {
                case "l": value = "text-align:left"; break;
                case "c": value = "text-align:center"; break;
                case "r": value = "text-align:right"; break;
                case "h": value = "visibility:hidden;"; break;
                default: value = ""; break;
            }
            return value;
        }

        private string BasicStyle()
        {
            string style = "<style>table td {}</style>";
            return style;
        }
    }
}
