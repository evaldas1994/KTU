<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            Konkurso dalyvio registracija<br />
            <br />
            Vardas:<br />
            Amžius:<br />
            Programavimo kalba:<br />
            <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Vardas yra privalomas" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
            </asp:DropDownList>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Neteisinga metų reikšmė" ForeColor="Red" MaximumValue="25" MinimumValue="14" Type="Integer">*</asp:RangeValidator>
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="pavadinimas" DataValueField="pavadinimas" Width="150px">
            </asp:CheckBoxList>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/kalbos.xml"></asp:XmlDataSource>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Registruotis" OnClick="Button1_Click" Width="150px" />
        </div>
    </form>
</body>
</html>
