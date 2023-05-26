<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courseofferreport.aspx.cs" Inherits="courseofferreport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Semester List</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        
        .grid-container {
            width: 100%;
            max-width: 1000px;
            margin: 0 auto;
        }

        .grid-view {
            border-collapse: collapse;
            width: 100%;
        }

        .grid-view th {
            background-color: #333333;
            color: #ffffff;
            padding: 8px;
            text-align: left;
            font-weight: bold;
        }

        .grid-view td {
            border: 1px solid #dddddd;
            padding: 8px;
            text-align: left;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid-view tr:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div id="Div1" class="grid-container" runat="server">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
                    <asp:BoundField DataField="MaxEnrollement" HeaderText="Max Enrollment" />
                    <asp:BoundField DataField="PreReq" HeaderText="PreReq" />
                    <asp:BoundField DataField="SemesterID" HeaderText="Semester ID" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnExport" runat="server" Text="Print Result" OnClick="btnExport_Click" CssClass="btn-export" />

    </form>
</body>
</html>



