using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class facultyreports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAttendanceSheet_Click(object sender, EventArgs e)
    {
        Response.Redirect("AttendanceSheetReport.aspx");

    }

    protected void btnGradeReport_Click(object sender, EventArgs e)
    {
        // Redirect to the Grade Report Page
        Response.Redirect("GradeReport.aspx");

    }

    protected void btnCountGrades_Click(object sender, EventArgs e)
    {
        // Redirect to the Count of Grades Report Page
        Response.Redirect("CountGradesReport.aspx");
    }

    protected void btnStudentFeedback_Click(object sender, EventArgs e)
    {
        // Redirect to the Students Feedback Report Page
        Response.Redirect("feedbackreport.aspx");

    }


}