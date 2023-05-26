<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CountGradesReport.aspx.cs" Inherits="CountGradesReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grade Count Report</title>
    <style>
        /* Apply CSS styling to the GridView */
        #GridView1 {
            font-family: Arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        /* Apply styling to table header */
        #GridView1 th {
            background-color: #f2f2f2;
            padding: 8px;
            text-align: left;
        }

        /* Apply styling to table cells */
        #GridView1 td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        /* Apply alternate row background color */
        #GridView1 tr:nth-child(even) {
            background-color: #f9f9f9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="d1" runat="server" >
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:BoundField DataField="Count" HeaderText="Count" />
                </Columns>
            </asp:GridView>
        </div>
                    <asp:Button ID="btnExport" runat="server" Text="Print Result" OnClick="btnExport_Click" CssClass="btn-export" />

    </form>
</body>
</html>




