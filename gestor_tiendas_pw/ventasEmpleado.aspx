<%@ Page Title="" Language="C#" MasterPageFile="~/sideEmpleado.Master" AutoEventWireup="true" CodeBehind="ventasEmpleado.aspx.cs" Inherits="gestor_tiendas_pw.ventasEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="row">Ventas</h2>
    <p class="title">Ventas Realizadas<asp:GridView ID="grid_ventas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="grid_ventas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
            <asp:BoundField DataField="producto" HeaderText="producto" SortExpression="producto" />
            <asp:BoundField DataField="empleado" HeaderText="empleado" SortExpression="empleado" />
            <asp:BoundField DataField="tienda" HeaderText="tienda" SortExpression="tienda" />
        </Columns>
        </asp:GridView>
    </p>
    <asp:Label runat="server" Text="Label" ID="lbl"></asp:Label>

    <asp:DropDownList ID="drop_inventario" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="drop_date" runat="server" DataTextField="fecha" DataValueField="fecha">
    </asp:DropDownList>

</asp:Content>
