using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class academicoffice : System.Web.UI.Page
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

        Label1.Text=x;

    }

    //protected void OfferCoursesBtn_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("OfferCourses.aspx");
    //}

    protected void CreateSectionsBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("createSections.aspx");
    }

    protected void AllocateInstructorsBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Allocateinstructor.aspx");
    }

    protected void GenerateReportsBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("genratereports.aspx");
    }

    protected void TeacherSectionBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeacherSection.aspx");
    }

    protected void StudentSectionBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentSection.aspx");
    }


    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}

