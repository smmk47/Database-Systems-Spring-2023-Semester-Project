using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class faculty : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        string x = "";
        if (!IsPostBack)
        {
            if (Session["d1"] != null)
            {
                string adminname = Session["d1"].ToString();
                // Use the data as needed
                x=adminname;
            }
        }


        if (!IsPostBack)
        {
            string facultyEmail = x;
            LoadFacultyInfo(facultyEmail);
            LoadCourseInfo(facultyEmail);
        }
    }

    private void LoadFacultyInfo(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Faculty WHERE Email = @Email", con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblFacultyInfo.Text = "Faculty Information: " + reader["Fname"].ToString() + " " + reader["Lname"].ToString();
                        lblCurEdu.Text = "Current Education: " + reader["CurEdu"].ToString();
                        lblExperience.Text = "Experience: " + reader["Experience"].ToString() + " years";
                        lblPosition.Text = "Position: " + reader["Position"].ToString();
                        lblDateOfEmployment.Text = "Date of Employment: " + reader["DateOfEmployement"].ToString();
                    }
                }
            }
        }
    }

    private void LoadCourseInfo(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(@"SELECT C.CourseID, C.CourseName, C.CreditHours
                                                     FROM Course C
                                                     JOIN FacultyCourse FC ON C.CourseID = FC.CourseID JOIN Faculty F ON FC.FacultyID = F.FacultyID WHERE F.Email = @Email", con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblCourseInfo.Text = "Courses Taught:";
                        gvCourseInfo.DataSource = dt;
                        gvCourseInfo.DataBind();
                    }
                }
            }
        }
    }



    protected void btnAttendance_Click(object sender, EventArgs e)
    {
        Response.Redirect("Attendance.aspx");

    }

    protected void btnEvaluation_Click(object sender, EventArgs e)
    {
        Response.Redirect("evaluate.aspx");

    }

    protected void btnGenerateGrades_Click(object sender, EventArgs e)
    {
        Response.Redirect("gradesaspx.aspx");

    }

    protected void btnGenerateReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("facultyreports.aspx");

    }






    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}