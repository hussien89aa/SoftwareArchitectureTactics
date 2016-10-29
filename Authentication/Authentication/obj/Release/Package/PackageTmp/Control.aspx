<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="Authentication.Control" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li>  <a href="Pannel.aspx"> Go Back</a></li>
            <li> <a href="Login.aspx"> Sign out</a></li>
        </ul>
       
        
            <h1>Your account authorize you to add Bus</h1>
    <h1> Add new Bus</h1>
        <table style="width:100%;">
            <tr  >
                <td class="auto-style1">Bus Name</td>
                <td>
                    <asp:TextBox ID="txtBusName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Bus Driver</td>
                <td>
                    <asp:TextBox ID="txtBusDriver" runat="server"  ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="buAdd" runat="server" Text="Add" OnClick="buAdd_Click"  />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
