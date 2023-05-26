using System;
using System.Data;
using System.Data.SqlClient;
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

public partial class feedbackreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string facultyEmail = Session["d1"].ToString();
            BindFeedbackReport(facultyEmail);
        }
    }

    private void BindFeedbackReport(string facultyEmail)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sqlQuery = @"
            SELECT FF.FeedbackID, FF.StudentID, FF.RollNo, FF.CourseName, FF.FeedbackText,
                FF.TeacherArrivesOnTime, FF.TeachersPace, FF.TeacherEngagement, FF.TeacherDedication,
                FF.TeacherRespect, FF.TeacherAssignments, FF.TeacherRules, FF.TeacherResponsiveness
            FROM FacultyFeedback FF
            INNER JOIN Faculty F ON FF.FacultyID = F.FacultyID
            WHERE F.Email = @FacultyEmail";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                cmd.Parameters.AddWithValue("@FacultyEmail", facultyEmail);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    gvFeedbackReport.DataSource = dt;
                    gvFeedbackReport.DataBind();
                }
            }
        }
    }

    protected void ExportToPDF(object sender, EventArgs e)
    {
       
    }

    private byte[] ExportGridViewToPDF(GridView gridView)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                gridView.RenderControl(hw);
                string html = sw.ToString();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    HtmlConverter.ConvertToPdf(html, memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Required to avoid an exception when rendering the GridView
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType ="Application/pdf";
        Response.AddHeader("Content-Disposition","attachment; filename=Result.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        toprint.RenderControl(hw);
        Document doc = new Document(PageSize.A4,50f,50f,30f,30f);
        HTMLWorker htw = new HTMLWorker(doc);
        PdfWriter.GetInstance(doc, Response.OutputStream);
        doc.Open();
        StringReader sr = new StringReader(sw.ToString());
        htw.Parse(sr);
        doc.Close();
        Response.Write(doc);
        Response.End();

         
    }


}
