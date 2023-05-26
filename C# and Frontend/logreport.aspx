<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logreport.aspx.cs" Inherits="logreport" %>

<<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Audit Log Report</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid black;
            padding: 15px;
            text-align: left;
        }

        th {
            background-color: #4CAF50;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" id="div1">
            <h2>Audit Log Report</h2>
            <asp:GridView ID="AuditLogGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="AuditLogID" HeaderText="Audit Log ID" />
                    <asp:BoundField DataField="OperationType" HeaderText="Operation Type" />
                    <asp:BoundField DataField="TableName" HeaderText="Table Name" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" />
                    <asp:BoundField DataField="DateTime" HeaderText="Date and Time" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnExport" runat="server" Text="Print Result" OnClick="btnExport_Click" CssClass="btn-export" />

    </form>
</body>
</html>

