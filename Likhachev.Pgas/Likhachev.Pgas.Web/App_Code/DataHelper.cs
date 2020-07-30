using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Likhachev.Pgas.Web.App_Code
{
    public static class DataHelper
    {
        public static HtmlString CreateDataTable(this IHtmlHelper html, DataTable dt)
        {
            string result = "<table id=\"data-table\" class=\"table table-bordered table-responsive-md table-striped text-center\"><tr>";

            foreach (DataColumn col in dt.Columns)
                result = $"{result}<td><b>{col.ColumnName}</b></td>";

            result = $"{result}<td><b>Check</b></td><td><b>Edit</b></td><td><b>Delete</b></td></tr>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result = $"{result}<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    result = $"{result}<td class=\"pt-3-half\">{dt.Rows[i][j]}</td>";

                result = $"{result}<td><input style=\"margin:auto\" type=\"checkbox\" class=\"form-check-input\"></td>";
                result = $"{result}<td><button asp-action=\"Edit\" asp-controller=\"Activity\"" +
                    $"type=\"button\" class=\"btn btn-primary btn-rounded\">Изменить</button></td>";
                result = $"{result}<td><button type=\"button\" class=\"btn btn-danger btn-rounded\">X</button></td></tr>";
            }

            result = $"{result}</table>";
            return new HtmlString(result);
        }

        public static HtmlString CreateExpertDataTable(this IHtmlHelper html, DataTable dt)
        {
            string result = "<table id=\"data-table\" class=\"table table-bordered table-responsive-md table-striped text-center\"><thead><tr>";

            foreach (DataColumn col in dt.Columns)
                result = $"{result}<td>{col.ColumnName}</td>";

            result = $"{result}<td>Edit</td></tr></thead>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result = $"{result}<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    result = $"{result}<td>{dt.Rows[i][j]}</td>";

                result = $"{result}<td><button type=\"button\" asp-action=\"Edit\" asp-controller=\"Expert\"" +
                    $"class=\"btn btn-primary btn-rounded btn-sm my-0\">Изменить</button></td></tr>";
            }

            result = $"{result}</table>";
            return new HtmlString(result);
        }
    }
}
