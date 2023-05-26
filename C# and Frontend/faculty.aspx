<%@ Page Language="C#" AutoEventWireup="true" CodeFile="faculty.aspx.cs" Inherits="faculty" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty Information</title>
    <style>
      body {
        background-color: #f0f0f0;
        font-family: Helvetica, sans-serif;
        line-height: 1.5;
      }

      #form1 {
        width: 80%;
        margin: 0 auto;
        padding: 20px;
        background-color: #fff;
        border: 1px solid #ccc;
      }

      #form1 div {
        margin-bottom: 20px;
      }

      #form1 label {
        display: block;
        margin-bottom: 5px;
        font-size: 16px;
        font-weight: bold;
      }

      #form1 .gridview {
        border-collapse: collapse;
        width: 100%;
      }

      #form1 .gridview th,
      #form1 .gridview td {
        padding: 8px;
        text-align: left;
        border-bottom: 1px solid #ddd;
      }

      #form1 .gridview th {
        background-color: #ffd800;
        color: #fff;
      }

      #form1 .gridview tr:nth-child(even) {
        background-color: #f9f9f9;
      }

      #form1 .gridview tr:hover {
        background-color: #e9e9e9;
      }

      #form1 .button-container {
        display: flex;
        justify-content: space-between;
        align-items: center;
        flex-wrap: wrap;
      }

      #form1 .btn {
        background: linear-gradient(to bottom, #0094ff, #0066cc);
        color: #ffffff;
        border: none;
        padding: 12px 24px;
        text-align: center;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        border-radius: 5px;
        transition: all 0.3s ease-in-out;
      }

      #form1 .btn:hover {
        background: linear-gradient(to bottom, #ffd800, #0094ff);
        box-shadow: 0px 0px 10px #0026ff;
      }

      #form1 .btn-logout {
        background: linear-gradient(to bottom, #ff0000, #cc0000);
        color: #ffffff;
        border: none;
        padding: 12px 24px;
        text-align: center;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        border-radius: 5px;
        transition: all 0.3s ease-in-out;
      }

      #form1 .btn-logout:hover {
        background: linear-gradient(to bottom, #ffd800, #ff0000);
        box-shadow: 0px 0px 10px #ff0000;
      }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFacultyInfo" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="lblCurEdu" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblExperience" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblPosition" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblDateOfEmployment" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblCourseInfo" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br />
            <asp:GridView ID="gvCourseInfo" runat="server" CssClass="gridview" AutoGenerateColumns="False">
                <Columns>
                   <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="button-container">
            <asp:Button ID="btnAttendance" runat="server" Text="Attendance" OnClick="btnAttendance_Click" CssClass="btn" />
            <asp:Button ID="btnEvaluation" runat="server" Text="Evaluation" OnClick="btnEvaluation_Click" CssClass="btn" />
            <asp:Button ID="btnGenerateGrades" runat="server" Text="Generate Grades" OnClick="btnGenerateGrades_Click" CssClass="btn" />
            <asp:Button ID="btnGenerateReports" runat="server" Text="Generate Reports" OnClick="btnGenerateReports_Click" CssClass="btn" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn-logout" />

        </div>
    </form>
</body>
</html>

