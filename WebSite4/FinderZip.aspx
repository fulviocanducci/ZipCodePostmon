<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinderZip.aspx.cs" Inherits="FinderZip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        p, div {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TxtZipCode" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
        <div>
            <asp:Button ID="BtnFind" runat="server" Text="Buscar" OnClick="BtnFind_Click" />
        </div>
        <asp:Panel ID="PanelStatus" runat="server" Visible="false">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Logradouro ou Rua"></asp:Label>
                <p><asp:Literal ID="LtlAddress" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Cidade:"></asp:Label>
                <p><asp:Literal ID="LtlCity" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Cidade Informação"></asp:Label>
                <p><asp:Literal ID="LtlCityAreaKm2" runat="server"></asp:Literal></p>
                <p><asp:Literal ID="LtlCityCodeIbge" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Código Postal:"></asp:Label>
                <p><asp:Literal ID="LtlCodePostal" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Complemento:"></asp:Label>
                <p><asp:Literal ID="LtlComplement" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label6" runat="server" Text="Bairro:"></asp:Label>
                <p><asp:Literal ID="LtlDistrict" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label7" runat="server" Text="UF:"></asp:Label>
                <p><asp:Literal ID="LtlUF" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Label ID="Label8" runat="server" Text="UF Informação:"></asp:Label>
                <p><asp:Literal ID="LtlUFName" runat="server"></asp:Literal></p>
                <p><asp:Literal ID="LtlUFAreadKm2" runat="server"></asp:Literal></p>
                <p><asp:Literal ID="LtlUFCodeIbge" runat="server"></asp:Literal></p>
            </div>
        </asp:Panel>        
    </form>
</body>
</html>
