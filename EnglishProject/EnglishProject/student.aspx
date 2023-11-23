﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="EnglishProject.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>Student Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header -->
        <div class="container-fluid" runat="server">
            <nav class="navbar sticky-top navbar-expand-lg bg-body-tertiary" runat="server">
                <div class="container-fluid" runat="server">
                    <!-- Logo -->
                    <a class="navbar-brand" onclick="logo" runat="server">
                        <asp:Image runat="server" src="../img/logo.png" href="index.aspx" alt="Logo" Width="225" Height="80" class="d-inline-block align-text-top" />
                    </a>

                    <!-- Menu -->
                    <button class="navbar-toggler" runat="server" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
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
                        <span class="navbar-text" runat="server">
                            <asp:Button runat="server" class="btn btn-outline-danger btn-lg" Text="Log out" />
                        </span>
                    </div>
                </div>
            </nav>
        </div>
        <!-- Fin Header -->
        <br />
        <div class="container">
            <div class="row">
                <div class="container-sm col-5 card" runat="server">
                    <!-- first and last names -->
                    <div class="card-title" runat="server">
                        <h3>My personal information</h3>
                    </div>
                    <br />
                    <div class="contanier row mb-4" runat="server">
                        <div class="col" runat="server">
                            <div class="form-outline" runat="server">
                                <label class="form-label">Name:</label>
                                <asp:Label ID="name" runat="server" Text="null" class="form-control"></asp:Label>
                                <asp:TextBox ID="nameB" runat="server" class="form-control" type="text"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col" runat="server">
                            <div class="form-outline" runat="server">
                                <label class="form-label">Surname:</label>
                                <asp:Label ID="surname" runat="server" Text="null" class="form-control"></asp:Label>
                                <asp:TextBox ID="surnameB" runat="server" class="form-control">hola</asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- DNI & DOB-->
                    <div class="contanier row mb-4" runat="server">
                        <div class="col" runat="server">
                            <div class="form-outline" runat="server">
                                <label class="form-label">DNI:</label>
                                <asp:Label ID="dni" runat="server" Text="null" class="form-control"></asp:Label>
                                <asp:TextBox ID="dniB" runat="server" class="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col" runat="server">
                            <div class="form-outline" runat="server">
                                <label class="form-label">Date of birth:</label>
                                <asp:Label ID="dob" runat="server" Text="null" class="form-control"></asp:Label>
                                <asp:TextBox ID="dobb" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- Adress & Nationality-->
                    <div class="contanier row mb-4" runat="server">
                        <div class="col" runat="server">
                            <div class="form-outline" runat="server">
                                <label class="form-label">Adress:</label>
                                <asp:Label ID="address" runat="server" Text="null" class="form-control"></asp:Label>
                                <asp:TextBox ID="addressb" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col" runat="server">
                            <div class="form-outline" runat="server">
                                <label class="form-label">Nationality:</label>
                                <asp:Label ID="nationality" runat="server" Text="null" class="form-control"></asp:Label>
                                <asp:TextBox ID="nationalityb" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- buttons -->
                    <div runat="server">
                        <asp:Button ID="change_information" runat="server" Text="Change Information" OnClick="change_information_Click" class="btn btn-primary" />
                        <asp:Button ID="send_information" runat="server" Text="Save Changes" OnClick="saveChanges" class="btn btn-success" /><br />
                        <asp:Label ID="output" runat="server" Text=" "></asp:Label>
                        <br />
                    </div>
                </div>
                <!-- subjects -->
                <br />
                <div class="container-sm col-5 card" runat="server">
                    <div class="card-title" runat="server">
                        <h3>Enter the year to see your subjects</h3>
                    </div>
                    <asp:TextBox ID="year" runat="server" AutoPostBack="true" OnTextChanged="year_TextChanged">_ _ _ _</asp:TextBox>

                    <p></p>
                    <h5>Select one subject to see its information</h5>

                    <asp:ListBox ID="subjectsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subjectsList_SelectedIndexChanged"></asp:ListBox>
                    <p></p>
                    <asp:Label ID="subjectInfoLabel" runat="server" Text="Subject Information:"></asp:Label>
                    <p></p>
                    <asp:Label ID="subjectInfo" runat="server" Text=" "></asp:Label>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
