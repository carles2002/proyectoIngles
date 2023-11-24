<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="EnglishProject.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>Admin Page</title>
</head>
<body>
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
    <!-- Fin Header -->


    <form id="form1" runat="server">
        <div class="container">
            <p></p>
            <asp:Button ID="addStudents" runat="server" Text="Add New Students" OnClick="goToAddStudent" class="btn btn-info"/>
            <asp:Button ID="addProfessors" runat="server" Text="Add New Professors" OnClick="goToAddProfessor" class="btn btn-info" />
            <p></p>
        </div>

        <div class="row">
            <!-- Subjects and information -->
            <div class="container-sm col-5 card" runat="server">
                <br />
                <div class="mb-4" runat="server">
                    <div class="col" runat="server">
                        <div class="form-outline" runat="server">
                            <h3>Subjects list</h3>
                            <asp:ListBox ID="subjectsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subjectsList_SelectedIndexChanged"></asp:ListBox>
                        </div>
                    </div>
                    <div class="col" runat="server">
                        <div class="form-outline" runat="server">
                            <h3>Selected subject information</h3>
                            <p>ID: </p>
                            <asp:TextBox ID="idb" runat="server" class="form-control"></asp:TextBox>

                            <p>Name: </p>
                            <asp:TextBox ID="nameb" runat="server" class="form-control"></asp:TextBox>

                            <p>Credits: </p>
                            <asp:TextBox ID="creditsb" runat="server" class="form-control"></asp:TextBox>

                            <p>Semester: </p>
                            <asp:TextBox ID="semesterb" runat="server" class="form-control"></asp:TextBox>

                            <p>Year: </p>
                            <asp:TextBox ID="yearb" runat="server" class="form-control"></asp:TextBox>

                            <p>Details: </p>
                            <asp:TextBox ID="detailsb" runat="server" class="form-control"></asp:TextBox>
                            <p></p>

                            <!-- buttons -->
                            <asp:Button ID="saveInfo" runat="server" Text="Save Info" OnClick="saveChanges" class="btn btn-success" />
                            <asp:Label ID="output" runat="server" Text=""></asp:Label>
                            <p></p>

                        </div>
                    </div>
                </div>
            </div>

            <!-- delete & add -->
            <div class="container-sm col-5 card" runat="server">
                <div class="mb-4" runat="server">
                    <!-- students in subjects -->
                    <div class="col" runat="server">
                        <br />
                        <h2>Students in selected subject</h2>
                        <asp:ListBox ID="studentsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="students_SelectedIndexChanged"></asp:ListBox>
                        <p></p>
                        <asp:Button ID="studDelete" runat="server" Text="Delete Selected Student" OnClick="deleteStudentSubj" class="btn btn-danger" />
                    </div>
                </div>
                <!-- Professors in selected subject -->
                <div class="col" runat="server">
                    <h2>Professors in Subject</h2>
                    <asp:ListBox ID="profList" runat="server" AutoPostBack="true"></asp:ListBox><p></p>
                    <asp:Button ID="deleteProf" runat="server" Text="Delete Selected Profesor" OnClick="deleteProfessorSubj" class="btn btn-danger" /><p></p>
                </div>

                <!-- add student in selected subject -->
                <div class="col" runat="server">
                    <h2>Add student in selected subject</h2>
                    <p>Student DNI</p>
                    <asp:TextBox ID="studDNI" runat="server" class="form-control"></asp:TextBox>
                    <p>Year of the matriculed subject</p>
                    <asp:TextBox ID="addyear" runat="server" class="form-control"></asp:TextBox>
                    <p></p>
                    <asp:Button ID="addStudent" runat="server" Text="Add Students" OnClick="studDNI_add" class="btn btn-success" />
                    <p></p>
                </div>

                <!-- add Professors in selected subject -->
                <div class="col" runat="server">
                    <h2>Add a Professor in Selected Subject</h2>
                    <p>Profesor DNI</p>
                    <asp:TextBox ID="DNIprof" runat="server"></asp:TextBox>
                    <p>Year of the subject</p>
                    <asp:TextBox ID="yearSubProf" runat="server"></asp:TextBox><p></p>

                    <asp:Button ID="addProf" runat="server" Text="Add Professor" OnClick="profDNI_add" class="btn btn-success" />

                </div>


            </div>
        </div>

    </form>
</body>
</html>
