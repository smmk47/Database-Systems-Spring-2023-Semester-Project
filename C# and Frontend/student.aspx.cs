using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class student : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Assuming "d1" session variable contains the student's email
            string studentEmail = Session["d1"].ToString();
            BindStudentInfo(studentEmail);
            BindStudentMarks(studentEmail);
            BindStudentAttendance(studentEmail);
        }
    }

    private void BindStudentInfo(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvStudentInfo.DataSource = dt;
            gvStudentInfo.DataBind();
        }
    }

    private void BindStudentMarks(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT SM.* FROM StudentMarks SM INNER JOIN Student S ON SM.StudentID = S.StudentID WHERE S.Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvStudentMarks.DataSource = dt;
            gvStudentMarks.DataBind();
        }
    }

    private void BindStudentAttendance(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT SA.AttendanceID, SA.StudentID, SA.Status, SA.AttendanceDate FROM StudentAttendance SA INNER JOIN Student S ON SA.StudentID = S.StudentID WHERE S.Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvStudentAttendance.DataSource = dt;
            gvStudentAttendance.DataBind();
        }
    }

    protected void btnFacultyFeedback_Click(object sender, EventArgs e)
    {
        // Redirect to the Faculty Feedback page
        Response.Redirect("StudentFeedbackReport.aspx");
    }



    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void btnOfferedCourses_Click(object sender, EventArgs e)
    {
        Response.Redirect("offeredcourses.aspx");
    }
}


