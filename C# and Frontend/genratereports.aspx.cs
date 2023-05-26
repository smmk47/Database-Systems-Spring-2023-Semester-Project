using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class genratereports : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if the AdminName session variable is set
            if (Session["AdminName"] != null)
            {
                string adminName = Session["AdminName"].ToString();
                Label1.Text = adminName;

                // Generate the reports here and save them to the server or display them on the page
            }
            else
            {
                // Admin name not found in session, handle accordingly
            }
        }
    }

    protected void OfferedCoursesReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("courseofferreport.aspx");

        // Generate the offered courses report here and save it to the server or display it on the page
    }

    protected void StudentSectionReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("studentsectionreport.aspx");
        // Generate the student section report here and save it to the server or display it on the page
    }

    protected void CourseAllocationReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("courseallocationreport.aspx");

        // Generate the course allocation report here and save it to the server or display it on the page
    }


    protected void LogsReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("logreport.aspx");
    }
}