<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs"  Inherits="_1_4_Gissa_det_hemliga_talet._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Style.css" rel="stylesheet" />
    <title>Gissa det hemliga talet</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Gissa talet!</h1>
        <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 - 100"></asp:Label>
    
        <div>
        <asp:TextBox ID="Input" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Input" ErrorMessage="Ange ett tal mellan 1 och 100" Display="Dynamic" Type="Integer" MaximumValue="100" MinimumValue="1"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Input" runat="server" ErrorMessage="Du måste skriva något!" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />


        <asp:PlaceHolder ID="sendHolder" Visible="true" runat="server">
        <asp:Button ID="SendGuess" runat="server" Text="Send" OnClick="SendGuess_Click" />
        </asp:PlaceHolder>
            
            
            <asp:PlaceHolder ID="myPlaceHolder" runat="server" Visible="false">
                <asp:Button ID="Restart" runat="server" Text="Restart" />
            </asp:PlaceHolder>
        <div>
        <asp:Label ID="AmountOfGuesslabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
        <asp:Label ID="GuessLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
        <asp:Label ID="HighOrLowLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
        <div>
            <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
