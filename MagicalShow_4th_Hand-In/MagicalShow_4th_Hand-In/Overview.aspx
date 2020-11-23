<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="MagicalShow_4th_HandIn.Overview" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Magic Show Overview</title>
    <link rel="stylesheet" media="screen" href="template.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <asp:Button ID="buttonNewAct" CssClass="fltLft" runat="server" OnClick="ButtonNewAct_Click" Text="New act" />
            <asp:Button ID="buttonNewProfile" CssClass="fltLft" runat="server" OnClick="ButtonNewProfile_Click" Text="New profile" />
            <asp:Button ID="logOut" CssClass="fltRght" runat="server" OnClick="Logout_Click" Text="Logout" />
            <asp:ListBox ID="Profiles" runat="server"></asp:ListBox>
            <asp:ListBox ID="Acts" runat="server"></asp:ListBox>
            <asp:Button ID="buttonEditProfile" CssClass="fltLft" runat="server" OnClick="ButtonEditProfile_Click" Text="Edit profile" />
            <asp:Button ID="buttonDeleteProfile" CssClass="fltRght" runat="server" OnClick="ButtonDeleteProfile_Click" Text="Delete profile" />
            <asp:Button ID="buttonEditAct" CssClass="fltLft" runat="server" OnClick="ButtonEditAct_Click" Text="Edit act" />
            <asp:Button ID="buttonDeleteAct" CssClass="fltRght" runat="server" OnClick="ButtonDeleteAct_Click" Text="Delete act" />
            <asp:Button ID="buttonMoveUp" CssClass="fltLft" runat="server" OnClick="ButtonMoveUp_Click" Text="Move Up /\ " />
            <asp:Button ID="buttonMoveDown" CssClass="fltRght" runat="server" OnClick="ButtonMoveDown_Click" Text="Move Down \/ " />
        </div>
    </form>
</body>
</html>
