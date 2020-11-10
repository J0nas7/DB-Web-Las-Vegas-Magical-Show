<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMagician.aspx.cs" Inherits="MagicalShow_4th_HandIn.CreateMagician" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Magician</title>
    <link rel="stylesheet" media="screen" href="template.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <asp:Button ID="GoToOverview" runat="server" OnClick="GoToOverview_Click" Text="Go back" />
            <br/>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxArtistName" runat="server"></asp:TextBox>
            <asp:Label ID="LabelArtistName" runat="server" Text="Artist Name"></asp:Label>
            <br/><small>(Leave empty if you are not a magician)</small>
            <br />
            <br />
            <asp:RadioButtonList ID="RdBtnProfileType" runat="server">
                <asp:ListItem Text="Magician" Value="magician" />
                <asp:ListItem Text="Manager" Value="manager" />
                <asp:ListItem Text="Secretary" Value="secretary" />
            </asp:RadioButtonList>
            <asp:Label ID="LabelProfileType" runat="server" Text="Profile Type"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add person and return" />
            <br />
            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
