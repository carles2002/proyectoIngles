<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EnglishProject.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
    <title>UPV universitat Politecnica</title>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</head>
<body class="p-3 m-0 border-0 bd-example m-0 border-0">

    <!-- Header -->
    <div class="container-fluid">
        <nav class="navbar sticky-top navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
                <!-- Logo -->
                <a class="navbar-brand" href="#">
                    <img src="../img/logo.png" alt="Logo" width="225" height="80" class="d-inline-block align-text-top" />
                </a>

                <!-- Menu -->
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarText">
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
                    <span class="navbar-text">
                            <button type="button" class="btn btn-outline-danger btn-lg" href="#">Login</button>
                    </span>
                </div>
            </div>
        </nav>
    </div>
    <!-- Fin Header -->

    <!-- Landing -->
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
                <img src="../img/slider1.jpg" class="card-img-top" alt="slider1"/>
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
                <img src="../img/slider2.jpg" class="card-img-top" alt="slider1"/>
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

    <!-- End Example Code -->
</body>
</html>
