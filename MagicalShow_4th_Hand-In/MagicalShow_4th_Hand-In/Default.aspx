<%@ Page Language="C#" Inherits="MagicalShow_4th_HandIn.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
    <link rel="stylesheet" media="screen" href="template.css" />
</head>
<body>
    <div class="center">
    	<form id="form1" runat="server">
    		<asp:GridView ID="GridViewShops" runat="server" EmptyDataText="No data" OnSelectedIndexChanged="GridViewShops_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField HeaderText="Your choise" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Button id="BackendArea" runat="server" Text="Backend Area" OnClick="button1Clicked" />
    	</form>
    </div>
</body>
</html>
