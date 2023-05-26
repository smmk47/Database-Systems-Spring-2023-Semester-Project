<%@ Page Language="C#" AutoEventWireup="true" CodeFile="offeredcourses.aspx.cs" Inherits="offeredcourses" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f5f5f5;
        }

        .container {
            max-width: 600px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
        }

        .course {
            margin-bottom: 20px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
        }

        .course h3 {
            margin-top: 0;
        }

        .course p {
            margin-bottom: 5px;
        }

        .register-btn {
            display: block;
            margin-top: 10px;
            padding: 5px 10px;
            border: none;
            border-radius: 5px;
            background-color: #4CAF50;
            color: #fff;
            text-align: center;
            text-decoration: none;
            cursor: pointer;
        }

        .register-btn:hover {
            background-color: #45a049;
        }

        .no-courses {
            text-align: center;
            color: #888;
            font-style: italic;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Available Courses</h1>
            <asp:Repeater ID="CourseRepeater" runat="server">
                <ItemTemplate>
                    <div class="course">
                        <h3><%# Eval("CourseName") %></h3>
                        <p>Credit Hours: <%# Eval("CreditHours") %></p>
                        <p>Max Enrollment: <%# Eval("MaxEnrollment") %></p>
                        <asp:Button ID="RegisterButton" runat="server" Text="Register" CommandArgument='<%# Eval("CourseID") %>' OnClick="RegisterButton_Click" Visible='<%# CanRegister(Eval("SemesterID")) %>' CssClass="register-btn" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <h5 class="no-courses">No more courses available.</h5>
        </div>
    </form>
</body>
</html>


