<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MagicalShow_4th_HandIn.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to Backend Area</title>
    <link rel="stylesheet" media="screen" href="template.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <br />
            <asp:Button ID="buttonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
            <asp:Label ID="LabelLoginMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
