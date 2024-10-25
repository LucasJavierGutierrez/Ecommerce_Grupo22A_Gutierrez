<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ErrorLogin.aspx.cs" Inherits="Administracion_web.ErrorLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
        <h1>Hubo un problema!</h1>
        <asp:Label Text="" ID="lblErrorLogin" Style="color: red;" runat="server" />
        
    </div>
    <div style="text-align:center;">
        <img src="../img/errorLogin.png" alt="Error" />
    </div>

</asp:Content>
