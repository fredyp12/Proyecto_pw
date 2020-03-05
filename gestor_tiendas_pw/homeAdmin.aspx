<%@ Page Title="" Language="C#" MasterPageFile="~/sidenav.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="gestor_tiendas_pw.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center p-4">
            <span class="welcome pr-2">Bienvenido:</span>
            <asp:Label ID="lblBienvenido" class="welcome_dat" runat="server"></asp:Label>
        </div>
        <div class="row pt-5 px-5">
                <h3>Datos Generales</h3>
            </div>
        <div class="row px-5">
            <div class="col-6">
                <div class="row pt-5">
                    <div class="form">
                        <span class="form_des">Id:</span>
                        <asp:Label ID="lbl_id" class="lbl_dat" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row pt-3">
                    <div class="form">
                        <span class="form_des">Nombre:</span>
                        <asp:Label ID="lbl_name" class="lbl_dat" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row pt-3">
                    <div class="form">
                        <span class="form_des">Usuario:</span>
                        <asp:Label ID="lbl_user" class="lbl_dat" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="row pt-5">
                    <div class="col-6">
                        <asp:Button ID="btn_mostrar" class="btn btn-info" runat="server" Text="EDITAR" OnClick="btn_mostrar_Click" />
                    </div>
                    <div class="col-6">
                         <asp:Button ID="btn_update" class="btn btn-primary" runat="server" Text="ACTUALIZAR" OnClick="btn_update_Click" />
                    </div>
                </div>
                <div id="row_update" class="row pt-3">
                    <div class="form w-100">
                        <asp:Label ID="lbl_nombreU" class="form_des disN" runat="server">Nombre:</asp:Label>
                        <asp:TextBox ID="txt_nombre" class="form-control disN" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row pt-3">
                    <div class="form w-100">
                        <asp:Label ID="lbl_passU" class="form_des disN" runat="server">Contraseña:</asp:Label>
                        <asp:TextBox ID="txt_pass" class="form-control disN" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row py-3 mb-5">
                    <div class="form w-100">
                        <asp:Label ID="lbl_passCopyU" class="form_des disN" runat="server">Repetir Contraseña:</asp:Label>
                        <asp:TextBox ID="txt_passCopy" class="form-control disN" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
