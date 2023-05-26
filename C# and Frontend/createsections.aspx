<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createsections.aspx.cs" Inherits="createsections" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Portal</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
        }

        #form1 {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        #GridView1 {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        #GridView1 th, #GridView1 td {
            border: 1px solid #ccc;
            padding: 10px;
            text-align: left;
        }

        #GridView1 th {
            background-color: #f5f5f5;
        }

        #GridView1 tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        #GridView1 tr:hover {
            background-color: #e9e9e9;
        }

        #GridView1 .btnAssign {
            background-color: #008CBA; /* Blue */
            border: none;
            color: white;
            padding: 10px 24px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        #GridView1 .ddlSection {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        h1 {
            text-align: center;
            color: #333;
            font-size: 2em;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Creating Sections</h1>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentID" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" ReadOnly="True" SortExpression="StudentID" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" SortExpression="Fname" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" SortExpression="Lname" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                    <asp:TemplateField HeaderText="Section">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlSection" runat="server" CssClass="ddlSection">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" CssClass="btnAssign" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
           </asp:GridView>
            </div>
        </form>
    </body>
</html>