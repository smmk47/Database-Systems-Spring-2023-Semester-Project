using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class offeredcourses : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";



    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CreditHours { get; set; }
        public int MaxEnrollment { get; set; }
        public string PreReq { get; set; }
        public int CoordinatorID { get; set; }
        public int SemesterID { get; set; } // New property
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCourses();
        }
    }

    protected void LoadCourses()
    {
        // Retrieve student's email from session variable 'd1'
        string studentEmail = Session["d1"] as string;

        // Query the database to get the student's semester
        int studentSemester = GetStudentSemester(studentEmail);

        // Query the database to get the courses offered in the student's semester
        var courses = GetCoursesBySemester(studentSemester);

        CourseRepeater.DataSource = courses;
        CourseRepeater.DataBind();
    }

    protected int GetStudentSemester(string email)
    {
        int semester = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT SemesterID FROM StudentSemester INNER JOIN Student ON StudentSemester.StudentID = Student.StudentID WHERE Email = @Email";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && !Convert.IsDBNull(result))
                {
                    semester = Convert.ToInt32(result);
                }
            }
        }

        return semester;
    }

    protected bool CanRegister(object semesterID)
    {
        int studentSemester = GetStudentSemester(Session["d1"] as string);

        int courseSemester = Convert.ToInt32(semesterID);

        // Check if the student's semester is greater than 1 and the course semester matches the student's semester
        return studentSemester > 1 && studentSemester == courseSemester;
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        // Get the CourseID from the CommandArgument of the clicked button
        int courseID = Convert.ToInt32((sender as Button).CommandArgument);

        // Get the student's email from the session variable 'd1'
        string studentEmail = Session["d1"] as string;

        // Register the student for the selected course
        RegisterCourse(studentEmail, courseID);

        // Reload the course list
        LoadCourses();
    }

    protected void RegisterCourse(string email, int courseID)
    {
        // Insert the registration into the database
        // Implement the necessary code to insert the registration into the appropriate table(s)
        // For example:

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO StudentCourse (StudentID, CourseID) VALUES ((SELECT StudentID FROM Student WHERE Email = @Email), @CourseID)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@CourseID", courseID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
    protected List<Course> GetCoursesBySemester(int semesterID)
    {
        List<Course> courses = new List<Course>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Course c INNER JOIN CourseSemester cs ON c.CourseID = cs.CourseID WHERE cs.SemesterID = @SemesterID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SemesterID", semesterID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseID = Convert.ToInt32(reader["CourseID"]);
                    course.CourseName = reader["CourseName"].ToString();
                    course.CreditHours = Convert.ToInt32(reader["CreditHours"]);
                    course.MaxEnrollment = Convert.ToInt32(reader["MaxEnrollement"]);
                    course.PreReq = reader["PreReq"].ToString();
                    course.CoordinatorID = Convert.ToInt32(reader["CoordinatorID"]);

                    courses.Add(course);
                }

                reader.Close();
            }
        }

        return courses;
    }


}