using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentSection : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int rollNo = int.Parse(txtSearch.Text);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE RollNo = @RollNo", connection))
            {



                string email = Session["d1"] as string;
                InsertAuditLog("Seaching Student  In database ", "Academic", email);

                command.Parameters.AddWithValue("@RollNo", rollNo);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    lblStudentID.Text = reader["StudentID"].ToString();
                    lblRollNo.Text = reader["RollNo"].ToString();
                    lblName.Text = $"{reader["Fname"]} {reader["Lname"]}";
                    lblDOB.Text = reader["DOB"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblPhoneNo.Text = reader["PhoneNo"].ToString();
                    lblDateOfAdmission.Text = reader["DateOfAdmission"].ToString();
                    lblCGPA.Text = reader["CGPA"].ToString();
                    lblCreditHours.Text = reader["CreditHours"].ToString();
                    lblAddress.Text = reader["Address"].ToString();
                }

                else
                {
                    // Clear the labels if the RollNo is not found
                    ClearLabels();
                }
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int rollNo = int.Parse(txtRollNo.Text);
        //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("DELETE FROM Student WHERE RollNo = @RollNo", connection))
            {


                string email = Session["d1"] as string;
                InsertAuditLog("Seaching Student   In database ", "Academic", email);



                command.Parameters.AddWithValue("@RollNo", rollNo);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Show a success message and clear the input field
                    Response.Write("<script>alert('Student record deleted successfully.');</script>");
                    txtRollNo.Text = "";
                }
                else
                {
                    // Show an error message
                    Response.Write("<script>alert('Student record not found.');</script>");
                }
            }
        }
    }

    private void ClearLabels()
    {
        lblStudentID.Text = "";
        lblRollNo.Text = "";
        lblName.Text = "";
        lblDOB.Text = "";
        lblEmail.Text = "";
        lblPhoneNo.Text = "";
        lblDateOfAdmission.Text = "";
        lblCGPA.Text = "";
        lblCreditHours.Text = "";
        lblAddress.Text = "";
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int studentID = Convert.ToInt32(txtStudentID.Text);
        int rollNo = Convert.ToInt32(txtRollNoAdd.Text);
        string firstName = txtFname.Text;
        string lastName = txtLname.Text;
        string dob = txtDOB.Text;
        string email = txtEmailAdd.Text;
        string password = txtPassword.Text;
        string phoneNo = txtPhoneNo.Text;
        string dateOfAdmission = txtDateOfAdmission.Text;
        decimal cgpa = Convert.ToDecimal(txtCGPA.Text);
        int creditHours = Convert.ToInt32(txtCreditHours.Text);
        string address = txtAddress.Text;

        // Assuming you have set up a connection string in your Web.config file.

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string insertQuery = "INSERT INTO Student (StudentID, RollNo, Fname, Lname, DOB, Email, Password, PhoneNo, DateOfAdmission, CGPA, CreditHours, Address) VALUES (@StudentID, @RollNo, @Fname, @Lname, @DOB, @Email, @Password, @PhoneNo, @DateOfAdmission, @CGPA, @CreditHours, @Address)";



            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@RollNo", rollNo);
                command.Parameters.AddWithValue("@Fname", firstName);
                command.Parameters.AddWithValue("@Lname", lastName);
                command.Parameters.AddWithValue("@DOB", dob);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@PhoneNo", phoneNo);
                command.Parameters.AddWithValue("@DateOfAdmission", dateOfAdmission);
                command.Parameters.AddWithValue("@CGPA", cgpa);
                command.Parameters.AddWithValue("@CreditHours", creditHours);
                command.Parameters.AddWithValue("@Address", address);


                string email1 = Session["d1"] as string;
                InsertAuditLog("Registring Student @RollNo  In database ", "Student", email1);


                

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Show success message or perform any other action after successful insertion.
                }
                else
                {
                    // Show error message or perform any other action if insertion failed.
                }
            }

            ; ;
            string insertUserQuery = "INSERT INTO Userr (UserID, Email, Password) VALUES (@UserID, @Email, @Password)";
            using (SqlCommand userCommand = new SqlCommand(insertUserQuery, connection))
            {
                userCommand.Parameters.AddWithValue("@UserID", rollNo);  // Assuming StudentID is also UserID
                userCommand.Parameters.AddWithValue("@Email", email);
                userCommand.Parameters.AddWithValue("@Password", password);
                userCommand.ExecuteNonQuery();
            }

           


            string insertUserRoleQuery = "INSERT INTO UserRole (UserRoleID, RoleID, UserID) VALUES (@UserRoleID, 2 , @UserID)";
            using (SqlCommand userRoleCommand = new SqlCommand(insertUserRoleQuery, connection))
            {
                userRoleCommand.Parameters.AddWithValue("@UserRoleID", rollNo);  // You need to provide this
                userRoleCommand.Parameters.AddWithValue("@RoleID", 2);  // You need to provide this
                userRoleCommand.Parameters.AddWithValue("@UserID", rollNo);  // Assuming StudentID is also UserID
                userRoleCommand.ExecuteNonQuery();
            }

        }
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

    public void assign_privilege(string operationType, string tableName, string userId)
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