using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createsectionsandallocateinstructors : System.Web.UI.Page
{

    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudents();
            LoadSections();
        }
    }

    private void LoadStudents()
    {
        // Replace with your own connection string

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT StudentID, Fname, Lname, RollNo FROM Student", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            gvStudents.DataSource = dt;
            gvStudents.DataBind();
        }
    }

    private void LoadSections()
    {
        // Replace with your own connection string

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT SectionID, SectionName FROM Section", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            ddlSections.DataSource = dt;
            ddlSections.DataTextField = "SectionName";
            ddlSections.DataValueField = "SectionID";
            ddlSections.DataBind();
        }
    }

   
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        int sectionID = Convert.ToInt32(ddlSections.SelectedValue);

        // Replace with your own connection string

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            foreach (GridViewRow row in gvStudents.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect != null && chkSelect.Checked)
                {
                    int studentID = Convert.ToInt32(gvStudents.DataKeys[row.RowIndex].Value);

                    SqlCommand cmd = new SqlCommand("INSERT INTO StudentSection (StudentID, SectionID, SemesterID) VALUES (@StudentID, @SectionID, @SemesterID)", conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@SectionID", sectionID);
                    cmd.Parameters.AddWithValue("@SemesterID", sectionID);

                    // Replace with the appropriate CourseID

                    cmd.ExecuteNonQuery();
                }
            }

            lblMessage.Text = "Students assigned to the selected section successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}