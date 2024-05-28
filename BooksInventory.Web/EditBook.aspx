<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="BooksInventory.Web.EditBook"  MasterPageFile="~/Site.Master"%>
  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <h2>Edit Book</h2>
            <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" ItemType="BooksInventory.Web.Models.UpdateBook" SelectMethod="GetBook" UpdateMethod="UpdateBook" >
                <EditItemTemplate>
                    <div  style="margin:5px">
                        <span style="width: 150px; display: inline-block; text-align:right">Title</span>
                    <asp:TextBox ID="Title" runat="server" Text="<%# BindItem.Title %>">></asp:TextBox>
                    </div>
                    <div style="margin:5px">
                        <span style="width: 150px; display: inline-block; text-align:right">Author</span>
                    <asp:TextBox ID="Author" runat="server" Text="<%# BindItem.Author %>">></asp:TextBox>
                    </div>
                    <div style="margin:5px">
                        <span style="width: 150px; display: inline-block; text-align:right">ISBN</span>
                    <asp:TextBox ID="ISBN" runat="server" Text="<%# BindItem.ISBN %>">></asp:TextBox>
                    </div>
                    <div style="margin:5px">
                        <span style="width: 150px; display: inline-block; text-align:right">Publication Year</span>
                    <asp:TextBox ID="PublicationYear" runat="server" Text="<%# BindItem.PublicationYear %>" TextMode="Number">></asp:TextBox>
                   </div>
                     <div style="margin:5px">
                         <span style="width: 150px; display: inline-block; text-align:right">Quantity</span>
                        <asp:TextBox ID="TextBox1" runat="server" Text="<%# BindItem.Quantity %>" TextMode="Number">></asp:TextBox>
                    </div>
                     <div style="margin:5px">
                         <span style="width: 150px; display: inline-block; text-align:right">Category</span>
 <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue="<%# BindItem.CategoryId %>" DataTextField="Name" DataValueField="Id" ItemType="BooksInventory.Web.Models.Category" DataSource="<%# Categories %>">
 </asp:DropDownList>
                         </div>
                    <div>
                    <span style="width: 350px; display: inline-block; text-align:right">
                        <a href="Books.aspx" style="margin-right:210px">Back</a>
                        <asp:Button runat="server" ID="btnSave" Text="Save" CommandName="Update"/>
                    </span>
                    </div>
                </EditItemTemplate>
            </asp:FormView>
        </div>
 </asp:Content>