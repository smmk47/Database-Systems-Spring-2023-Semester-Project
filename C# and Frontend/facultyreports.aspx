<%@ Page Language="C#" AutoEventWireup="true" CodeFile="facultyreports.aspx.cs" Inherits="facultyreports" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
            background-color: #f0f0f0;
        }
        h2 {
            color: #333;
        }
        .report-button {
            margin: 10px 0;
            padding: 10px 20px;
            font-size: 1.1em;
            color: white;
            background-color: #007BFF;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .report-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Faculty Dashboard</h2>
            
            <asp:Button ID="btnAttendanceSheet" CssClass="report-button" runat="server" Text="Attendance Sheet Report" OnClick="btnAttendanceSheet_Click" />
            <br />
            <asp:Button ID="btnGradeReport" CssClass="report-button" runat="server" Text="Grade Report" OnClick="btnGradeReport_Click" />
            <br />
            <asp:Button ID="btnCountGrades" CssClass="report-button" runat="server" Text="Count of Grades Report" OnClick="btnCountGrades_Click" />
            <br />
            <asp:Button ID="btnStudentFeedback" CssClass="report-button" runat="server" Text="Students Feedback Report" OnClick="btnStudentFeedback_Click" />
        </div>
    </form>
</body>
</html>

