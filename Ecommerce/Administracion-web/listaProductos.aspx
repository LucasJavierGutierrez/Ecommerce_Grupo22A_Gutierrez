<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="listaProductos.aspx.cs" Inherits="Administracion_web.listaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if ((dominio.Usuario)Session["Usuario"] != null && tu == dominio.TipoUsuario.ADMIN)
        {%>
    <script type="text/javascript">
        function getValue() {
            return confirm("¿Estás seguro que lo quiere eliminar?");
        }
    </script>
    <div class="row">
        <hr />
        <div style="text-align: center;">
            <a type="submit" class="btn btn-light" href="listaProductos.aspx">Productos</a>
            <a type="submit" class="btn btn-light" href="listaMarcas.aspx">Marcas</a>
            <a type="submit" class="btn btn-light" href="listaCategorias.aspx">Categorias</a>
            <hr />
        </div>

        <div>
            <a type="submit" style="float: right;" class="btn btn-primary" href="agregarProducto.aspx">Agregar</a>
        </div>
    </div>
    <div class="col-6">
        <div style="padding:10px;">
            <asp:Panel runat="server" CssClass="input-group">
                <asp:TextBox ID="txtSearch" MaxLength="20" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Buscar" />
            </asp:Panel>
        </div>
    </div>
    <div class="col">
        <asp:Repeater ID="repetidor" runat="server">
            <ItemTemplate>
                <div class="card mb-3" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%#Eval("Imagen1")%>" class="img-fluid rounded-start" onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                <p style="color: grey"><%#Eval("Marca.Nombre")%></p>
                                <p style="color: grey;" class="card-text"><%#Eval("Precio")%></p>
                                <a href="agregarProducto.aspx?id=<%#Eval("Id")%>" class="btn btn-primary">Modificar</a>
                                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click1" OnClientClick="return getValue()" CommandArgument='<%#Eval("Id")%>' Text="Eliminar" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="col-4"></div>
    </div>
            <%}
                else
                {
                    Session.Add("Error", "recuerde Loguearse");
                    Response.Redirect("ErrorLogin.aspx", false);

                } %>
</asp:Content>
