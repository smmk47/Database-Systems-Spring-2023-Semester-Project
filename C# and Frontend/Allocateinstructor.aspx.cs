using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Allocateinstructor : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FacultyList.DataSource = GetData("SELECT FacultyID, Fname FROM Faculty");
            FacultyList.DataTextField = "Fname";
            FacultyList.DataValueField = "FacultyID";
            FacultyList.DataBind();

            SectionList.DataSource = GetData("SELECT SectionID, SectionName FROM Section");
            SectionList.DataTextField = "SectionName";
            SectionList.DataValueField = "SectionID";
            SectionList.DataBind();

            CourseList.DataSource = GetData("SELECT CourseID, CourseName FROM Course");
            CourseList.DataTextField = "CourseName";
            CourseList.DataValueField = "CourseID";
            CourseList.DataBind();
        }
    }

    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }
            }
            con.Close();
        }
        return dt;
    }

    protected void AssignButton_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO FACULTYSECTION (SectionID, CourseID, FacultyID) VALUES (@SectionID, @CourseID, @FacultyID)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SectionID", SectionList.SelectedValue);
                cmd.Parameters.AddWithValue("@CourseID", CourseList.SelectedValue);
                cmd.Parameters.AddWithValue("@FacultyID", FacultyList.SelectedValue);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        // Clear the selection or give some feedback to user
    }


}