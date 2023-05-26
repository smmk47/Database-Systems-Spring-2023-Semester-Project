<%@ Page Language="C#" AutoEventWireup="true" CodeFile="evaluate.aspx.cs" Inherits="evaluate" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Marks</title>
    <style>
        /* Add some basic styling here */

      body {
            font-family: Arial, sans-serif;
            background-color: #ececec;
            padding: 20px;
        }

        h1 {
            text-align: center;
            color: #444;
        }

        form {
            background: #f7f7f7;
            padding: 20px;
            border-radius: 8px;
            max-width: 500px;
            margin: 0 auto;
            border: 1px solid #ddd;
        }

        div {
            margin-bottom: 15px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #666;
        }

        asp:TextBox, asp:DropDownList {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            color: #333;
            background-color: #fff;
        }

        asp:Button {
            display: block;
            width: 100%;
            padding: 10px;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        asp:Button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Enter Student Marks</h1>

        <div>
            <label for="studentDropdown">Select Student:</label>
            <asp:DropDownList ID="studentDropdown" runat="server"></asp:DropDownList>
        </div>

        <div>
            <label for="courseDropdown">Select Course:</label>
            <asp:DropDownList ID="courseDropdown" runat="server"></asp:DropDownList>
        </div>

        <div>
            <label for="assignmentMarks">Assignment Marks:</label>
            <asp:TextBox ID="assignmentMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="quizMarks">Quiz Marks:</label>
            <asp:TextBox ID="quizMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="sessional_1">Sessional I Marks:</label>
            <asp:TextBox ID="sessional_1" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="sessional_2">Sessional II Marks:</label>
            <asp:TextBox ID="sessional_2" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="projectMarks">Project Marks:</label>
            <asp:TextBox ID="projectMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="finalMarks">Final Marks:</label>
            <asp:TextBox ID="finalMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="submitMarks" Text="Submit Marks" runat="server" OnClick="SubmitMarks_Click" />
        </div>
    </form>
</body>
</html>

