<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="SupplyPortal.AdminPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Portal</title>
    <link href="Stylesheets/AdminPage.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
        <form id="form1" runat="server">
    <div class="banner">
    <h1>Admin Portal</h1>
                  <div class="tab">
            <asp:button CssClass="optionTabs" runat="server" ID="AddUserTab" Text="Add User" OnClick="AddUserTab_Click"></asp:button>
            <asp:button CssClass="optionTabs" runat="server" Text="Delete User" ID="DeleteUserTab" OnClick="DeleteUserTab_Click"></asp:button>
            <asp:button CssClass="optionTabs" runat="server" Text="Edit User" ID="EditUserTab" OnClick="EditUserTab_Click"></asp:button>
        </div>  
    </div>
    <div class="content">



        <div class="inputPanel">
            <asp:Label CssClass="tablenamelabel" ID="TableName" runat="server"></asp:Label>
        <asp:Table CssClass="inputtables" ID="AddUserTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="230px">Username</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="100px">Role</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="355px">Email</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell><asp:TextBox CssClass="textbox" Width="230px" ID="UsernameTextBox" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox CssClass="textbox" Width="100px" ID="RoleTextBox" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox CssClass="textbox" Width="355px" ID="EmailTextBox" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Button ID="SubmitButton" runat="server" OnClick="addUserButton_Click" Text="Add" Font-Size="20px" Width="100px" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
            <asp:Table CssClass="deleteinputtable" ID="DeleteUserTable" runat="server">
                <asp:TableHeaderRow Width="230px"><asp:TableHeaderCell>Username</asp:TableHeaderCell><asp:TableHeaderCell></asp:TableHeaderCell></asp:TableHeaderRow>
                <asp:TableRow><asp:TableCell><asp:TextBox CssClass="textbox" ID="UserToDelTextBox" runat="server" Width="230px"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Button ID="deleteButton" runat="server" OnClick="deleteButton_Click" Text="Delete" Font-Size="20px" Width="100px" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table CssClass="inputtables" ID="EditUserTable" runat="server">
                <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="230px">Username</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="100px">Role</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="355px">Email</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell><asp:TextBox CssClass="textbox" Width="230px" ID="EditUserTextBox" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox Enabled="false" CssClass="textbox" Width="100px" ID="EditRoleTextBox" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox Enabled="false" CssClass="textbox" Width="355px" ID="EditEmailTextBox" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Button Visible="true" ID="editButton" runat="server" OnClick="editUserButton_Click" Text="Edit" Font-Size="20px" Width="100px" />
                    <asp:Button Visible="false" ID="saveEditButton" runat="server" OnClick="saveEditUserButton_Click" Text="Save" Font-Size="20px" Width="100px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
                            
        <asp:Label CssClass="resultlabel" ID="ResultLabel" runat="server"></asp:Label>
        </div>
        
        <section class="gridview1">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" HeaderStyle-Width="250px" />
                <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" HeaderStyle-Width="100px" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" HeaderStyle-Width="400px" />
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
            </section>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [UserName], [Role], [Email] FROM [Users] ORDER BY [UserName]"></asp:SqlDataSource>
    
    </div>
            </form>
</body>
</html>
