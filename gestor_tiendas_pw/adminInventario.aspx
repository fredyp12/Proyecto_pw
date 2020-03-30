<%@ Page Title="" Language="C#" MasterPageFile="~/sidenav.Master" AutoEventWireup="true" CodeBehind="adminInventario.aspx.cs" Inherits="gestor_tiendas_pw.adminInventario" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/geneic.css" rel="stylesheet" />
     <link href="styles/crud.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cpmtaimer">
        <div class="row py-3 pl-3">
            <h2>Inventario</h2>
        </div>
        <div class="row">
            <div class="col-5">
                <asp:DropDownList ID="drop_tienda" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT [nombre] FROM [tienda]"></asp:SqlDataSource>
            </div>
            <div class="col-7">
                <asp:GridView ID="grid_inventario" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="grid_inventario_SelectedIndexChanged" AllowPaging="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="producto" HeaderText="producto" SortExpression="producto" />
                        <asp:BoundField DataField="tienda" HeaderText="tienda" SortExpression="tienda" />
                        <asp:BoundField DataField="cantidad" HeaderText="cantidad" SortExpression="cantidad" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [inventario] WHERE ([tienda] = @tienda)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drop_tienda" Name="tienda" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="col-5">
                <div class="input-group">
                    <label class="label_group">Producto</label>
                    <asp:TextBox ID="txt_producto" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Cantidad</label>
                    <asp:TextBox ID="txt_cantidad" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col">
                <asp:Button ID="btn_add" class="btn_bn col-8 btn btn-primary" runat="server" Text="Adicionar" OnClick="btn_add_Click" />
                <asp:Button ID="btn_update" class="btn_bn col-8 btn btn-primary" runat="server" Text="Actualizar" OnClick="btn_update_Click" />
                <asp:Button ID="btn_delete" class="btn_bn col-8 btn btn-primary" runat="server" Text="Eliminar" OnClick="btn_delete_Click" />
            </div>
        </div>
        <p class="pt-3 pl-3 title row ">Productos</p>
        <div class="row">
            <div class="col-md-5">
                <asp:GridView ID="grid_producto" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [producto]"></asp:SqlDataSource>
            </div>
            <div class="col-3">
                <asp:Button ID="btn_add_p" class="btn_bn btn btn-primary" runat="server" Text="Adicionar" OnClick="btn_add_p_Click" />
                <asp:Button ID="btn_update_p" class="btn_bn btn btn-primary" runat="server" Text="Editar" OnClick="btn_update_p_Click" />
                <asp:Button ID="btn_delete_p" class="btn_bn btn btn-primary" runat="server" Text="Eliminar" OnClick="btn_delete_p_Click" />
            </div>
            <div class="col-4">
                <div class="input-group">
                    <label class="label_group">Nombre</label>
                    <asp:TextBox ID="txt_nombre_p" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Precion</label>
                    <asp:TextBox ID="txt_precio" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
