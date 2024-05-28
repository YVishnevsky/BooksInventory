<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BooksInventory.Web.Books" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <p style="font-weight:900"><span style="width: 20px; display: inline-block;">Id</span>
                       <span style="width: 150px; display: inline-block;">Author</span>
                       <span style="width: 300px; display: inline-block;">Title</span>
                       <span style="width: 120px; display: inline-block;">ISBN</span>
                       <span style="width: 60px; display: inline-block;">Year</span>
                       <span style="width: 50px; display: inline-block;">Qty</span>
                       <span style="width: 200px; display: inline-block;">Category</span>
                    </p>
                </HeaderTemplate>
             <ItemTemplate>
                <p><span style="width: 20px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "Id") %></span>
                   <span style="width: 150px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "Author") %></span>
                   <span style="width: 300px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "Title") %></span>
                   <span style="width: 120px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "ISBN") %></span>
                   <span style="width: 60px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "PublicationYear") %></span>
                   <span style="width: 50px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "Quantity") %></span>
                   <span style="width: 200px; display: inline-block;"><%# DataBinder.Eval(Container.DataItem, "CategoryName") %></span>
                   <asp:HyperLink style="width: 50px; display: inline-block;" runat="server" ID="editButton" NavigateUrl='<%# Eval("Id", "~/EditBook.aspx?id={0}") %>'>Edit</asp:HyperLink>
                   <asp:HyperLink style="width: 50px; display: inline-block;" runat="server" ID="deleteButton" NavigateUrl='<%# Eval("Id", "~/DeleteBook.aspx?id={0}") %>'>Delete</asp:HyperLink>
                </p>
            </ItemTemplate>
            </asp:Repeater>
        </div>
         </asp:Content>

