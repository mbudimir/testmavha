<%@ Page Language="VB" AutoEventWireup="false" CodeFile="wfNuevaPersona.aspx.vb" Inherits="wfNuevaPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        </div>
                <div>
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
                <div>
            <asp:Label ID="Label3" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
        </div>
                <div>
            <asp:Label ID="Label4" runat="server" Text="Sexo"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" runat="server">
                        <asp:ListItem Value="1">Masculino</asp:ListItem>
                        <asp:ListItem Value="2">Femenino</asp:ListItem>
                    </asp:DropDownList>
        </div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </form>
</body>
</html>
