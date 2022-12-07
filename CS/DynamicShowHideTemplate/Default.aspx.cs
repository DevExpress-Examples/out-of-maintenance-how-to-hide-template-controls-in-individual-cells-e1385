using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DynamicShowHideTemplate {
    public partial class _Default : System.Web.UI.Page {
        private DataTable CreateGridData() {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("Status", typeof(string));
            table.Rows.Add(1, "im");
            table.Rows.Add(2, "fr");
            return table;
        }
        protected void Page_Init(object sender, EventArgs e) {
            gvTrackingNumbers.DataSource = CreateGridData();
        }
        protected void Page_Load(object sender, EventArgs e) {
            gvTrackingNumbers.DataBind();
        }

        // hide custom command button
        protected void gvTrackingNumbers_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableCommandCellEventArgs e) {
            if(e.CommandCellType == DevExpress.Web.GridViewTableCommandCellType.Data
                && e.CommandColumn.Name == "colManage") {
                bool isVisible = GetManageButtonVisible(e.VisibleIndex);
                e.Cell.Controls[0].Visible = isVisible;
            }
        }

        // hide template controls
        protected bool GetIssueLinkVisible(int rowVisibleIndex) {
            string status = GetStatus(rowVisibleIndex);
            if(status.Contains("i")) // some logic for visibility calculation
                return true;
            else
                return false;
        }
        protected bool GetReturnLinkVisible(int rowVisibleIndex) {
            string status = GetStatus(rowVisibleIndex);
            if(status.Contains("r"))
                return true;
            else
                return false;
        }
        protected bool GetManageButtonVisible(int rowVisibleIndex) {
            string status = GetStatus(rowVisibleIndex);
            if(status.Contains("m"))
                return true;
            else
                return false;
        }

        // get cell value
        private string GetStatus(int rowVisibleIndex) {
            DataRow row = gvTrackingNumbers.GetDataRow(rowVisibleIndex);
            return (string)row["Status"];
        }
    }
}
