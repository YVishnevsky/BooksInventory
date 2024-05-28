<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="BooksInventory.Web.DeleteBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
               
            </asp:DetailsView>
        </div>
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
        
    </form>
</body>
</html>
