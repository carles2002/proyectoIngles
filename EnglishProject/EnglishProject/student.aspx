<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="EnglishProject.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>My personal information</h2>
            <p>Name: </p>
            <asp:Label ID="name" runat="server" Text="null"></asp:Label>
            <asp:TextBox ID="nameB" runat="server"></asp:TextBox>
            <p>Surname: </p>
            <asp:Label ID="surname" runat="server" Text="null"></asp:Label>
            <asp:TextBox ID="surnameB" runat="server">hola</asp:TextBox>
            <p>DNI: </p>
            <asp:Label ID="dni" runat="server" Text="null"></asp:Label>
            <asp:TextBox ID="dniB" runat="server"></asp:TextBox>
            <p>Date Of Birth: </p>
            <asp:Label ID="dob" runat="server" Text="null"></asp:Label>
            <asp:TextBox ID="dobb" runat="server"></asp:TextBox>
            <p>Nationality: </p>
            <asp:Label ID="nationality" runat="server" Text="null"></asp:Label>
            <asp:TextBox ID="nationalityb" runat="server"></asp:TextBox>
            <p>Address: </p>
            <asp:Label ID="address" runat="server" Text="null"></asp:Label>
            <asp:TextBox ID="addressb" runat="server"></asp:TextBox>
            <p></p>
            <asp:Button ID="change_information" runat="server" Text="Change Information" OnClick="change_information_Click" />
            <asp:Button ID="send_information" runat="server" Text="Save Changes" OnClick="saveChanges" />
            <asp:Label ID="output" runat="server" Text=" "></asp:Label>


            <h2>Your subjects in: </h2>
            <asp:TextBox ID="year" runat="server" AutoPostBack="true" OnTextChanged="year_TextChanged">----</asp:TextBox>

            <p></p>
            <asp:ListBox ID="subjectsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subjectsList_SelectedIndexChanged"></asp:ListBox>
            <p></p>
            <asp:Label ID="subjectInfoLabel" runat="server" Text="Subject Information:"></asp:Label>
            <p></p>
            <asp:Label ID="subjectInfo" runat="server" Text=" "></asp:Label> 
        </div>
    </form>
</body>
</html>
