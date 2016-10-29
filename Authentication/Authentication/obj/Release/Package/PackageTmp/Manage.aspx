<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Authentication.Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul>
            <li>  <a href="Pannel.aspx"> Go Back</a></li>
            <li> <a href="Login.aspx"> Sign out</a></li>
        </ul>
        <h1>Your account authorize you to manage Bus only</h1>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElearningConnectionString %>" DeleteCommand="DELETE FROM [Bus] WHERE [BusID] = @BusID" InsertCommand="INSERT INTO [Bus] ([BusName], [BusDriver]) VALUES (@BusName, @BusDriver)" SelectCommand="SELECT * FROM [Bus]" UpdateCommand="UPDATE [Bus] SET [BusName] = @BusName, [BusDriver] = @BusDriver WHERE [BusID] = @BusID">
            <DeleteParameters>
                <asp:Parameter Name="BusID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="BusName" Type="String" />
                <asp:Parameter Name="BusDriver" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="BusName" Type="String" />
                <asp:Parameter Name="BusDriver" Type="String" />
                <asp:Parameter Name="BusID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="BusID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="BusID" HeaderText="BusID" InsertVisible="False" ReadOnly="True" SortExpression="BusID" />
                <asp:BoundField DataField="BusName" HeaderText="BusName" SortExpression="BusName" />
                <asp:BoundField DataField="BusDriver" HeaderText="BusDriver" SortExpression="BusDriver" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
