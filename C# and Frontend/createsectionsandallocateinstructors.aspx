<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createsectionsandallocateinstructors.aspx.cs" Inherits="createsectionsandallocateinstructors" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Officer Dashboard</title>
    <!-- Add Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <!-- Add custom CSS for further customization -->
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 30px;
        }
        .container {
            max-width: 800px;
        }
        h2 {
            margin-bottom: 30px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .btn {
            width: 100%;
            font-size: 1.1rem;
        }
        .success-message {
            color: green;
            margin-bottom: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblMessage" runat="server" CssClass="success-message" />
            <h2>Registered Students:</h2>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentID" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br />
            <div class="form-group">
                <asp:Label ID="lblSection" runat="server" Text="Select Section:" CssClass="font-weight-bold" />
                <asp:DropDownList ID="ddlSections" runat="server" DataTextField="SectionName" DataValueField="SectionID" CssClass="form-control" />
            </div>
            <asp:Button ID="btnAssign" runat="server" Text="Assign Students to Section" OnClick="btnAssign_Click" CssClass="btn btn-primary" />
        </div>
    </form>
</body>
</html>

