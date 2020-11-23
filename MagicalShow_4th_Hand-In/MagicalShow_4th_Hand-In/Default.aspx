<%@ Page Language="C#" Inherits="MagicalShow_4th_HandIn.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
    <link rel="stylesheet" media="screen" href="template.css" />
</head>
<body>
    <div class="center">
    	<asp:Label id="TotalDuration" runat="server"></asp:Label>
            
        <asp:DataList ID="dtlist" runat="server" RepeatColumns = "2"  Width = "500px">
            <ItemTemplate>
                <div class="act">
                    <h1><asp:Label runat="server" Text='<%# Eval("Act_Title") %>'></asp:Label></h1>
                    <asp:Label runat="server" Text='<%# "#"+Eval("Program_SequenceNumber")+": "+Eval("Act_Duration")+" minutes" %>'></asp:Label>
                    <br/>
                    <asp:Image id="Image1" CssClass="actImage" runat="server" ImageUrl='<%# "Images/"+Eval("Act_Picture") %>' />
                    <br/>
                    <asp:Label id="Label1" runat="server" Text='<%# Eval("Magician_ArtistName")+" performs" %>'></asp:Label>
                    <br/>
                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("Act_Sdesc") %>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
            
        <form id="form1" runat="server">
            <asp:Button id="BackendArea" runat="server" Text="Backend Area" OnClick="button1Clicked" />
        </form>
    </div>
</body>
</html>
