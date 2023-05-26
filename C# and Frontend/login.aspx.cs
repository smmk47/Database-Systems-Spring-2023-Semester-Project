
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// Other using directives

public partial class login : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    



    protected void userRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void password_TextChanged(object sender, EventArgs e)
    {

    }

    protected void username_TextChanged(object sender, EventArgs e)
    {

    }
  
    protected void loginButton_Click(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            
            string email = TextBox1.Text;
            string password = TextBox2.Text;

            int selectedUserRole = Convert.ToInt32(userRole.SelectedValue);

            Session["d1"] = email;


            string query = "SELECT Userr.UserID, UserRole.RoleID FROM Userr INNER JOIN UserRole ON Userr.UserID = UserRole.UserID WHERE Email = @Email AND Password = @Password AND RoleID = @RoleID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@RoleID", selectedUserRole);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        int roleID = reader.GetInt32(1);

                        // Store the UserID and RoleID in session variables
                        Session["UserID"] = userID;
                        Session["RoleID"] = roleID;

                        // Redirect to a specific page based on the role
                        switch (roleID)
                        {
                            case 1: // Academic Office
                                InsertAuditLog("Logging In", "Academic", email);
                                Response.Redirect("academicoffice.aspx");
                                break;
                            case 2: // Student
                                InsertAuditLog("Logging In", "Student", email);
                                Response.Redirect("student.aspx");
                                break;
                            case 3: // Faculty
                                InsertAuditLog("Logging In", "Faculty", email);
                                Response.Redirect("Faculty.aspx");
                                break;
                            default:
                              //  Label errorMessage = new Label();
                                //errorMessage.Text = "Invalid role.";
                               // form2.Controls.Add(errorMessage);
                                break;
                        }
                    }
                }
                else
                {
                    // Display an error message if the user is not found or the role does not match.
                    //Label errorMessage = new Label();
                    //errorMessage.Text = "Invalid username, password, or role.";
                    //form2.Controls.Add(errorMessage);
                }
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
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {   

    }
}









//  MessageBox.Show("Connection Open");
//SqlCommand cm;
//string un = TextBox1.Text;
//string pass = TextBox2.Text;
//string query = "SELECT u.UserID, u.Email, u.Password, r.RoleID FROM Userr u INNER JOIN UserRole r ON u.UserID = r.UserID WHERE u.Email = @Email AND u.Password = @Password";
//cm = new SqlCommand(query, conn);

//cm.Parameters.AddWithValue("@Email", un);
//cm.Parameters.AddWithValue("@Password", pass);

//SqlDataReader res = cm.ExecuteReader();





//if (!res.HasRows)
//{
//   // MessageBox.Show("No such username found");
//}
//else
//{
//    res.Read();
//    int roleID = res.GetInt32(3);
//    //MessageBox.Show("Successfully logged in!");

//    // Redirect to the appropriate page based on the user role
//    switch (roleID)
//    {
//        case 1: // Assuming 1 corresponds to the "Student" role
//            Response.Redirect("student.aspx");
//            break;
//        case 2: // Assuming 2 corresponds to the "Faculty" role
//            Response.Redirect("faculty.aspx");
//            break;
//        case 3: // Assuming 3 corresponds to the "Academic Office" role
//            Response.Redirect("academicoffice.aspx");
//            break;
//        default:
//      //      MessageBox.Show("Invalid user role");
//            break;
//    }
//}

//Console.WriteLine("After method call, value of res : {0}", res);
//cm.Dispose();
//conn.Close();
////this.Close();





//string username = TextBox1.Text;
//string password = TextBox2.Text;
//string userRole = "\0";



//SqlConnection con = null;
//try
//{
//    // Creating Connection  
//    con = new SqlConnection("data source=DESKTOP-O82UBQG\\SQLEXPRESS; database=FLEXNU; integrated security=SSPI");
//    // writing sql query  
//    SqlCommand cm = new SqlCommand("Select * from Userr where Email = '" + username+"' AND password ='"+ password+"'", con);
//    // Opening Connection  
//    con.Open();
//    // Executing the SQL query  
//    SqlDataReader sdr = cm.ExecuteReader();
//    // Iterating Data  
//    while (sdr.Read())
//    {
//        // Displaying Record  
//        Console.WriteLine(sdr["UserID"] + " " + sdr["Password"] + " " + sdr["Email"]);
//    }
//}


//catch (Exception )
//{
//    Console.WriteLine("OOPs, something went wrong." + e);
//}
//// Closing the connection  
//finally
//{
//    con.Close();
//}