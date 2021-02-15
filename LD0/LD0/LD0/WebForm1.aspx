<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LD0.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            width:80vw;
            height:100vh;
        }
        main {
            display:flex;
            flex-wrap: wrap;
            width: 40%;
            margin: 0 auto;
            border-sizing: border-box;
        }
        h1, span, input, select{
            width: 100%;
            padding: 0.3em 2em;
        }
        
        .form1 {
            display:flex;
            flex-wrap:wrap;
            align-content:baseline;
            justify-content:center;
            border-sizing: border-box;
        }

        #CheckBoxList1_0, #CheckBoxList1_1, #CheckBoxList1_2, #CheckBoxList1_3, #CheckBoxList1_4, #CheckBoxList1_5 {
            position:relative;
            top:1.3em;
        }

        #Button1 {
            width: 80%;
        }

        #CheckBoxList1 {
            margin-top: 1em;
            width: 100%;
        }

        #Table1, table {
            margin-top: 1em;
            width: 100%;
        }
    </style>
</head>
<body>
    <main>
        <section id="main-title">
            <h1>Konkurso dalyvio registracija:</h1>
        </section>
        <section id="main-form">
            <form id="form1" runat="server">
                <div class="form1">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />        
                    <asp:Label ID="Label1" runat="server" Text="Vardas ir pavardė"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Vardas yra privalomas" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Mokyklos pavadinimas:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Mokyklos pavadinimas yra privalomas" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>            
                    <asp:Label ID="Label3" runat="server" Text="Amžius:"></asp:Label>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Neteisinga metų reikšmė" ForeColor="Red" MaximumValue="25" MinimumValue="14" Type="Integer">*</asp:RangeValidator>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px"></asp:DropDownList>     
                    <asp:Label ID="Label4" runat="server" Text="Programavimo kalba:"></asp:Label>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="pavadinimas" DataValueField="pavadinimas" Width="200px"></asp:CheckBoxList>
                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/kalbos.xml"></asp:XmlDataSource>
                    <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Reset" OnClick="Button2_Click" />
                    <asp:Table ID="Table1" runat="server">
                    </asp:Table>
                </div>
            </form>
        </section>
    </main>
    
</body>
</html>
