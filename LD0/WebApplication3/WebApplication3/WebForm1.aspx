<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Naujas įrašas:"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox><br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Įvesti" OnClick="Button1_Click" /><br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Egzistuojantys įrašai:"></asp:Label><br />
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" Height="70px" Width="400px">
            </asp:Table>
        </div>
    </form>
</body>
</html>
