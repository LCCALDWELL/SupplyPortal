<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SupplyPortal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supply Portal</title>
    <link href="Stylesheets/LoginPage.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <section class="loginbox">
    <h1>Supply Portal</h1>
        <asp:Label CssClass="label" ID="Label1" runat="server" Text="Username"></asp:Label>
        
        <asp:TextBox CssClass="textbox" ID="usernameTextBox" runat="server"></asp:TextBox>
        
        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Password"></asp:Label>
        
        <asp:TextBox CssClass="textbox" ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        
        <asp:Button CssClass="button" ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Login" />
        <asp:Label CssClass="resultLabel" ID="resultLabel" runat="server"></asp:Label>
        </section>
    </form>
</body>
</html>
