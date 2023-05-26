<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to Flex</title>

    <style>
    body {
    font-family: Arial, sans-serif;
    background-color: #f8f8f8;
}

.container {
    width: 400px;
    margin: 50px 0 50px 50px;
    background-color: white;
    border: 1px solid #ddd;
    border-radius: 4px;
    padding: 24px;
    box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.1);
}

.top {
    display: flex;
    justify-content: center;
    margin-bottom: 24px;
}

.top img {
    max-width: 100%;
    height: auto;
}

.top-right-img {
  position: absolute;
  top: 50px;
  right: 0;
  height: auto;
  width: 780px;
  margin: 0 0 50px 50px;
  background-color: dodgerblue;
  border: 1px medium #ddd;
  border-radius: 1px;
  padding: 30px;
}

h1 {

  font-family: "Times New Roman", Times, serif;
  font-weight: bold;
  font-size: 35px;
  text-align: center;
  line-height: 1;
  color: #0056b3;
  text-shadow: 2px 2px 4px #ddd;
}

h2 {
    font-family: Georgia, serif;
    text-align: center;
    margin-bottom: 24px;
    color: #000;
    text-shadow: 2px 2px 4px #ddd;
}

.label {
    display: inline-block;
    width: 100px;
    font-weight: bold;
    color: #007bff;
    text-transform: uppercase;
    margin-bottom: 4px;
}

.sample-email {
    font-weight: normal;
    font-size: 12px;
    color: #777;
    margin-left: 4px;
}

input[type="text"],
input[type="password"] {
    width: 100%;
    padding: 6px 12px;
    margin: 8px 0;
    box-sizing: border-box;
    border: 1px solid #ccc;
    border-radius: 4px;
}

input[type="submit"] {
  width: 50%;
  padding: 10px 0;
  background: linear-gradient(to bottom, #007bff, #0056b3);
  color: white;
  font-weight: normal;
  border: none;
  border-radius: 10px;
  cursor: pointer ;
  margin-top: 24px;
  margin-left: 80px;
  box-shadow: 0px 2px 2px #888;
  font-family: 'Times New Roman', serif;
}

input[type="submit"]:hover {
  background-color: #ffd800;
}


.radio-group {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: space-between;
}

.logo {
    width: 300px;
    margin: 0 auto;
    display: block;
    margin-bottom: 24px;
}

</style>
</head>
<body>
   <form id="form2" runat="server" class="container">
       <div class="left">
           <img src="https://flexstudent.nu.edu.pk/Assets/demo/demo3/media/img/logo/flex-logo-blue.png" alt="Flex Logo">
           <img src="http://www.nu.edu.pk/Content/images/Slider/01.jpg" alt="Uni Image" class="top-right-img">
       </div>
       <div class="right">
           <h1>Welcome to Flex</h1>
           <h2>Sign In</h2>
           <label for="username">Email:</label>
            <asp:TextBox ID="TextBox1" runat="server" name="username" OnTextChanged="username_TextChanged"></asp:TextBox>
            <span class="sample-email">(Email i.e. Id@nu.edu.pk)</span><br /><br />
            <label for="password">Password:</label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" name="password" OnTextChanged="password_TextChanged"></asp:TextBox><br /><br />
           <label for="userRole">Role: </label>
           <asp:DropDownList ID="userRole" runat="server">
               <asp:ListItem Value="1">Academic Office</asp:ListItem>
               <asp:ListItem Value="2">Student</asp:ListItem>
               <asp:ListItem Value="3">Faculty</asp:ListItem>
           </asp:DropDownList>
             <br />
    <asp:Button ID="Button1" runat="server" Text="Sign In" OnClick="loginButton_Click" UseSubmitBehavior="true" />
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="true"></asp:Label>
</form>


</body>
</html>
