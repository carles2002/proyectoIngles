<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="professor.aspx.cs" Inherits="EnglishProject.professor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

    <title>Professor Page</title>
</head>
<body>
    <form id="form1" runat="server">
         <!-- Header -->
 <div class="container-fluid" runat="server">
     <nav class="navbar sticky-top navbar-expand-lg bg-body-tertiary" runat="server">
         <div class="container-fluid" runat="server">
             <!-- Logo -->
             <a class="navbar-brand" onclick="logo" runat="server" href="index.aspx">
                 <asp:Image runat="server" src="../img/logo.png" alt="Logo" Width="225" Height="80" class="d-inline-block align-text-top" />
             </a>

             <!-- Menu -->
             <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                 <span class="navbar-toggler-icon"></span>
             </button>

             <div class="collapse navbar-collapse" id="navbarText" runat="server">
                 <ul class="navbar-nav me-auto mb-2 mb-lg-0" runat="server">
                     <li class="nav-item">
                         <a class="nav-link" href="index.aspx">Home</a>
                     </li>
                     <li class="nav-item">
                         <a class="nav-link" href="#">Admission</a>
                     </li>
                     <li class="nav-item">
                         <a class="nav-link" href="index.aspx">Studies</a>
                     </li>
                     <li class="nav-item">
                         <a class="nav-link" href="#">Investigation</a>
                     </li>
                 </ul>
             </div>
         </div>
     </nav>
 </div>

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
