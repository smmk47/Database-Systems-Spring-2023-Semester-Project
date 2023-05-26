using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentFeedbackReport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["d1"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }

    /*protected void submitButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string studentEmail = Session["d1"].ToString();

            string studentIdQuery = "SELECT StudentID FROM Student WHERE Email = @Email";
            using (SqlCommand command = new SqlCommand(studentIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Email", studentEmail);
                var studentId = command.ExecuteScalar();

                string insertFeedbackQuery = @"INSERT INTO FacultyFeedback 
                            (StudentID, RollNo, CourseName, FeedbackText, TeacherArrivesOnTime, TeachersPace, TeacherEngagement, 
                             TeacherDedication, TeacherRespect, TeacherAssignments, TeacherRules, TeacherResponsiveness)
                            VALUES 
                            (@StudentID, @RollNo, @CourseName, @FeedbackText, @TeacherArrivesOnTime, @TeachersPace, @TeacherEngagement, 
                             @TeacherDedication, @TeacherRespect, @TeacherAssignments, @TeacherRules, @TeacherResponsiveness)";

                using (SqlCommand feedbackCommand = new SqlCommand(insertFeedbackQuery, connection))
                {
                    feedbackCommand.Parameters.AddWithValue("@StudentID", studentId);
                    feedbackCommand.Parameters.AddWithValue("@RollNo", rollNumberTextBox.Text);
                    feedbackCommand.Parameters.AddWithValue("@CourseName", courseNameTextBox.Text);
                    feedbackCommand.Parameters.AddWithValue("@FeedbackText", feedbackTextBox.Text);
                    feedbackCommand.Parameters.AddWithValue("@TeacherArrivesOnTime", teacherArrivesOnTimeDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeachersPace", teachersPaceDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeacherEngagement", teacherEngagementDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeacherDedication", teacherDedicationDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeacherRespect", teacherRespectDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeacherAssignments", teacherAssignmentsDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeacherRules", teacherRulesDropDownList.SelectedValue);
                    feedbackCommand.Parameters.AddWithValue("@TeacherResponsiveness", teacherResponsivenessDropDownList.SelectedValue);

                    feedbackCommand.ExecuteNonQuery();
                }
            }

            connection.Close();
        }

        // Clear the form
        rollNumberTextBox.Text = string.Empty;
        courseNameTextBox.Text = string.Empty;
        feedbackTextBox.Text = string.Empty;
        teacherArrivesOnTimeDropDownList.SelectedIndex = 0;
        teachersPaceDropDownList.SelectedIndex = 0;
        teacherEngagementDropDownList.SelectedIndex = 0;
        teacherDedicationDropDownList.SelectedIndex = 0;
        teacherRespectDropDownList.SelectedIndex = 0;
        teacherAssignmentsDropDownList.SelectedIndex = 0;
        teacherRulesDropDownList.SelectedIndex = 0;
        teacherResponsivenessDropDownList.SelectedIndex = 0;
    }*/
    protected void submitButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            // Retrieve faculty ID using student email (session variable "d1")
            string studentEmail = Session["d1"].ToString();
            string getFacultyIdQuery = "SELECT FacultyID FROM StudentSection ss INNER JOIN FACULTYSECTION fs ON ss.SectionID = fs.SectionID WHERE ss.StudentID = (SELECT StudentID FROM Student WHERE Email = @Email)";

            using (SqlCommand cmd = new SqlCommand(getFacultyIdQuery, con))
            {
                cmd.Parameters.AddWithValue("@Email", studentEmail);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int facultyId = Convert.ToInt32(result);

                    // Insert feedback into the FacultyFeedback table
                    string insertFeedbackQuery = "INSERT INTO FacultyFeedback (StudentID, RollNo, FacultyID, CourseName, FeedbackText, TeacherArrivesOnTime, TeachersPace, TeacherEngagement, TeacherDedication, TeacherRespect, TeacherAssignments, TeacherRules, TeacherResponsiveness) VALUES ((SELECT StudentID FROM Student WHERE Email = @Email), @RollNo, @FacultyID, @CourseName, @FeedbackText, @TeacherArrivesOnTime, @TeachersPace, @TeacherEngagement, @TeacherDedication, @TeacherRespect, @TeacherAssignments, @TeacherRules, @TeacherResponsiveness)";

                    using (SqlCommand insertCmd = new SqlCommand(insertFeedbackQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@Email", studentEmail);
                        insertCmd.Parameters.AddWithValue("@RollNo", rollNumberTextBox.Text);
                        insertCmd.Parameters.AddWithValue("@FacultyID", facultyId);
                        insertCmd.Parameters.AddWithValue("@CourseName", courseNameTextBox.Text);
                        insertCmd.Parameters.AddWithValue("@FeedbackText", feedbackTextBox.Text);
                        insertCmd.Parameters.AddWithValue("@TeacherArrivesOnTime", teacherArrivesOnTimeDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeachersPace", teachersPaceDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeacherEngagement", teacherEngagementDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeacherDedication", teacherDedicationDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeacherRespect", teacherRespectDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeacherAssignments", teacherAssignmentsDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeacherRules", teacherRulesDropDownList.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@TeacherResponsiveness", teacherResponsivenessDropDownList.SelectedValue);

                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

}