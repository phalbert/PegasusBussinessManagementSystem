﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListGeneralLedger.ascx.cs" Inherits="ListGeneralLedger" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
    <asp:View ID="SearchView" runat="server">
        <%-------------------------------------------- Message Label ----------------------------------%>
        <div class="row">
            <div class="text-center">
                <% 
                    string IsError = Session["IsError"] as string;
                    if (IsError == null)
                    {
                        Response.Write("<div>");

                    }
                    else if (IsError == "True")
                    {
                        Response.Write("<div class=\"alert alert-danger\">");

                    }
                    else
                    {
                        Response.Write("<div class=\"alert alert-success\">");
                    }
                %>
                <strong>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label></strong>
                <%Response.Write("</div>"); %>
            </div>
        </div>

        <!---------------------------------------------- Search Options --------------------------------->
        <div class="row">
            <div class="col-lg-2">
                <label>
                    Company
                </label>
                <asp:DropDownList ID="ddCompanies" runat="server" CssClass="form-control">
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <label>
                    Tran Category
                </label>
                <asp:DropDownList ID="ddTranCategories" runat="server" CssClass="form-control">
                    <asp:ListItem Value="ALL">ALL</asp:ListItem>
                    <asp:ListItem Value="TRUE">YES</asp:ListItem>
                    <asp:ListItem Value="FALSE">NO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <label>
                    Client/Supplier Name
                </label>
                <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control" placeholder="Enter text" />
            </div>
            <div class="col-lg-2">
                <label>
                    Start Date
                </label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" placeholder="Enter text" />
            </div>
            <div class="col-lg-2">
                <label>
                    End Date
                </label>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" placeholder="Enter text" />
            </div>
            <div class="col-lg-2" style="padding-top: 15px;">
                <asp:Button ID="btnSubmit" runat="server" Text="Search DB" CssClass="btn btn-success btn-lg"
                    OnClick="btnSubmit_Click" />
            </div>
        </div>

        <hr />
        <%------------------------------------------- Search Results  -----------------------------------%>
        <asp:MultiView runat="server" ID="Multiview2">
            <asp:View runat="server" ID="resultView">
                <div class="row">
                    <div class="table-responsive">
                        <asp:GridView runat="server" Width="100%" CssClass="table table-bordered table-hover"
                            ID="dataGridResults" OnRowCommand="dataGridResults_RowCommand">
                            <AlternatingRowStyle BackColor="#BFE4FF" />
                            <HeaderStyle BackColor="#115E9B" Font-Bold="false" ForeColor="white" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="30px" />
                            <Columns>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDetails" runat="server" Text="Details" CommandName="ViewDetails" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:View>

            <asp:View runat="server" ID="EmptyView">
            </asp:View>
        </asp:MultiView>
        <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
        <br />
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
            Format="yyyy-MM-dd" PopupPosition="BottomRight" TargetControlID="txtStartDate">
        </ajaxToolkit:CalendarExtender>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
            Format="yyyy-MM-dd" PopupPosition="BottomRight" TargetControlID="txtEndDate">
        </ajaxToolkit:CalendarExtender>
        <!------------------------------------------------- View2 -------------------------------------------------->
    </asp:View>
    <asp:View ID="View2" runat="server">
    </asp:View>
</asp:MultiView>
