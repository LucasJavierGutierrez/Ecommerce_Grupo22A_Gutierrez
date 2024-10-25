<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="Administracion_web.stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
        <div class="col-4"></div>
        <div class="col" style="text-align:center;">
            <h3 style="color:grey;">stock</h3>
            <p>Por favor ingrese la cantidad de stock...</p>
            <asp:TextBox Text="" CssClass="form-control" ID="txtStock" runat="server" />
            <asp:Button OnClick="btnSumarStock_Click" ID="btnSumarStock" cssClass="btn btn-success" Text="+" runat="server" />
            <asp:Button OnClick="btnRestarStock_Click" Id="btnRestarStock" cssClass="btn btn-danger"  Text="-" runat="server" />
        </div>
        <div class="col-4" style="padding-top:82px;">
            
            
            <asp:Button ID="btnAplicar" OnClick="btnAplicar_Click" cssClass="btn btn-outline-success" Text="Aplicar" runat="server" />
        </div>

    </div>
    
</asp:Content>
