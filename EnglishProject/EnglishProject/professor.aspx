<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="professor.aspx.cs" Inherits="EnglishProject.professor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <h2>Your subjects in: </h2>
            <asp:TextBox ID="year" runat="server" AutoPostBack="true" OnTextChanged="year_TextChanged"></asp:TextBox>

            <p></p>
            <asp:ListBox ID="subjectsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subjectsList_SelectedIndexChanged"></asp:ListBox>
            <p></p>
            <asp:Label ID="subjectInfoLabel" runat="server" Text="Subject Information:"></asp:Label>
            <p></p>
            <asp:Label ID="subjectInfo" runat="server" Text=" "></asp:Label> 
            <p></p>
            <h2>Students in the subject </h2>
            <p></p>
            <asp:ListBox ID="studentsList" runat="server"></asp:ListBox>
            <asp:Label ID="output" runat="server" Text=" "></asp:Label> 
            
        </div>
    </form>
</body>
</html>
