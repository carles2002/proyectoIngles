<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EnglishProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelDBPath" runat="server"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label">Log In</asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label">User DNI</asp:Label>
            <asp:TextBox ID="UserDNITextBox" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Label">Password</asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="LoginButton" runat="server" Text="LOG IN" OnClick="Login_Click"/>
        </div>
    </form>
</body>
</html>
