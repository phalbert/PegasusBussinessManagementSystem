<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ManageSaleItems.aspx.cs" Inherits="ManageSaleItems" %>

<%@ Register TagPrefix="uc" TagName="ListSaleItemsUserControl" Src="~/ListSaleItems.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="margin-top:30px;">
        <asp:MultiView ActiveViewIndex="0" ID="MultiView" runat="server">
            <asp:View ID="ListSaleItemsView" runat="server">
                <uc:ListSaleItemsUserControl ID="ListSaleItemsUserControl" runat="server" />
            </asp:View>
            <asp:View ID="SaveRecieptView" runat="server">
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
