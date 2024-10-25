<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="listaMarcas.aspx.cs" Inherits="Administracion_web.listaMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <hr />
        <div style="text-align: center;">
            <a type="submit" class="btn btn-light" href="listaProductos.aspx">Productos</a>
            <a type="submit" class="btn btn-light" href="listaMarcas.aspx">Marcas</a>
            <a type="submit" class="btn btn-light" href="listaCategorias.aspx">Categorias</a>
        </div>
        <hr />
        <div>
            <a type="submit" style="float: right;" class="btn btn-primary" href="agregarMarca.aspx">Agregar</a>

        </div>
        <div class="col-4"></div>
        
        <div class="col-6" style="text-align:center;" >
            <asp:GridView runat="server" ID="dgvListaMarcas" Style="width: 60%;" OnClass="table" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped" OnSelectedIndexChanged="dgvListaMarcas_SelectedIndexChanged" OnRowCommand="dgvListaMarcas_RowCommand">
                <Columns >
                    <asp:BoundField HeaderText="Marca" DataField="Nombre" />
                    <asp:CommandField HeaderText="Modifica" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="true" SelectText="Modificar" />
                    <asp:ButtonField  Text="Eliminar" ControlStyle-CssClass="btn btn-danger" runat="server" />

                </Columns>
            </asp:GridView>

                                <%  if (confirmaEliminacion)
                        { %>
                    <div>
                        <asp:CheckBox AutoPosback="false" Text="Confirmar eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>
                    <% }  %>

        </div>
        <div class="col-4"></div>


    </div>
</asp:Content>
