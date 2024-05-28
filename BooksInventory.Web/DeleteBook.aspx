<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="BooksInventory.Web.DeleteBook" MasterPageFile="~/Site.Master"%>
  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h2>Edit Book</h2>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="325px">
               
            </asp:DetailsView>
        </div>
    <div style="margin-top:10px">
      <span style="width: 325px; display: inline-block; text-align:right">
      <a href="Books.aspx" style="margin-right:210px">Back</a>
      <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
      </span>
    </div>
        
</asp:Content>