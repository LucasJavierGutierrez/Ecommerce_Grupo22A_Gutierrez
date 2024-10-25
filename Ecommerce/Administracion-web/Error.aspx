<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="administracion_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
        <h1 style="color:grey; font-family:Arial;">Hubo un problema</h1>
        <asp:Label Text="" Style="color:red;" ID="lblError" runat="server" />
    </div>
    <div style="text-align:center;width:30px;">
        <img src="../img/error.png" alt="Alternate Text" />
    </div>

</asp:Content>
