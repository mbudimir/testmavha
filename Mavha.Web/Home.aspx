<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Listado de Personas</div>
        <asp:GridView ID="gvPersonas" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateSelectButton="True" EnableModelValidation="True">
            <RowStyle BackColor="White" BorderStyle="Solid" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" />
        </asp:GridView>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
        <asp:Button ID="btnEditar" runat="server" Text="Editar" />
        <asp:Button ID="btnAnular" runat="server" Text="Anular" />
    </form>
</body>
</html>
