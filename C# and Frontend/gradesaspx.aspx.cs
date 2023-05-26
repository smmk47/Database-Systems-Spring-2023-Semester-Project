using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gradesaspx : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateGridView();
        }
    }

    void PopulateGridView()
    {
        DataTable dtbl = new DataTable();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string query = @"SELECT sm.StudentID, sm.CourseID, sm.SectionID, sm.Assignment, sm.Quiz, sm.Sessional_I, sm.Sessional_II, sm.Project, sm.Final, sg.Grade
                             FROM StudentMarks sm
                             INNER JOIN FACULTYSECTION fs ON sm.SectionID = fs.SectionID
                             INNER JOIN Faculty f ON fs.FacultyID = f.FacultyID
                             LEFT JOIN StudentGrades sg ON sm.StudentID = sg.StudentID
                             WHERE f.Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", Session["d1"]);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtbl);
            }
        }

        if (dtbl.Rows.Count > 0)
        {
            foreach (DataRow row in dtbl.Rows)
            {
                int total = Convert.ToInt32(row["Assignment"]) + Convert.ToInt32(row["Quiz"]) + Convert.ToInt32(row["Sessional_I"]) + Convert.ToInt32(row["Sessional_II"]) + Convert.ToInt32(row["Project"]) + Convert.ToInt32(row["Final"]);
                row["Grade"] = CalculateGrade(total);
            }

            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            GridView1.Rows[0].Cells[0].Text = "No Data Found ..!";
            GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }
    }

    string CalculateGrade(int total)
    {
        if (total > 90)
            return "+A";
        else if (total >= 86)
            return "A";
        else if (total >= 82)
            return "-A";
        else if (total >= 78)
            return "+B";
        else if (total >= 74)
            return "B";
        else if (total >= 70)
            return "-B";
        else if (total >= 66)
            return "+C";
        else if (total >= 62)
            return "C";
        else if (total >= 58)
            return "-C";
        else if (total >= 54)
            return "+D";
        else if (total >= 50)
            return "D";
        else
            return "F";
    }
}