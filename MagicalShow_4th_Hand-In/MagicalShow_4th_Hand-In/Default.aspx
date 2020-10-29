<%@ Page Language="C#" Inherits="MagicalShow_4th_HandIn.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:GridView ID="GridViewShops" runat="server" EmptyDataText="No data" OnSelectedIndexChanged="GridViewShops_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="Your choise" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button id="button1" runat="server" Text="Click me!" OnClick="button1Clicked" />
	</form>
</body>
</html>
