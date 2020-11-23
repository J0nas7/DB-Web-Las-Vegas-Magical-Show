<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Act.aspx.cs" Inherits="MagicalShow_4th_HandIn.Act" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Act Management</title>
    <link rel="stylesheet" media="screen" href="template.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <asp:Button ID="GoToOverview" runat="server" OnClick="GoToOverview_Click" Text="Go back" />
            <br/>
            <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
            <asp:Label ID="LabelTitle" runat="server" Text="Title"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxShortDescription" runat="server"></asp:TextBox>
            <asp:Label ID="LabelShortDescription" runat="server" Text="Short Description"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxDuration" runat="server"></asp:TextBox>
            <asp:Label ID="LabelDuration" runat="server" Text="Duration in minutes"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPicLink" runat="server"></asp:TextBox>
            <asp:Label ID="LabelPicLink" runat="server" Text="Link to a Picture"></asp:Label>
            <br />
            <br />
            <asp:Image ID="ActImage" runat="server" Width="200px" /><br/>
            <asp:Label ID="LabelActImage" runat="server" Text="Chosen Image"></asp:Label>    
            <br />
            <br />
            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add act and return" />
            <asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" Text="Save changes" />
            <br />
            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:FileUpload ID="ImageUpload" runat="server" />
            <asp:Label ID="LabelImageUpload" runat="server" Text="Choose Image"></asp:Label>
            <br/>
            <asp:Button ID="ButtonImage" runat="server" OnClick="ImageUpload_Click" Text="Upload Image" />
                
            <asp:DataList ID="dtlist" runat="server" RepeatColumns = "2"  RepeatLayout = "Table"  Width = "500px">
                <ItemTemplate>
                    <br />
                    <table cellpadding = "5px" cellspacing = "0" class="dlTable">
                    <tr>
                    <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Name", "~/Images/{0}") %>' Width = "200px" />
                    <asp:Label id="Label1" runat="server" Text='<%# Bind("Name", "{0}") %>'></asp:Label>
                    </td>
                    </tr>
                    </table>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
