using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using Microsoft.VisualStudio.OLE.Interop;
using System.IO;

using iText.Html2pdf;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;

public partial class logreport : System.Web.UI.Page
{

    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM AuditLog", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                AuditLogGridView.DataSource = dataTable;
                AuditLogGridView.DataBind();
            }
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {





        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM AuditLog", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                AuditLogGridView.DataSource = dataTable;
                AuditLogGridView.DataBind();


           

                GridView newGridView = new GridView();
                newGridView.DataSource = dataTable;
                newGridView.DataBind();

                HtmlGenericControl div7 = new HtmlGenericControl("div");
                div7.Controls.Add(newGridView);

                Response.ContentType ="Application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Result.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div7.RenderControl(hw);
                Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f);
                HTMLWorker htw = new HTMLWorker(doc);
                PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();
                StringReader sr = new StringReader(sw.ToString());
                htw.Parse(sr);
                doc.Close();
                Response.Write(doc);


                Response.End();

                Response.Redirect("genratereports.aspx");


            }
        }




       


    }

}