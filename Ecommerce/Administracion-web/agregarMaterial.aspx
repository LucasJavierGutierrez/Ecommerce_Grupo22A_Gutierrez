<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="agregarMaterial.aspx.cs" Inherits="Administracion_web.modificaMaterial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2 style="font-family: Arial; color: grey;">Agregue un material</h2>
        <hr />
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button CssClass="btn btn-primary" ID="btnSiguiente" OnClick="btnSiguiente_Click" Text="Siguiente" runat="server" />
               <%--CUANDO APRETO EL BOTON, TENGO QUE DAR DE ALTA LA TABLA PRODUCTO PARA PODER CREAR UN ID MATERIAL--%>
            </div>

        </div>
        <div class="col-2"></div>

    </div>
</asp:Content>
