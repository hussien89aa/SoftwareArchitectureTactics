<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pannel.aspx.cs" Inherits="Authentication.Pannel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <a href="Login.aspx"> Sign out</a>
            <br />
            <asp:Literal ID="LAuthenticat" runat="server"></asp:Literal>
        <br />

    </div>
    </form>
</body>
</html>
