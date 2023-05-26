<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RC.aspx.cs" Inherits="RC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate Reports</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            text-align: center; /* Center align the container */
        }
        .container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }
        h1 {
            margin-bottom: 30px;
        }
        .admin-info {
            text-align: right;
            margin-bottom: 10px;
        }
        .button {
            display: inline-block;
            background-color: #007BFF;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            font-size: 16px;
            border-radius: 5px;
            margin: 10px;
        }
        .button:hover {
            background-color: #0056b3;
            text-decoration: none;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="admin-info">Logged in as: <asp:Label ID="Label1" runat="server" Text="Admin Name"></asp:Label></div>
            <h1>Generate Reports</h1>
            <asp:Button runat="server" Text="Offered Courses Report" CssClass="button" OnClick="OfferedCoursesReport_Click" />
        <asp:Button runat="server" Text="Student Section Report" CssClass="button" OnClick="StudentSectionReport_Click" />
        <asp:Button runat="server" Text="Course Allocation Report" CssClass="button" OnClick="CourseAllocationReport_Click" />
   
        </div>
    </form>
</body>
</html>
