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
using iText.Html2pdf;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class GradeReport : System.Web.UI.Page
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
            SELECT 
                s.RollNo, s.Fname, s.Lname, sm.Assignment, sm.Quiz, sm.Sessional_I, sm.Sessional_II, sm.Project, sm.Final 
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
                f.Email = @FacultyEmail";

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

    protected string CalculateGrade(int total)
    {
        if (total > 90)
            return "+A";
        else if (total >= 86)
            return "A";
        else if (total >= 82)
            return "-A";
        else if (total >= 78)
            return "+B";
        else if (total >= 74)
            return "B";
        else if (total >= 70)
            return "-B";
        else if (total >= 66)
            return "+C";
        else if (total >= 62)
            return "C";
        else if (total >= 58)
            return "-C";
        else if (total >= 54)
            return "+D";
        else if (total >= 50)
            return "D";
        else
            return "F";
    }

    protected void btnPrint_Click(object sender, EventArgs e)
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