<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EnglishProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>Log in page</title>
</head>
<body>
    <!-- Header -->
    <div class="container-fluid" runat="server">
        <nav class="navbar sticky-top navbar-expand-lg bg-body-tertiary" runat="server">
            <div class="container-fluid" runat="server">
                <!-- Logo -->
                <a class="navbar-brand" onclick="logo" runat="server" href="index.aspx" >
                    <asp:Image runat="server" src="../img/logo.png"  alt="Logo" Width="225" Height="80" class="d-inline-block align-text-top" />
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

    <!-- form -->
    <br />
    <form id="form1" runat="server">
        <div class="container-sm col-3 card" runat="server">


            <asp:Panel ID="Panel1" Visible="false" runat="server">
                <div class="container alert alert-dismissible alert-danger " runat="server">
                    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                    <strong>
                        <asp:Label ID="LabelDBPath" runat="server"></asp:Label></strong>
                </div>

            </asp:Panel>


            <div class="mb-3">
                <div class="card-header" runat="server">Log in</div>
                <br />
                <asp:Label ID="Label2" runat="server" class="form-label" aria-describedby="emailHelp" Text="Label">User DNI</asp:Label>
                <asp:TextBox ID="UserDNITextBox" runat="server" class="form-control"></asp:TextBox>
                <div id="emailHelp" class="form-text">Log in with your DNI and password the administrator gave to you</div>
            </div>

            <div class="mb-3">
                <asp:Label ID="Label3" runat="server" Text="Label" for="exampleInputPassword1" class="form-label">Password </asp:Label>
                <asp:TextBox ID="PasswordTextBox" runat="server" type="password" class="form-control"></asp:TextBox>
            </div>

            <asp:Button ID="LoginButton" runat="server" Text="LOG IN" class="btn btn-primary btn-block mb-4" OnClick="Login_Click" />
        </div>
    </form>
    <!-- form -->

    <!-- Footer -->

    <div class="container">
        <footer class="row row-cols-1 row-cols-sm-2 row-cols-md-5 py-5 my-5 border-top">
            <div class="col mb-3">
                <a href="/" class="d-flex align-items-center mb-3 link-body-emphasis text-decoration-none">
                    <img src="../img/logo.png" alt="Logo" width="225" height="80" class="d-inline-block align-text-top" />
                </a>
                <p class="text-body-secondary">© 2023</p>
            </div>

            <div class="col mb-3">
            </div>

            <div class="col mb-3">
                <h5>Resources</h5>
                <ul class="nav flex-column">
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Academic calendar</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Thesis, TFG, articles and more</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Accommodations</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Corporate identity</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">About</a></li>
                </ul>
            </div>

            <div class="col mb-3">
                <h5>Facilities</h5>
                <ul class="nav flex-column">
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">How to get here</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">2D blueprints</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Image gallery</a></li>
                </ul>
            </div>

            <div class="col mb-3">
                <h5>College life</h5>
                <ul class="nav flex-column">
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Home</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Features</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">Pricing</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">FAQs</a></li>
                    <li class="nav-item mb-2"><a href="#" class="nav-link p-0 text-body-secondary">About</a></li>
                </ul>
            </div>
        </footer>
    </div>
    <!-- Fin Footer -->

</body>
</html>
