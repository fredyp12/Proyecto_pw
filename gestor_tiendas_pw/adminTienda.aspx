<%@ Page Title="" Language="C#" MasterPageFile="~/sidenav.Master" AutoEventWireup="true" CodeBehind="adminTienda.aspx.cs" Inherits="gestor_tiendas_pw.adminTienda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="styles/geneic.css" rel="stylesheet" />
    <link href="styles/crud.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cpmtaimer">
        <div class="row py-3 pl-3">
            <h2>Tienda</h2>
        </div>
        <div class="row">
            <div class="col-8">
                <asp:GridView ID="grid_tienda" runat="server" AutoGenerateColumns="False" DataKeyNames="nombre" DataSourceID="SqlDataSource1" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" ReadOnly="True" SortExpression="nombre" />
                    <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" />
                </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tienda]"></asp:SqlDataSource>
            </div>
            <div class="col">
                <div class="input-group">
                    <label class="label_group">Nombre</label>
                    <asp:TextBox ID="txt_nombre" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Dirección</label>
                    <asp:TextBox ID="txt_direccion" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btn_add" class="btn_bn col-3 btn btn-primary" runat="server" Text="Adicionar" OnClick="btn_add_Click" />
            <asp:Button ID="btn_update" class="btn_bn col-3 btn btn-primary" runat="server" Text="Actualizar" OnClick="btn_update_Click" />
            <asp:Button ID="btn_delete" class="btn_bn col-3 btn btn-primary" runat="server" Text="Eliminar" OnClick="btn_delete_Click" />
        </div>

    </div>
</asp:Content>
