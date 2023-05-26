<%@ Page Language="C#" AutoEventWireup="true" CodeFile="academicoffice.aspx.cs" Inherits="academicoffice" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Office Interface</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
            text-align: center; /* Center align the container */
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
            <h1>Welcome to the Academic Office</h1>
<%--            <asp:Button ID="OfferCoursesBtn" runat="server" CssClass="button" Text="Offer Courses" OnClick="OfferCoursesBtn_Click" />--%>
            <asp:Button ID="AllocateInstructorsBtn" runat="server" CssClass="button" Text="Allocate Instructors" OnClick="AllocateInstructorsBtn_Click" />
            <asp:Button ID="CreateSectionsBtn" runat="server" CssClass="button" Text="Create Sections" OnClick="CreateSectionsBtn_Click" />
            <asp:Button ID="GenerateReportsBtn" runat="server" CssClass="button" Text="Generate Reports" OnClick="GenerateReportsBtn_Click" />

            <br /> <!-- Add a line break -->
            <h2>Other Sections:</h2>
            <asp:Button ID="TeacherSectionBtn" runat="server" CssClass="button" Text="Teacher Section" OnClick="TeacherSectionBtn_Click" />
            <asp:Button ID="StudentSectionBtn" runat="server" CssClass="button" Text="Student Section" OnClick="StudentSectionBtn_Click" />

            <br /> <!-- Add a line break for the logout button -->
            <asp:Button ID="LogoutBtn" runat="server" CssClass="button" Text="Logout" OnClick="LogoutBtn_Click" />
        </div>
    </form>
</body>
</html>





