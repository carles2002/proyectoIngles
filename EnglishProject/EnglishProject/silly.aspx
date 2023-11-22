<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="silly.aspx.cs" Inherits="EnglishProject.silly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>You shouldn't be here, you've tried to do bad things</p>
            <asp:Button ID="Button1" runat="server" Text="Return to a safe place" OnClick="safe"/>
        </div>
    </form>
</body>
</html>
