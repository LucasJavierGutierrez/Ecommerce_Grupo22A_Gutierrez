<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Administracion_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <table class="table">
                <asp:Repeater runat="server" ID="repetidor">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("item.Nombre")%>

                            </td>
                            <td>
                                <%#Eval("Color.Nombre")%>               

                            </td>
                            <td>
                                <asp:Label ID="lblSubTotal" runat="server" Text='<%#Eval("subtotal") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="btn-toolbar justify-content-between" role="toolbar" aria-label="Toolbar with button groups">
                                    <div class="btn-group" role="group" aria-label="First group">
                                        <asp:Button Text="+" ID="btnInc" type="Button" AutoPostback="true" OnClick="btnInc_Click" class="btn btn-secondary" CommandArgument='<%#Eval("Id")+ ","+ Eval("color.Id")%>' runat="server" />
                                        <asp:Button Text='<%#Eval("cantidad")%>' type="text" CssClass="btn btn-secondary" AutoPostBack="true" CommandArgument='<%#Eval("Id")%>' runat="server" />
                                        <asp:Button Text="-" ID="btnDec" type="Button" CssClass="btn btn-secondary" AutoPostBack="true" OnClick="btnDec_Click" CommandArgument='<%#Eval("Id")+ ","+ Eval("color.Id")%>' runat="server" />
                                    </div>
                                </div>

                            </td>
                            <td>
                                <asp:Button Text="-" CssClass="btn btn-danger" ID="btnEliminar2" AutoPostBack="true" OnClick="btnEliminar2_Click" CommandArgument='<%#Eval("ID")%>' runat="server" />
                            </td>
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <asp:Label Text="" ID="lblPrecioTotal" runat="server" />
            <div style="padding-top: 30px;">
                <asp:Button Text="Comprar" CssClass="btn btn-success" ID="btnComprar" OnClick="btnComprar_Click" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
