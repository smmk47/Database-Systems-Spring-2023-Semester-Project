<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Information</title>
    <style>
      body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #ecf0f1;
        }
        .container {
            width: 80%;
            margin: auto;
            overflow: hidden;
        }
        h1 {
            color: #2980b9;
            margin: 20px 0;
        }
        .grid-view {
            margin: 20px 0;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0px 0px 10px #ccc;
        }
        .grid-view label {
            color: #2980b9;
            font-weight: bold;
        }
        .grid-view table {
            width: 100%;
            border-collapse: collapse;
        }
        .grid-view th, .grid-view td {
            padding: 15px;
            border: 1px solid #ddd;
            text-align: left;
        }
        .grid-view th {
            background-color: #3498db;
            color: white;
        }
        .feedback-btn, .logout-btn, .courses-btn {
            display: block;
            width: 200px;
            height: 45px;
            margin: 20px auto;
            background-color: #3498db;
            text-align: center;
            border-radius: 5px;
            color: white;
            font-weight: bold;
            line-height: 45px;
            letter-spacing: 1px;
            text-decoration: none;
        }
        .feedback-btn:hover, .logout-btn:hover, .courses-btn:hover {
            background-color: #2980b9;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome to Student Section</h1>
            <div class="grid-view">
                <asp:Label ID="lblStudentInfo" runat="server" Text="Student Information"></asp:Label>
                <asp:GridView ID="gvStudentInfo" runat="server" AutoGenerateColumns="true" />
            </div>
            <div class="grid-view">
                <asp:Label ID="lblStudentMarks" runat="server" Text="Student Marks"></asp:Label>
                <asp:GridView ID="gvStudentMarks" runat="server" AutoGenerateColumns="true" />
            </div>
            <div class="grid-view">
                <asp:Label ID="lblStudentAttendance" runat="server" Text="Student Attendance"></asp:Label>
                <asp:GridView ID="gvStudentAttendance" runat="server" AutoGenerateColumns="true" />
            </div>
            <asp:Button ID="btnFacultyFeedback" runat="server" Text="Faculty Feedback" CssClass="feedback-btn" OnClick="btnFacultyFeedback_Click" />
            <asp:Button ID="btnOfferedCourses" runat="server" Text="Offered Courses" CssClass="courses-btn" OnClick="btnOfferedCourses_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-btn" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>


