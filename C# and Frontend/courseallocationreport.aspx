<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courseallocationreport.aspx.cs" Inherits="courseallocationreport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Information</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        .grid-container {
            max-width: 80%;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
        }

        #GridView1 {
            width: 100%;
            border-collapse: collapse;
        }

        #GridView1 th, #GridView1 td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ccc;
        }

        #GridView1 th {
            background-color: #007bff;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1" class="grid-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="Semester" HeaderText="Semester" />
                    <asp:TemplateField HeaderText="Instructors">
                        <ItemTemplate>
                            <asp:Label ID="lblInstructors" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course Coordinator">
                        <ItemTemplate>
                            <asp:Label ID="lblCoordinator" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
                <asp:Button ID="btnExport" runat="server" Text="Print Result" OnClick="btnExport_Click" CssClass="btn-export" />

    </form>
</body>
</html>

