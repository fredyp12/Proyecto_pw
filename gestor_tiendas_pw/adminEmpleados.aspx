<%@ Page Title="" Language="C#" MasterPageFile="~/sidenav.Master" AutoEventWireup="true" CodeBehind="adminEmpleados.aspx.cs" Inherits="gestor_tiendas_pw.adminEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/geneic.css" rel="stylesheet" />
    <link href="styles/crud.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cpmtaimer">
        <div class="row py-3 pl-3">
            <h2>Empleados</h2>
        </div>
        <div class="row">
            <div class="col-8">
                <asp:GridView ID="grid_empleado" runat="server" DataSourceID="SqlDataSourceEmpleado" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True" OnSelectedIndexChanged="grid_empleado_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                        <asp:BoundField DataField="user" HeaderText="user" SortExpression="user" />
                        <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
                        <asp:BoundField DataField="tienda" HeaderText="tienda" SortExpression="tienda" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceEmpleado" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [empleado]"></asp:SqlDataSource>
            </div>
            <div class="col">
                <div class="input-group">
                    <label class="label_group">Id</label>
                    <asp:TextBox ID="txt_id" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Nombre</label>
                    <asp:TextBox ID="txt_nombre" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Usuario</label>
                    <asp:TextBox ID="txt_usuario" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Clave</label>
                    <asp:TextBox ID="txt_pass" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <label class="label_group">Tienda</label>
                    <asp:TextBox ID="txt_tienda" class="form-control mt-4" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row pt-3 pl-2">
            <asp:Button ID="btn_add" class="btn_bn col-3 btn btn-primary" runat="server" Text="Adicionar" OnClick="btn_add_Click" />
            <asp:Button ID="btn_update" class="btn_bn col-3 btn btn-primary" runat="server" OnClick="btn_update_Click" Text="Actualizar" />
            <asp:Button ID="btn_delete" class="btn_bn col-3 btn btn-primary" runat="server" OnClick="btn_delete_Click" Text="Eliminar" />
        </div>
    </div>
</asp:Content>
