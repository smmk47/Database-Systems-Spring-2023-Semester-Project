using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Web.UI.HtmlControls;


using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualStudio.OLE.Interop;

public partial class CountGradesReport : System.Web.UI.Page
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
        string facultyEmail = Session["d1"].ToString();

        string query = @"
            WITH GradeTotals AS (
                SELECT
                    s.StudentID,
                    sm.Assignment + sm.Quiz + sm.Sessional_I + sm.Sessional_II + sm.Project + sm.Final AS Total
                FROM
                    Student s
                INNER JOIN
                    StudentSection ss ON s.StudentID = ss.StudentID
                INNER JOIN
                    StudentMarks sm ON s.StudentID = sm.StudentID
                INNER JOIN
                    FACULTYSECTION fs ON fs.SectionID = ss.SectionID
                INNER JOIN
                    Faculty f ON f.FacultyID = fs.FacultyID
                WHERE
                    f.Email = @FacultyEmail
            ),
            GradeCounts AS (
                SELECT
                    CASE
                        WHEN Total > 90 THEN '+A'
                        WHEN Total BETWEEN 86 AND 89 THEN 'A'
                        WHEN Total BETWEEN 82 AND 85 THEN '-A'
                        WHEN Total BETWEEN 78 AND 81 THEN '+B'
                        WHEN Total BETWEEN 74 AND 77 THEN 'B'
                        WHEN Total BETWEEN 70 AND 73 THEN '-B'
                        WHEN Total BETWEEN 66 AND 69 THEN '+C'
                        WHEN Total BETWEEN 62 AND 65 THEN 'C'
                        WHEN Total BETWEEN 58 AND 61 THEN '-C'
                        WHEN Total BETWEEN 54 AND 57 THEN '+D'
                        WHEN Total BETWEEN 50 AND 53 THEN 'D'
                        ELSE 'F'
                    END AS Grade
                FROM
                    GradeTotals
            )
            SELECT Grade, COUNT(*) AS Count
            FROM GradeCounts
            GROUP BY Grade
            ORDER BY Grade";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FacultyEmail", facultyEmail);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();






                }
            }
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {

        string facultyEmail = Session["d1"].ToString();

        string query = @"
            WITH GradeTotals AS (
                SELECT
                    s.StudentID,
                    sm.Assignment + sm.Quiz + sm.Sessional_I + sm.Sessional_II + sm.Project + sm.Final AS Total
                FROM
                    Student s
                INNER JOIN
                    StudentSection ss ON s.StudentID = ss.StudentID
                INNER JOIN
                    StudentMarks sm ON s.StudentID = sm.StudentID
                INNER JOIN
                    FACULTYSECTION fs ON fs.SectionID = ss.SectionID
                INNER JOIN
                    Faculty f ON f.FacultyID = fs.FacultyID
                WHERE
                    f.Email = @FacultyEmail
            ),
            GradeCounts AS (
                SELECT
                    CASE
                        WHEN Total > 90 THEN '+A'
                        WHEN Total BETWEEN 86 AND 89 THEN 'A'
                        WHEN Total BETWEEN 82 AND 85 THEN '-A'
                        WHEN Total BETWEEN 78 AND 81 THEN '+B'
                        WHEN Total BETWEEN 74 AND 77 THEN 'B'
                        WHEN Total BETWEEN 70 AND 73 THEN '-B'
                        WHEN Total BETWEEN 66 AND 69 THEN '+C'
                        WHEN Total BETWEEN 62 AND 65 THEN 'C'
                        WHEN Total BETWEEN 58 AND 61 THEN '-C'
                        WHEN Total BETWEEN 54 AND 57 THEN '+D'
                        WHEN Total BETWEEN 50 AND 53 THEN 'D'
                        ELSE 'F'
                    END AS Grade
                FROM
                    GradeTotals
            )
            SELECT Grade, COUNT(*) AS Count
            FROM GradeCounts
            GROUP BY Grade
            ORDER BY Grade";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FacultyEmail", facultyEmail);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                    HtmlGenericControl div9 = new HtmlGenericControl("div");
                    div9.Attributes["id"] = "div9";
                    div9.Attributes["class"] = "grid-container";
                    div9.Controls.Add(GridView1);

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


                    Response.Redirect("facultyreports.aspx");



                }
            }
        }

    }
}