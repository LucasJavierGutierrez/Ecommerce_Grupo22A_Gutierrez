<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SolicitudesDevoluciones.aspx.cs" Inherits="Administracion_web.SolicitudesDevoluciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .gridview-style {
            font-size: 12px;
            color: #333;
            background-color: #fff;
            border: 1px solid #ccc;
            border-collapse: collapse;
        }

            .gridview-style th {
                background-color: #eee;
                font-weight: bold;
            }

            .gridview-style td {
                border: 1px solid #ccc;
                padding: 5px;
            }

            .gridview-style tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .gridview-style tr:nth-child(odd) {
                background-color: #e6f3ff;
            }
    </style>
    <script type="text/javascript">
        function mostrarAlerta() {
            alert('¡Botón presionado!');
        }
    </script>
    <div class="row">
        <hr />
        <asp:GridView runat="server" ID="dgvSolicitudesDeDevolucion" Style="width: 60%;" AutoPostBack="false" OnClass="table" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-success table-striped" OnRowCommand="dgvSolicitudesDeDevolucion_RowCommand1">

            <Columns>
                <asp:BoundField HeaderText="#id" DataField="Id" />
                <asp:BoundField HeaderText="#Venta" DataField="IdVenta" />
                <asp:BoundField HeaderText="Nombre" DataField="usuario.Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="usuario.Apellido" />
                <asp:BoundField HeaderText="Email" DataField="usuario.Email" />
                <asp:BoundField HeaderText="Producto" DataField="producto.Nombre" />
                <asp:BoundField HeaderText="Color" DataField="color.Nombre" />
                <asp:BoundField HeaderText="Motivo" DataField="motivo" ItemStyle-Width="50%"/>
                <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                <asp:ButtonField Text="Aceptar" ControlStyle-CssClass="btn btn-success" CommandName="Boton1" />
                <asp:ButtonField Text="Cancelar" ControlStyle-CssClass="btn btn-danger" CommandName="Boton2" />

            </Columns>
        </asp:GridView>
    </div>
    <asp:Label Text="" ID="lblPrueba" runat="server" />
</asp:Content>
