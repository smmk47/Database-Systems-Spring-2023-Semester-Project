<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedbackreport.aspx.cs" Inherits="feedbackreport" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty Feedback Report</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f0f0f0;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }

        h1 {
            text-align: center;
            color: #333;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            border: 1px solid #ddd;
            margin-top: 20px;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .grid-view th {
            background-color: #4CAF50;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="toprint" class="container" runat="server" >
            <h1>Faculty Feedback Report</h1>
            <asp:GridView ID="gvFeedbackReport" runat="server" CssClass="grid-view" AutoGenerateColumns="true" />
        </div>
<asp:Button ID="btnExport" runat="server" Text="Print Result" OnClick="btnExport_Click" CssClass="btn-export" />
    </form>
</body>

</html>

