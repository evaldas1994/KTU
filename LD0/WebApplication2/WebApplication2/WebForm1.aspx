<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Kūgio aukštinė, H"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged">0</asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Kūgio spindulys, R"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server">0</asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Kūgio spindulys, r"></asp:Label><br />
            <asp:TextBox ID="TextBox3" runat="server">0</asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Kūgio tūris"></asp:Label><br />
            <asp:TextBox ID="TextBox4" runat="server">0</asp:TextBox>
        </div>
        <div>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Skaičiuoti!" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
