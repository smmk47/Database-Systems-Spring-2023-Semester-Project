using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Attendance : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    private int _sectionID;
    private int _courseID;
    private int _facultyID;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStudents();
        }
    }

    protected void BindStudents()
    {
        string facultyEmail = Session["d1"].ToString();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            // First, fetch the SectionID, CourseID, and FacultyID for the faculty
            SqlCommand cmdFaculty = new SqlCommand("SELECT fs.SectionID, fs.CourseID, f.FacultyID FROM FACULTYSECTION fs INNER JOIN Faculty f ON fs.FacultyID = f.FacultyID WHERE f.Email = @Email", con);
            cmdFaculty.Parameters.AddWithValue("@Email", facultyEmail);
            SqlDataReader dr = cmdFaculty.ExecuteReader();
            if (dr.Read())
            {
                _sectionID = dr.GetInt32(0);  // Assuming the SectionID is the first column
                _courseID = dr.GetInt32(1);  // Assuming the CourseID is the second column
                _facultyID = dr.GetInt32(2);  // Assuming the FacultyID is the third column
            }
            dr.Close();

            // Then fetch the students
            SqlCommand cmd = new SqlCommand("SELECT s.StudentID, s.Fname, s.Lname FROM Student s INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID INNER JOIN FACULTYSECTION fs ON ss.SectionID = fs.SectionID WHERE fs.FacultyID = (SELECT FacultyID FROM Faculty WHERE Email = @Email)", con);
            cmd.Parameters.AddWithValue("@Email", facultyEmail);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gvStudents.DataSource = dt;
            gvStudents.DataBind();
            con.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            foreach (GridViewRow row in gvStudents.Rows)
            {
                DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

                // Assuming that you have the FacultyID stored in a variable _facultyID
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentAttendance (StudentID, SectionID, CourseID, FacultyID, Status, AttendanceDate) VALUES (@StudentID, @SectionID, @CourseID, @FacultyID, @Status, @AttendanceDate)", con);

                cmd.Parameters.AddWithValue("@StudentID", row.Cells[0].Text);
                cmd.Parameters.AddWithValue("@SectionID", _sectionID);
                cmd.Parameters.AddWithValue("@CourseID", _courseID);
                cmd.Parameters.AddWithValue("@FacultyID", _facultyID); // Add this line
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@AttendanceDate", DateTime.Now.Date);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        Response.Write("<script>alert('Attendance Marked Successfully.');</script>");
    }



    protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText("Present")); // Default to Present
        }
    }


}











