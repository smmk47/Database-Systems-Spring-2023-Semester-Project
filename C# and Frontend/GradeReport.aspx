<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GradeReport.aspx.cs" Inherits="GradeReport"  EnableEventValidation="false"  %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluation Report</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
            background-color: #f0f0f0;
        }
        h2 {
            color: #333;
        }
        .report-table {
            width: 100%;
            border-collapse: collapse;
        }
        .report-table th, .report-table td {
            border: 1px solid #666;
            padding: 10px;
            text-align: left;
        }
        .report-table th {
            background-color: #007BFF;
            color: white;
        }
        .print-btn {
            display: block;
            width: 100px;
            height: 40px;
            margin: 20px auto;
            background-color: #007BFF;
            color: white;
            text-align: center;
            line-height: 40px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Evaluation Report</h2>
            
            <asp:GridView ID="GridView1" CssClass="report-table" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                    <asp:BoundField DataField="Assignment" HeaderText="Assignment" />
                    <asp:BoundField DataField="Quiz" HeaderText="Quiz" />
                    <asp:BoundField DataField="Sessional_I" HeaderText="Sessional I" />
                    <asp:BoundField DataField="Sessional_II" HeaderText="Sessional II" />
                    <asp:BoundField DataField="Project" HeaderText="Project" />
                    <asp:BoundField DataField="Final" HeaderText="Final" />
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("Assignment")) + Convert.ToInt32(Eval("Quiz")) + Convert.ToInt32(Eval("Sessional_I")) + Convert.ToInt32(Eval("Sessional_II")) + Convert.ToInt32(Eval("Project")) + Convert.ToInt32(Eval("Final")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grade">
                        <ItemTemplate>
                            <%# CalculateGrade(Convert.ToInt32(Eval("Assignment")) + Convert.ToInt32(Eval("Quiz")) + Convert.ToInt32(Eval("Sessional_I")) + Convert.ToInt32(Eval("Sessional_II")) + Convert.ToInt32(Eval("Project")) + Convert.ToInt32(Eval("Final"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="print-btn" OnClick="btnPrint_Click" />
        </div>
    </form>
</body>
</html>














