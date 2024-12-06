<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="agregarOrificios.aspx.cs" Inherits="Administracion_web.agregarOrificios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <h3 style="color: grey;">Colores</h3>

        <asp:GridView ID="dgvOrificios" runat="server" Style="width: 50%;" OnClass="table" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-ligth table-striped" OnSelectedIndexChanged="dgvOrificios_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Orificios" DataField="Nombre" />
                <asp:CommandField HeaderText="agrega Stock" ShowSelectButton="true" SelectText="stock" />
            </Columns>
        </asp:GridView>
            <div class="col-2"></div>
            <div class="col">
                <a class="btn btn-primary" href="shopTodos.aspx" role="button">Listo</a>
            </div>
            <div class="col-6"></div>
    </div>
</asp:Content>
