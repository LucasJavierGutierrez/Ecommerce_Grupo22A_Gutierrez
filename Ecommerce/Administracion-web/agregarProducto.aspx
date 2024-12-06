<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="agregarProducto.aspx.cs" Inherits="Administracion_web.modificaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2 style="font-family: Arial; color: grey;">Agregue un producto</h2>
        <hr />
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripcion" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Tipo" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlTipo" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label Text="Material" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlMaterial" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button CssClass="btn btn-primary" ID="btnSiguiente" OnClick="btnSiguiente_Click" Text="Siguiente" runat="server" />
                <%--CUANDO APRETO EL BOTON, TENGO QUE DAR DE ALTA LA TABLA PRODUCTO PARA PODER CREAR UN ID PRODUCTO--%>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Orificios" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtCantidadOrificios" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Diametro" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtDiametro" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Tipo de Bloqueo" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtTipoBloqueo" CssClass="form-control" runat="server" />
            </div>
            <%if (idTipoSeleccionado == 2)
                { %>
            <div class="mb-3">
                <asp:Label Text="Lado" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtLado" CssClass="form-control" runat="server" />
               </div>
            <% } %>

            <div class="mb-3">
                <asp:Label Text="Imagen URL 1" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtImagenURL1" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Imagen URL 2" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtImagenURL2" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Imagen URL 3" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtImagenURL3" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Imagen URL 4" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtImagenURL4" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
