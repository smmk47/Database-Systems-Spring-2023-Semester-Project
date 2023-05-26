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

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;

public partial class courseofferreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCourses();

           // printreport();
        }


    }

    private void BindCourses()
    {
        string query = @"
            SELECT
                c.CourseID,
                c.CourseName,
                c.CreditHours,
                c.MaxEnrollement,
                c.PreReq,
                cs.SemesterID
            FROM
                Course c
            INNER JOIN
                CourseSemester cs ON c.CourseID = cs.CourseID;
        ";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridView2.DataSource = dataTable;
            GridView2.DataBind();
        }
    }

    public void printreport()
    {
       


    }


    protected void btnExport_Click(object sender, EventArgs e)
    {


        string query = @"
            SELECT
                c.CourseID,
                c.CourseName,
                c.CreditHours,
                c.MaxEnrollement,
                c.PreReq,
                cs.SemesterID
            FROM
                Course c
            INNER JOIN
                CourseSemester cs ON c.CourseID = cs.CourseID;
        ";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridView2.DataSource = dataTable;
            GridView2.DataBind();

            // Create a new GridView that is equal to GridView2
            GridView anotherGridView = new GridView();
            anotherGridView.DataSource = dataTable;  // We use the same data table as GridView2
            anotherGridView.DataBind();

            // Create a new div
            HtmlGenericControl div9 = new HtmlGenericControl("div");
            div9.Attributes["id"] = "div9";  // Give it an id
            div9.Controls.Add(anotherGridView);  // Add the new GridView into div9

            // Add the new div into the page

            Response.ContentType ="Application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Result.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            div9.RenderControl(hw);
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