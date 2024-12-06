<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShopTornillos.aspx.cs" Inherits="Administracion_web.ShopTornillos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4" style="padding:10px;">
            <asp:Panel runat="server" CssClass="input-group">
                <asp:TextBox ID="txtSearch" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Buscar" />
            </asp:Panel>
        </div>
                <div class="col-6"></div>
        <div class="col-2" style="padding:10px;">
            <div class="btn-group">
                <button type="button" class="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown" data-bs-display="static" aria-expanded="false">
                    Filtrar
                </button>
                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-lg-start">
                    <li>

                        <asp:Button Text="Precio de Menor a Mayor" Type="button" CssClass="dropdown-item" OnClick="btnMenorAMayor_Click"  ID="btnMenorAMayor" runat="server" />

                    </li>
                    <li>
                        <asp:Button Text="Precio de Mayor a menor" Type="button" CssClass="dropdown-item" OnClick="btnMayorAMenor_Click" ID="btnMayorAMenor" runat="server" />

                    </li>
                    <li>
                        <asp:Button Text="A-Z" Type="button" CssClass="dropdown-item" ID="btnAZ" OnClick="btnAZ_Click" runat="server" />

                    </li>
                    <li>
                        <asp:Button Text="Z-A" Type="button" CssClass="dropdown-item" ID="btnZA" OnClick="btnZA_Click" runat="server" />

                    </li>
                </ul>
            </div>
        </div>
        <br />
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <% foreach (dominio.Producto item in ListaProductos)
                {%>
            <div class="col">
                <div class="card h-100" style="width: 18rem;">
                    <img src="<% = item.Imagen1 %>" class="card-img-top img-fluid" alt="..." onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';">
                    <div class="card-body card-heigth-xs">
                        <h5 class="card-title"><% = item.Material.Nombre %></h5>
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p style="color: grey;" class="card-text"><%= item.Precio %></p>
                        <a href="detalleProducto.aspx?id=<% = item.Id %>" class="btn btn-primary">
                            <span>Ver detalle
                                <img style="width: 20px;" src="../img/visibility.png" alt="Alternate Text" /></span>
                        </a>


                    </div>
                </div>
            </div>


            <%} %>
            <br />
            <br />
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
