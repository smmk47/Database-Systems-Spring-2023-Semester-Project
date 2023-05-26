<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentsectionreport.aspx.cs" Inherits="studentsectionreport" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student List</title>
    <style>
        table {
            width: 50%;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid black;
        }

        th, td {
            padding: 15px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        #toprint {
            margin: 0 auto;
            width: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="toprint" runat="server" >
            <h2>Student List</h2>
            <asp:Label ID="SectionLabel" runat="server" Text="Section: A" Font-Bold="true" />
            <asp:GridView ID="StudentListGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnExport" runat="server" Text="Print Result" OnClick="btnExport_Click" CssClass="btn-export" />

    </form>

</body>
</html> 
