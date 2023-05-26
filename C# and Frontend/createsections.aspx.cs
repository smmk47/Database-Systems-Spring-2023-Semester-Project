using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createsections : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        // Bind GridView with students data.
        // Use your own connection string
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student"))
            {
                cmd.Connection = con;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }
        }
    }

    

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        // Get the button that raised the event
        Button btn = (Button)sender;

        // Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;

        // Find the DropDownList in the Row
        DropDownList ddl = (DropDownList)gvr.FindControl("ddlSection");

        // Get the DataKey
        int studentID = Convert.ToInt32(GridView1.DataKeys[gvr.RowIndex].Value);

        // Get the selected section ID
        int sectionID = Convert.ToInt32(ddl.SelectedValue);

        // Assign the selected section to the student
        AssignSectionToStudent(studentID, sectionID);
    }


    private void AssignSectionToStudent(int studentID, int sectionID)
    {
        // Use your own connection string

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            // Check the current enrollment of the section
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM StudentSection WHERE SectionID = @SectionID"))
            {
                cmd.Parameters.AddWithValue("@SectionID", sectionID);
                cmd.Connection = con;
                con.Open();
                int currentEnrollment = (int)cmd.ExecuteScalar();

                // Check the max enrollment of the section
                cmd.CommandText = "SELECT MaxEnrollement FROM Section WHERE SectionID = @SectionID";
                int maxEnrollment = (int)cmd.ExecuteScalar();

                if (currentEnrollment < maxEnrollment)
                {
                    // If the section is not full, assign the student to the section
                    cmd.CommandText = "INSERT INTO StudentSection (StudentID, SectionID, SemesterID) VALUES (@StudentID, @SectionID, @SemesterID)";
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@SemesterID", 1); // Placeholder value
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Handle the case when the section is full
                    // You may want to display an error message to the admin
                    // For example, you can add a Label control to the page and display the error message there
                }

                con.Close();
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlSection = (e.Row.FindControl("ddlSection") as DropDownList);

            // Use your own connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT SectionID, SectionName FROM Section"))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlSection.DataSource = dr;
                    ddlSection.DataTextField = "SectionName";
                    ddlSection.DataValueField = "SectionID";
                    ddlSection.DataBind();
                    con.Close();
                }
            }
        }
    }

}