<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs"  Inherits="_1_4_Gissa_det_hemliga_talet._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Gissa talet!</h1>
    <div>

        <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 - 100"></asp:Label>
        <asp:TextBox ID="Input" runat="server"></asp:TextBox>
        <asp:Button ID="SendGuess" runat="server" Text="Send" OnClick="SendGuess_Click" />

    </div>
        <div>
            <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
