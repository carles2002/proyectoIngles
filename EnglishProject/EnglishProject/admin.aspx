<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="EnglishProject.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Button ID="addStudents" runat="server" Text="Add New Students"  OnClick="goToAddStudent"/>
            <asp:Button ID="addProfessors" runat="server" Text="Add New Professors" OnClick="goToAddProfessor" />
                
            <h2>Subjects List</h2>
            <asp:ListBox ID="subjectsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subjectsList_SelectedIndexChanged"></asp:ListBox>
            <h2>Selected subject information</h2>
            <div>
                <p>ID: </p>
                
                <asp:TextBox ID="idb" runat="server"></asp:TextBox>
                <p>Name: </p>
                
                <asp:TextBox ID="nameb" runat="server"></asp:TextBox>
                <p>Credits: </p>
                
                <asp:TextBox ID="creditsb" runat="server"></asp:TextBox>
                <p>Semester: </p>
                
                <asp:TextBox ID="semesterb" runat="server"></asp:TextBox>
                <p>Year: </p>
                
                <asp:TextBox ID="yearb" runat="server"></asp:TextBox>
                <p>Details: </p>
                
                <asp:TextBox ID="detailsb" runat="server"></asp:TextBox>
                <p></p>

                 <asp:Button ID="saveInfo" runat="server" Text="Save Info" OnClick="saveChanges" />
                
                <asp:Label ID="output" runat="server" Text=" OUTPUT "></asp:Label>
             </div>
            <div>
                <h2>Students in Subject</h2>
                <asp:ListBox ID="studentsList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="students_SelectedIndexChanged"></asp:ListBox>
                <asp:Button ID="studDelete" runat="server" Text="Delete Selected Student" OnClick="deleteStudentSubj" />
                <h2>Add Student in Selected Subject</h2>
                <p>Student DNI</p>
                <asp:TextBox ID="studDNI" runat="server" ></asp:TextBox>
                <p>Year of the matriculed subject</p>
                <asp:TextBox ID="addyear" runat="server" ></asp:TextBox>

                <asp:Button ID="addStudent" runat="server" Text="Add Students" OnClick="studDNI_add" />
                
                
            </div>

            <div>
                <h2>Professors in Subject</h2>
                <asp:ListBox ID="profList" runat="server" AutoPostBack="true" ></asp:ListBox>
                <asp:Button ID="deleteProf" runat="server" Text="Delete Selected Profesor" OnClick="deleteProfessorSubj" />
                <h2>Add a Professor in Selected Subject</h2>
                <p>Profesor DNI</p>
                <asp:TextBox ID="DNIprof" runat="server" ></asp:TextBox>
                <p>Year of the subject</p>
                <asp:TextBox ID="yearSubProf" runat="server" ></asp:TextBox>

                <asp:Button ID="addProf" runat="server" Text="Add Professor" OnClick="profDNI_add" />
                
                
            </div>
        </div>
    </form>
</body>
</html>
