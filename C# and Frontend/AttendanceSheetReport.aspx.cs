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
using iTextSharp.text;
using iTextSharp.text.pdf;



public partial class AttendanceSheetReport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            DataTable dtbl = new DataTable();
            string query = @"SELECT s.RollNo, s.Fname, s.Lname, sa.AttendanceDate, sa.Status 
                            FROM Student s 
                            INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID 
                            INNER JOIN FACULTYSECTION fs ON ss.SectionID = fs.SectionID 
                            INNER JOIN Faculty f ON fs.FacultyID = f.FacultyID 
                            INNER JOIN StudentAttendance sa ON s.StudentID = sa.StudentID 
                            WHERE f.Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", Session["d1"]);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
        }
    }

    protected void PrintButton_Click(object sender, EventArgs e)
    {


        System.Web.UI.HtmlControls.HtmlGenericControl newDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

        // Creating a new GridView
        GridView newGridView = new GridView();
        newGridView.ID = "newGridView";
        newGridView.CssClass = "report-table";
        newGridView.AutoGenerateColumns = false;

        // Assign the columns from GridView1 to the new GridView
        foreach (DataControlField column in GridView1.Columns)
        {
            newGridView.Columns.Add(column);
        }

        // Add the new GridView to the new div
        newDiv.Controls.Add(newGridView);

        // Add the new div to the form1
        form1.Controls.Add(newDiv);

        Response.ContentType = "Application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=Result.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        form1.RenderControl(hw);  // Render the entire form instead of just the newDiv
        Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f);
        HTMLWorker htw = new HTMLWorker(doc);
        PdfWriter.GetInstance(doc, Response.OutputStream);
        doc.Open();
        StringReader sr = new StringReader(sw.ToString());
        htw.Parse(sr);
        doc.Close();
        Response.Write(doc);
        Response.End();

     

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for the specified ASP.NET
        // server control at run time.
    }

}