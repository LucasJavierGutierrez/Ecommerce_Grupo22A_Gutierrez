<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administracion_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card {
            position: relative;
            width: 300px;
            height: 350px;
        }

            .card .face {
                position: absolute;
                width: 100%;
                height: 100%;
                backface-visibility: hidden;
                border-radius: 10px;
                overflow: hidden;
                transition: .5s;
            }

            .card .front {
                transform: perspective(600px) rotateY(0deg);
                box-shadow: 0 5px 10px #000;
            }

                .card .front img {
                    position: absolute;
                    width: 100%;
                    height: 100%;
                    object-fit: cover;
                }

                .card .front h3 {
                    position: absolute;
                    bottom: 0;
                    width: 100%;
                    height: 45px;
                    line-height: 45px;
                    color: #fff;
                    background: rgba(0,0,0,.4);
                    text-align: center;
                }

            .card .back {
                transform: perspective(600px) rotateY(180deg);
                background: #000;
                padding: 15px;
                color: #f3f3f3;
                display: flex;
                flex-direction: column;
                justify-content: space-between;
                text-align: center;
                box-shadow: 0 5px 10px #000;
            }

                .card .back .link {
                    border-top: solid 1px #f3f3f3;
                    height: 50px;
                    line-height: 50px;
                }

                    .card .back .link a {
                        color: #f3f3f3;
                    }

                .card .back h3 {
                    font-size: 30px;
                    margin-top: 20px;
                    letter-spacing: 2px;
                }

                .card .back p {
                    letter-spacing: 1px;
                }

            .card:hover .front {
                transform: perspective(600px) rotateY(180deg)
            }

            .card:hover .back {
                transform: perspective(600px) rotateY(360deg)
            }
    </style>
    <div class="row" style="width: 100%;">
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="true">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="../img/imgCarrousel2.jpg" class="d-block w-100" style="height: 100%;" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="../img/imgCarrousel3.png" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="../img/imgCarrousel4.png" class="d-block w-100" alt="...">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <br />
        <h3 style="font-family: Arial; padding-top: 80px; color: #717D7E; text-align: center;">Productos</h3>
        <div class="row row-cols-1 row-cols-md-3 g-4 sectionCard">
            <div class="col">
                <div class="card">
                    <div class="face front">
                        <img src="../img/celularCard.jpg" alt="Alternate Text" />
                        <h3>Celulares</h3>
                    </div>
                    <div class="face back">
                        <h3>Celulares</h3>
                        <p>Ver todos los productos Celulares</p>
                        <div class="link">
                            <a href="ShopCelulares.aspx">Celulares</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="face front">
                        <img src="../img/notebookCard.jpg" alt="Alternate Text" />
                        <h3>Notebooks</h3>
                    </div>
                    <div class="face back">
                        <h3>Notebooks/PC</h3>
                        <p>Ver todos los productos Notebooks/PC</p>
                        <div class="link">
                            <a href="ShopCompus.aspx">Notebooks/PC</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="face front">
                        <img src="../img/electrodomesticosCard.jpg" alt="Alternate Text" />
                        <h3>Ver todo</h3>
                    </div>
                    <div class="face back">
                        <h3>Ver todo</h3>
                        <p>Ver todos los productos</p>
                        <div class="link">
                            <a href="shopTodos.aspx">Ver todo</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div class="row" style="padding-top: 100px;">
        <div class="col-1"></div>
        <div class="col-2" style="text-align: center;">
            <span>
                <img style="width: 80px;" src="../img/iconEnvio.png" alt="Alternate Text" />
            </span>
            <div>
                <h5 style="color: grey;">ENVIAMOS TU COMPRA</h5>
                <p style="color: grey;">Entregas a todo el país</p>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-2" style="text-align: center;">
            <span>
                <img style="width: 80px;" src="../img/iconCreditCard.png" alt="Alternate Text" />
            </span>
            <div>
                <h5 style="color: grey;">PAGO SENCILLO</h5>
                <p style="color: grey;">Pagás y lo llevás</p>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-2" style="text-align: center;">
            <span>
                <img style="width: 80px;" src="../img/iconSecurity.png" alt="Alternate Text" />
            </span>
            <div>
                <h5 style="color: grey;">COMPRÁ CON SEGURIDAD</h5>
                <p style="color: grey;">Tus datos siempre protegidos</p>
            </div>
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
