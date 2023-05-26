<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Attendance" %>






<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Faculty</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
        }

        form {
            margin: auto;
            width: 60%;
            padding: 10px;
        }

        h1 {
            text-align: center;
            color: #333;
        }

        #gvStudents {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        #gvStudents th, #gvStudents td {
            border: 1px solid #ddd;
            padding: 15px;
            text-align: center;
        }

        #gvStudents th {
            background-color: #4CAF50;
            color: white;
        }

        #btnSubmit {
            display: block;
            width: 200px;
            height: 50px;
            margin: 20px auto;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        #btnSubmit:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Faculty</h1>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvStudents_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                    <asp:TemplateField HeaderText="Attendance Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem>Present</asp:ListItem>
                                <asp:ListItem>Late</asp:ListItem>
                                <asp:ListItem>Absent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>











