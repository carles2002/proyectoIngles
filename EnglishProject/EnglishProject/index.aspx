<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EnglishProject.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css" />
    <title>UPV universitat Politecnica</title>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</head>
<body class="p-3 m-0 border-0 bd-example m-0 border-0">
    <form runat="server">
        <!-- Header -->
        <div class="container-fluid" runat="server">
            <nav class="navbar sticky-top navbar-expand-lg bg-body-tertiary" runat="server">
                <div class="container-fluid" runat="server">
                    <!-- Logo -->
                    <a class="navbar-brand" href="#">
                        <img src="../img/logo.png" alt="Logo" width="225" height="80" class="d-inline-block align-text-top" />
                    </a>

                    <!-- Menu -->
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarText" runat="server">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link" href="#">Admission</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Studies</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Investigation</a>
                            </li>
                        </ul>
                        <span class="navbar-text" runat="server">
                            <asp:Button runat="server" OnClick="loginbtn" class="btn btn-outline-danger btn-lg" Text="Log in" />
                        </span>
                    </div>
                </div>
            </nav>
        </div>
        <!-- Fin Header -->

        <!-- Landing -->
        <div class="container text-center">
            <h1>UPV university master's degrees 2024-2025</h1>
            <h5>Get your studies right and enjoy a dream environment from day one. Prepare now for the future you want</h5>
            <br />
            <div class="row justify-content-start">
                <div class="col-sm">
                    <p class="d-inline-flex gap-1">
                        <a class="btn btn-outline-danger" style="--bs-link-hover-color-rgb: 25, 135, 84;" data-bs-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">PAU, pre-registration,enrollment…
                <i class="bi bi-arrow-down"></i>
                        </a>
                    </p>
                    <div class="collapse" id="collapseExample">
                        <div class="card card-body">
                            Find out all the steps and don't miss any date.
                 <button type="button" class="btn btn-outline-danger" width="50" height="50" href="#">More information</button>
                        </div>
                    </div>
                    <br />

                    <p class="d-inline-flex gap-1">
                        <a class="btn btn-outline-danger" style="--bs-link-hover-color-rgb: 25, 135, 84;" data-bs-toggle="collapse" href="#collapseExample2" role="button" aria-expanded="false" aria-controls="collapseExample">What mark do you need?
                <i class="bi bi-arrow-down"></i>
                        </a>
                    </p>
                    <div class="collapse" id="collapseExample2">
                        <div class="card card-body">
                            Know the cut-off marks if you come from high school or cycles, you do high-level sports, you are over 25, 40 or 45 years old...
                 <button type="button" class="btn btn-outline-danger" width="50" height="50" href="#">More information</button>
                        </div>
                    </div>
                    <br />

                    <p class="d-inline-flex gap-1">
                        <a class="btn btn-outline-danger" style="--bs-link-hover-color-rgb: 25, 135, 84;" data-bs-toggle="collapse" href="#collapseExample3" role="button" aria-expanded="false" aria-controls="collapseExample">How many places are offered?
                <i class="bi bi-arrow-down"></i>
                        </a>
                    </p>
                    <div class="collapse" id="collapseExample3">
                        <div class="card card-body">
                            Places at the UPV have not stopped growing in recent years. Check the number of vacancies for the degree you are interested in
                 <button type="button" class="btn btn-outline-danger" width="50" height="50" href="#">More information</button>
                        </div>
                    </div>
                    <br />
                </div>

                <div class="col">
                    <img src="../img/slider1.jpg" class="img-fluid" alt="..." />
                </div>
            </div>
        </div>
        <!-- Landing -->

        <!-- Second -->
        <br />

        <div class="container">
            <h1>What do you want to study?</h1>
            <h5>At the UPV we have a complete catalog of degrees. Explore all the options here or find your title in the search engine:</h5>
            <button type="button" class="btn btn-danger ">Find your degree here</button>
        </div>
        <br />

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <!-- Card1 -->
            <div class="col">
                <div class="card h-100">
                    <img src="../img/slider1.jpg" class="card-img-top" alt="slider1" />
                    <div class="card-body">
                        <h5 class="card-title">Degrees</h5>
                        <p class="card-text">A dream, an opportunity, an exciting future. Find the degree or double degree that best suits your preferences and develop your full potential at the best technological university in Spain.</p>
                    </div>
                    <div class="card-footer">
                        <small class="text-body-secondary">
                            <button type="button" class="btn btn-outline-secondary">More information</button>
                        </small>
                    </div>
                </div>
            </div>

            <!-- Card2 -->
            <div class="col">
                <div class="card h-100">
                    <img src="../img/slider2.jpg" class="card-img-top" alt="slider1" />
                    <div class="card-body">
                        <h5 class="card-title">International double degree</h5>
                        <p class="card-text">The Universitat Politècnica de València offers international double degrees at the undergraduate and master's level. Thanks to the agreement between two universities, the student obtains two different degrees upon finishing their studies, one from each institution. The programs are different, but compatible, and each student can follow their own program.</p>
                    </div>
                    <div class="card-footer">
                        <small class="text-body-secondary">
                            <button type="button" class="btn btn-outline-secondary">More information</button>
                        </small>
                    </div>
                </div>
            </div>

            <!-- Card3 -->
            <div class="col">
                <div class="card h-100">
                    <img src="../img/slider3.jpg" class="card-img-top" alt="slider3" />
                    <div class="card-body">
                        <h5 class="card-title">Regulated professions</h5>
                        <p class="card-text">The UPV offers degrees that qualify for the exercise of the regulated professions of technical engineering and technical architecture, and, starting in the 2014-2015 academic year, also university master's degrees that qualify for the exercise of the regulated professions of engineering and architecture.</p>
                    </div>
                    <div class="card-footer">
                        <small class="text-body-secondary">
                            <button type="button" class="btn btn-outline-secondary">More information</button>
                        </small>
                    </div>
                </div>
            </div>
        </div>

        <!-- Second -->
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
    </form>
</body>
</html>
