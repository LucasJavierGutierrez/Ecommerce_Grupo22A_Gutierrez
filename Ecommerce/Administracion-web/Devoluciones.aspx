<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Devoluciones.aspx.cs" Inherits="Administracion_web.Devoluciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <br />
        <hr />
        <div class="col">
            <div class="mb-3">
                <asp:Label Text="Producto(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlProducto" AutoPostBack="true" OnDataBound="ddlProducto_DataBound" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Color(*)" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlColor" Enabled="false" AutoPostBack="true" CssClass="form-select" OnDataBound="ddlColor_DataBound" OnSelectedIndexChanged="ddlColor_SelectedIndexChanged" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <asp:Label Text="Cantidad(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="1" ID="txtCantidad" Enabled="false" step="1" AutoPostBack="true" Type="Number" CssClass="form-control" runat="server" />
                <asp:Label Text="" ID="lblErrorCantidadStock" Style="color: red;" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Escribe el motivo de devolucion(*)" CssClass="form-label" runat="server" />
                <asp:TextBox Text="" ID="txtMotivo" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <div>
                <asp:Button Text="+" CssClass="btn btn-success" ID="btnSumarProductoDevolucion" OnClick="btnSumarProductoDevolucion_Click" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-6">
            <br />
            <table>

                <tr>
                    <td style="padding-right: 150px;"><b>Producto</b> </td>
                    <td style="padding-right: 140px;"><b>Color</b> </td>
                    <td style="padding-right: 100px;"><b>Cantidad</b> </td>
                </tr>
            </table>
            <table>
                <asp:Repeater runat="server" ID="tabla_productos">
                    <ItemTemplate>

                        <tr>
                            <td style="padding-right: 200px;"><%#Eval("producto.Nombre")%> </td>
                            <td style="padding-right: 200px;"><%#Eval("color.Nombre") %></td>
                            <td style="padding-right: 80px;"><%#Eval("cantidad") %></td>
                            <td>
                                <asp:Button Text="-" ID="btnEliminarProductoLista" OnClick="btnEliminarProductoLista_Click" CssClass="btn btn-danger" AutoPostback="true" CommandArgument='<%#Eval("producto.Id")+ ","+ Eval("color.Id")%>' runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
            <br />
            <br />

        </div>
        <div style="text-align: center; padding-top:50px;">
            <asp:Button Text="Realizar solicitud de devolución" ID="btnEnviarSolicitud" OnClick="btnEnviarSolicitud_Click" CssClass="btn btn-success" runat="server" />
            <asp:Label Text="" style="color:red;" ID="lblSinProductosLista" runat="server" />
        </div>

    </div>
</asp:Content>
