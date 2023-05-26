using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Collections.Specialized;

public partial class TeacherSection : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load all data from the database and display it in the gridview
            LoadData();
        }
    }

   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int facultyID;
        if (int.TryParse(txtSearch.Text, out facultyID))
        {
            FetchFacultyData(facultyID);
        }
        else
        {
            // Display an error message if the input is not a valid number
            // You can use a Label or other ASP.NET controls to display the error message
        }
    }




    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    // Get the values from the form
    //    int id1 = Int32.Parse(txtid1.Text);
    //    string fname = txtFname.Text;
    //    string lname = txtLname.Text;
    //    string email = txtEmail.Text;
    //    string password = txtPassword.Text;
    //    string curEdu = txtCurEdu.Text;
    //    int experience = Convert.ToInt32(txtExperience.Text);
    //    string position = txtPosition.Text;
    //    string dateOfEmployment = txtDateOfEmployment.Text;

    //    // Set up the SQL query
    //    string query = "INSERT INTO Faculty (FacultyID ,Fname, Lname, Email, Password, CurEdu, Experience, Position, DateOfEmployement) " +
    //                   "VALUES (@id1  @Fname, @Lname, @Email, @Password, @CurEdu, @Experience, @Position, @DateOfEmployement)";

    //    // Set up the SQL connection and command
    //   // string connectionString = "your_connection_string_here";
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    using (SqlCommand command = new SqlCommand(query, connection))
    //    {
    //        // Add the parameter values to the command
    //        command.Parameters.AddWithValue("@FacultyID", id1);
    //        command.Parameters.AddWithValue("@Fname", fname);
    //        command.Parameters.AddWithValue("@Lname", lname);
    //        command.Parameters.AddWithValue("@Email", email);
    //        command.Parameters.AddWithValue("@Password", password);
    //        command.Parameters.AddWithValue("@CurEdu", curEdu);
    //        command.Parameters.AddWithValue("@Experience", experience);
    //        command.Parameters.AddWithValue("@Position", position);
    //        command.Parameters.AddWithValue("@DateOfEmployement", dateOfEmployment);

    //        // Open the connection and execute the query
    //        connection.Open();
    //        int rowsAffected = command.ExecuteNonQuery();

    //        // Display a message based on the result
    //        if (rowsAffected > 0)
    //        {
    //            Response.Write("Data added successfully!");
    //        }
    //        else
    //        {
    //            Response.Write("Error adding data.");
    //        }
    //    }
    //}

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Get the values from the form
        int id1 = int.Parse(Textid1.Text.Trim());

        string fname = txtFname.Text;
        string lname = txtLname.Text;
        string email = txtEmail.Text;
        string password = txtPassword.Text;
        string curEdu = txtCurEdu.Text;
        int experience = Convert.ToInt32(txtExperience.Text);
        string position = txtPosition.Text;
        string dateOfEmployment = txtDateOfEmployment.Text;

        // Set up the SQL query
        string query = "INSERT INTO Faculty (FacultyID, Fname, Lname, Email, Password, CurEdu, Experience, Position, DateOfEmployement) " +
                       "VALUES (@FacultyID, @Fname, @Lname, @Email, @Password, @CurEdu, @Experience, @Position, @DateOfEmployement)";

        // Set up the SQL connection and command
        //string connectionString = "your_connection_string_here";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add the parameter values to the command
            command.Parameters.AddWithValue("@FacultyID", id1);
            command.Parameters.AddWithValue("@Fname", fname);
            command.Parameters.AddWithValue("@Lname", lname);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@CurEdu", curEdu);
            command.Parameters.AddWithValue("@Experience", experience);
            command.Parameters.AddWithValue("@Position", position);
            command.Parameters.AddWithValue("@DateOfEmployement", dateOfEmployment);

            string email1 = Session["d1"] as string;
            InsertAuditLog("Adding teacher   In database ", "Academic", email1);

            // Open the connection and execute the query
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            // Display a message based on the result
            if (rowsAffected > 0)
            {
                Response.Write("Data added successfully!");
            }
            else
            {
                Response.Write("Error adding data.");
            }



            string insertUserQuery = "INSERT INTO Userr (UserID, Email, Password) VALUES (@UserID, @Email, @Password)";
            using (SqlCommand userCommand = new SqlCommand(insertUserQuery, connection))
            {
                userCommand.Parameters.AddWithValue("@UserID", id1);  // Assuming StudentID is also UserID
                userCommand.Parameters.AddWithValue("@Email", email);
                userCommand.Parameters.AddWithValue("@Password", password);
                userCommand.ExecuteNonQuery();
            }




            string insertUserRoleQuery = "INSERT INTO UserRole (UserRoleID, RoleID, UserID) VALUES (@UserRoleID, 3 , @UserID)";
            using (SqlCommand userRoleCommand = new SqlCommand(insertUserRoleQuery, connection))
            {
                userRoleCommand.Parameters.AddWithValue("@UserRoleID", id1);  // You need to provide this
                userRoleCommand.Parameters.AddWithValue("@RoleID", 3);  // You need to provide this
                userRoleCommand.Parameters.AddWithValue("@UserID", id1);  // Assuming StudentID is also UserID
                userRoleCommand.ExecuteNonQuery();
            }

        }



    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Get the ID to delete from the text box
        int id = int.Parse(txtID.Text.Trim());

        // Create a connection to the database
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open the connection
            connection.Open();

            // Create a SQL command to delete the row with the given ID from the Faculty table
            string query = "DELETE FROM Faculty WHERE FacultyID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            string email1 = Session["d1"] as string;
            InsertAuditLog("deleting teacher   In database ", "Academic", email1);
            // Execute the command
            command.ExecuteNonQuery();
        }

        // Clear the text box and reload the data
        txtID.Text = "";
        LoadData();
    }

    private void LoadData()
    {
        // Create a connection to the database
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open the connection
            connection.Open();

                // Create a SQL command to select all data from the Faculty table
        string query = "SELECT * FROM Faculty";
            SqlCommand command = new SqlCommand(query, connection);

            // Execute the command and get the results
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Display the results in the gridview
            //tblData.DataBind();
        }
    }


    private void FetchFacultyData(int facultyID)
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Faculty WHERE FacultyID = @FacultyID", con))
            {
                cmd.Parameters.AddWithValue("@FacultyID", facultyID);



                string email1 = Session["d1"] as string;
                InsertAuditLog("Seaching teacher   In database ", "Academic", email1);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblID.Text = reader["FacultyID"].ToString();
                        lblName.Text = reader["Fname"].ToString() + " " + reader["Lname"].ToString();
                        lblEmail.Text = reader["Email"].ToString();
                        lblCurEdu.Text = reader["CurEdu"].ToString();
                        lblExperience.Text = reader["Experience"].ToString();
                        lblPosition.Text = reader["Position"].ToString();
                        lblDateOfEmployment.Text = reader["DateOfEmployement"].ToString();
                    }
                    else
                    {
                        // Display an error message if the faculty ID does not exist in the database
                        // You can use a Label or other ASP.NET controls to display the error message
                    }
                }

            }
        }
    }



    protected void tblData_SelectedIndexChanged(object sender, EventArgs e)
    {







    }



    public void InsertAuditLog(string operationType, string tableName, string userId)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand("INSERT INTO AuditLog (OperationType, TableName, UserID, DateTime) VALUES (@OperationType, @TableName, @UserID, @DateTime)", connection))
            {
                command.Parameters.AddWithValue("@OperationType", operationType);
                command.Parameters.AddWithValue("@TableName", tableName);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@DateTime", DateTime.UtcNow);

                command.ExecuteNonQuery();
            }
        }
    }

}


