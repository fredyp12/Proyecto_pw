<%@ Page Title="" Language="C#" MasterPageFile="~/sideEmpleado.Master" AutoEventWireup="true" CodeBehind="ventasEmpleado.aspx.cs" Inherits="gestor_tiendas_pw.ventasEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/geneic.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="row">Ventas</h2>
    <p class="title">Ventas Realizadas</p>
    <div class="row">
        <div class="col-8">
            <asp:GridView ID="grid_ventas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="grid_ventas_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                    <asp:BoundField DataField="producto" HeaderText="producto" SortExpression="producto" />
                    <asp:BoundField DataField="empleado" HeaderText="empleado" SortExpression="empleado" />
                    <asp:BoundField DataField="tienda" HeaderText="tienda" SortExpression="tienda" />
                    <asp:BoundField DataField="cantidad" HeaderText="cantidad" SortExpression="tienda" />
                    <asp:BoundField DataField="total" HeaderText="total" SortExpression="tienda" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col">
            <asp:Label runat="server" Text="Fecha" ID="lbl"></asp:Label>
            <asp:DropDownList ID="drop_date" runat="server" DataTextField="fecha" DataValueField="fecha">
            </asp:DropDownList>
            <asp:Button ID="btn_filtro" class="btn_bn btn btn-primary" runat="server" Text="Filtrar" OnClick="btn_filtro_Click" />
            <asp:Button ID="btn_all" class="btn_bn btn btn-primary" runat="server" Text="Todo" OnClick="btn_all_Click" />
        </div>
    </div>
    <p class="title row pl-3">Crear nueva venta</p>
    <div class="row pt-3 pl-3">
        <div class="col-4 div_venta">
            <span class="form_des">Producto</span>
            <asp:DropDownList ID="drop_inventario" calss="dropdown" runat="server">
            </asp:DropDownList>
        </div>
        <div class="input-group col-4">
            <label class="label_group">Fecha</label>
            <asp:TextBox ID="txt_fecha" class="form-control mt-4" runat="server"></asp:TextBox>
        </div>
        <div class="input-group col-4">
            <label class="label_group">Cantidad</label>
            <asp:TextBox ID="txt_cantidad" class="form-control mt-4" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row d-flex justify-content-center">
            <asp:Button ID="btn_add" class="btn_bn btn btn-primary col-5" runat="server" Text="Adicionar" OnClick="btn_add_Click" />
        </div>

</asp:Content>
