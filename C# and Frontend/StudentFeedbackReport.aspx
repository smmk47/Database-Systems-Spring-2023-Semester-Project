<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentFeedbackReport.aspx.cs" Inherits="StudentFeedbackReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback</title>
    <style>

 body {
            background-color: #0094ff;
            color: #000000; 
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        h1 {
            color: #0094ff; /* Blue */
        }

        .container {
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            background-color: #ffffff; /* White */
            border-radius: 10px;
        }

        label {
            display: block;
            margin-bottom: 10px;
        }

        input[type="text"], select {
            width: 90%;
            padding: 10px;
            border: 2px solid #007bff;
            border-radius: 5px;
            font-size: 16px;
            background-image: linear-gradient(to right, #007bff, #ffd700);
            color: #ffffff;
        }

        textarea {
            width: 90%;
            padding: 10px;
            border: 2px solid #007bff;
            border-radius: 5px;
            font-size: 16px;
            background-image: linear-gradient(to right, #007bff, #ffd700);
            color: #ffffff;
            resize: vertical;
        }

        input[type="submit"] {
            background: linear-gradient(to bottom, #0094ff, #0066cc);
            color: #ffffff;
            border: none;
            padding: 12px 24px;
            text-align: center;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
            border-radius: 5px;
            transition: all 0.3s ease-in-out;
        }

        input[type="submit"]:hover {
            background: linear-gradient(to bottom, #ffd800, #0094ff);
            box-shadow: 0px 0px 10px #0026ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Feedback</h1>

            <asp:Label ID="studentIdLabel" runat="server" Text="Student ID:" AssociatedControlID="studentIdTextBox" />
            <asp:TextBox ID="studentIdTextBox" runat="server" />

            <asp:Label ID="rollNumberLabel" runat="server" Text="Roll Number:" AssociatedControlID="rollNumberTextBox" />
            <asp:TextBox ID="rollNumberTextBox" runat="server" />

            <asp:Label ID="courseNameLabel" runat="server" Text="Course Name:" AssociatedControlID="courseNameTextBox" />
            <asp:TextBox ID="courseNameTextBox" runat="server" />

            <asp:Label ID="feedbackLabel" runat="server" Text="Feedback:" AssociatedControlID="feedbackTextBox" />
            <asp:TextBox ID="feedbackTextBox" runat="server" TextMode="MultiLine" Rows="5" />

            <asp:Label ID="teacherArrivesOnTimeLabel" runat="server" Text="Teacher arrives on time:" AssociatedControlID="teacherArrivesOnTimeDropDownList" />
            <asp:DropDownList ID="teacherArrivesOnTimeDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teachersPaceLabel" runat="server" Text="Teacher's pace of covering the lecture is normal:" AssociatedControlID="teachersPaceDropDownList" />
            <asp:DropDownList ID="teachersPaceDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teacherEngagementLabel" runat="server" Text="Teacher keeps the students engaged:" AssociatedControlID="teacherEngagementDropDownList" />
            <asp:DropDownList ID="teacherEngagementDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teacherDedicationLabel" runat="server" Text="Teacher is dedicated and determined:" AssociatedControlID="teacherDedicationDropDownList" />
            <asp:DropDownList ID="teacherDedicationDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teacherRespectLabel" runat="server" Text="Teacher is respectful and responsible:" AssociatedControlID="teacherRespectDropDownList" />
            <asp:DropDownList ID="teacherRespectDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teacherAssignmentsLabel" runat="server" Text="Teacher marks the assignments of the students well on time:" AssociatedControlID="teacherAssignmentsDropDownList" />
            <asp:DropDownList ID="teacherAssignmentsDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teacherRulesLabel" runat="server" Text="Teacher follows the university rules:" AssociatedControlID="teacherRulesDropDownList" />
            <asp:DropDownList ID="teacherRulesDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="teacherResponsivenessLabel" runat="server" Text="Teacher is keen and responsive to questions asked by the students:" AssociatedControlID="teacherResponsivenessDropDownList" />
            <asp:DropDownList ID="teacherResponsivenessDropDownList" runat="server">
                <asp:ListItem Value="agree">Agree</asp:ListItem>
                <asp:ListItem Value="disagree">Disagree</asp:ListItem>
                <asp:ListItem Value="neutral">Neutral</asp:ListItem>
                <asp:ListItem Value="dont-tell">Don't want to tell</asp:ListItem>
            </asp:DropDownList>

            <!-- Add more rating questions as needed -->

            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
        </div>
    </form>
</body>
</html>

