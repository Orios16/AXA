<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Polizas.aspx.cs" Inherits="AXA_WEB.Polizas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista de productos</title>
    <link rel="stylesheet" href="css/general.css">
</head>
<body>
    <table id="tbl-productos" class="tabla-informacion">
        <thead>
            <tr>
                <th>Código</th>
                <th>Producto</th>
                <th>Precio</th>
                <th>Descripción</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <script src="https://unpkg.com/axios/dist/axios.min.js"></script>
    <script src="js/productos-servicio.js"></script>
    <script src="js/lista-productos-controlador.js"></script>
</body>
</html>
</asp:Content>