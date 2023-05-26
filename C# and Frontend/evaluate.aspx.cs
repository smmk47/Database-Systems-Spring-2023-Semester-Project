using Microsoft.VisualStudio.OLE.Interop;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class evaluate : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load data into dropdowns, using Session["d1"] to get the relevant data for this faculty member
            studentDropdown.DataSource = GetStudents();
            studentDropdown.DataTextField = "Fname";
            studentDropdown.DataValueField = "StudentID";
            studentDropdown.DataBind();

            courseDropdown.DataSource = GetCoursesForFaculty(Session["d1"].ToString());
            courseDropdown.DataTextField = "CourseName";
            courseDropdown.DataValueField = "CourseID";
            courseDropdown.DataBind();
        }
    }

    protected void SubmitMarks_Click(object sender, EventArgs e)
    {
        // Get the selected student, course and marks
        var selectedStudent = studentDropdown.SelectedValue;
        var selectedCourse = courseDropdown.SelectedValue;
       


        var assignment_Marks = int.Parse(assignmentMarks.Text);
        var quiz_Marks = int.Parse(quizMarks.Text);
        var sessional_1Marks = int.Parse(sessional_1.Text);
        var sessional_2Marks = int.Parse(sessional_2.Text);
        var project_Marks = int.Parse(projectMarks.Text);
        var final_Marks = int.Parse(finalMarks.Text);

        // Save the marks in the database
        SaveMarks(selectedStudent, selectedCourse, assignment_Marks, quiz_Marks, sessional_1Marks, sessional_2Marks, project_Marks, final_Marks);

        // Optionally, clear the form and show a success message
        ClearForm();
        ShowSuccessMessage();
    }

    private DataTable GetStudents()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Student", connection))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    private DataTable GetCoursesForFaculty(string facultyEmail)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = @"SELECT DISTINCT c.CourseID, c.CourseName
                             FROM Course c
                             JOIN FACULTYSECTION fs ON c.CourseID = fs.CourseID
                             JOIN Faculty f ON fs.FacultyID = f.FacultyID
                             WHERE f.Email = @facultyEmail";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@facultyEmail", facultyEmail);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    private void SaveMarks(string studentId, string courseId, int assignmentMarks, int quizMarks, int sessional_1Marks, int sessional_2Marks, int projectMarks, int finalMarks)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sectionIdQuery = @"SELECT fs.SectionID 
                                  FROM FACULTYSECTION fs 
                                  JOIN Faculty f ON fs.FacultyID = f.FacultyID
                                  WHERE f.Email = @facultyEmail AND fs.CourseID = @courseId";

            int sectionId;
            using (SqlCommand sectionIdCommand = new SqlCommand(sectionIdQuery, connection))
            {
                sectionIdCommand.Parameters.AddWithValue("@facultyEmail", Session["d1"]);
                sectionIdCommand.Parameters.AddWithValue("@courseId", courseId);

                // Execute the command and get the section ID
                sectionId = (int)sectionIdCommand.ExecuteScalar();
            }

            string query = @"INSERT INTO StudentMarks (StudentID, CourseID, SectionID, Assignment, Quiz, Sessional_I, Sessional_II, Project, Final) 
                         VALUES (@studentId, @courseId, @sectionId, @assignmentMarks, @quizMarks, @sessional_1Marks, @sessional_2Marks, @projectMarks, @finalMarks)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@studentId", studentId);
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@sectionId", sectionId);
                command.Parameters.AddWithValue("@assignmentMarks", assignmentMarks);
                command.Parameters.AddWithValue("@quizMarks", quizMarks);
                command.Parameters.AddWithValue("@sessional_1Marks", sessional_1Marks);
                command.Parameters.AddWithValue("@sessional_2Marks", sessional_2Marks);
                command.Parameters.AddWithValue("@projectMarks", projectMarks);
                command.Parameters.AddWithValue("@finalMarks", finalMarks);

                command.ExecuteNonQuery();
            }
        }
    }


    private void ClearForm()
    {
        // Clear the text boxes
        assignmentMarks.Text = string.Empty;
        quizMarks.Text = string.Empty;
        sessional_1.Text = string.Empty;
        sessional_2.Text = string.Empty;
        projectMarks.Text = string.Empty;
        finalMarks.Text = string.Empty;
    }

    private void ShowSuccessMessage()
    {
        // Show a success message to the user
        // This could be a label on the page, a JavaScript alert, etc.
        // This is just an example
        Response.Write("<script>alert('Marks submitted successfully.');</script>");
    }
}