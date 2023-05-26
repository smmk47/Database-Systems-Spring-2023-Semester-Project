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
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;

public partial class studentsectionreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudentList();
        }

    }

    private void LoadStudentList()
    {

        string specificSectionId = "1"; // Replace with the desired section ID

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Fetch section information
            string sectionQuery = "SELECT SectionID FROM SectionCourse WHERE SectionID = @sectionId";
            SqlCommand sectionCommand = new SqlCommand(sectionQuery, connection);
            sectionCommand.Parameters.AddWithValue("@sectionId", specificSectionId);
            SqlDataReader sectionReader = sectionCommand.ExecuteReader();

            if (sectionReader.Read())
            {
                SectionLabel.Text += sectionReader["SectionID"].ToString();
            }
            sectionReader.Close();

            // Fetch student list
            string query = @"
                    SELECT s.RollNo, s.Fname + ' ' + s.Lname AS Name
                    FROM Student s
                    INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID
                    WHERE ss.SectionID = @sectionId
                    ORDER BY s.RollNo ASC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@sectionId", specificSectionId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            StudentListGridView.DataSource = dataTable;
            StudentListGridView.DataBind();





        }

       
    }

    private void printdata()
    {

        string specificSectionId = "1"; // Replace with the desired section ID

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Fetch section information
            string sectionQuery = "SELECT SectionID FROM SectionCourse WHERE SectionID = @sectionId";
            SqlCommand sectionCommand = new SqlCommand(sectionQuery, connection);
            sectionCommand.Parameters.AddWithValue("@sectionId", specificSectionId);
            SqlDataReader sectionReader = sectionCommand.ExecuteReader();

            if (sectionReader.Read())
            {
                SectionLabel.Text += sectionReader["SectionID"].ToString();
            }
            sectionReader.Close();

            // Fetch student list
            string query = @"
                    SELECT s.RollNo, s.Fname + ' ' + s.Lname AS Name
                    FROM Student s
                    INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID
                    WHERE ss.SectionID = @sectionId
                    ORDER BY s.RollNo ASC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@sectionId", specificSectionId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            StudentListGridView.DataSource = dataTable;
            StudentListGridView.DataBind();






            GridView anotherStudentListGridView = new GridView();
            anotherStudentListGridView.AutoGenerateColumns = false;

            BoundField rollNoField = new BoundField();
            rollNoField.DataField = "RollNo";
            rollNoField.HeaderText = "Roll No";

            BoundField nameField = new BoundField();
            nameField.DataField = "Name";
            nameField.HeaderText = "Name";

            anotherStudentListGridView.Columns.Add(rollNoField);
            anotherStudentListGridView.Columns.Add(nameField);

            anotherStudentListGridView.DataSource = dataTable;
            anotherStudentListGridView.DataBind();

            HtmlGenericControl div9 = new HtmlGenericControl("div");
            div9.Attributes["id"] = "div9";
            div9.Controls.Add(anotherStudentListGridView);







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


            Response.Redirect("studentsectionreport.aspx");

            // PlaceHolder1.Controls.Add(div9);




        }


    }



    protected void btnExport_Click(object sender, EventArgs e)
    {
        printdata();


    }


}