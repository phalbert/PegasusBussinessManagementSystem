﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SaveSystemUser.ascx.cs" Inherits="SaveSystemUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
    <asp:View ID="CaptureDetailsView" runat="server">
        <div id="page-wrapper">

            <div class="container-fluid">

                <div class="row">

                    <%------------------------------------------ Message Label ----------------------------------------%>
                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-10 text-center">
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
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </strong>
                            <%Response.Write("</div>"); %>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>

                    <div class="container">

                        <%--------------------------------------- Form  ------------------------------------------%>
                        <div class="col-lg-2"></div>

                        <div class="col-lg-8">

                            <div class="panel panel-success">

                                <div class="panel-heading text-center">
                                    SUPPLY SYSTEM USER DETAILS USING THE FORM BELOW
                                </div>

                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label>Company Code</label>
                                            <asp:DropDownList ID="ddCompanies" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="TRUE">YES</asp:ListItem>
                                                <asp:ListItem Value="FALSE">NO</asp:ListItem>
                                            </asp:DropDownList>
                                            <p class="help-block">The Name of the Company</p>
                                        </div>
                                        <div class="col-lg-6">
                                            <label>UserType</label>
                                           <asp:DropDownList ID="ddUserTypes" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="TRUE">YES</asp:ListItem>
                                                <asp:ListItem Value="FALSE">NO</asp:ListItem>
                                            </asp:DropDownList>
                                            <p class="help-block">The Name of the Client</p>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label>Name</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter text" />
                                            <p class="help-block">The Name of the Company</p>
                                        </div>
                                        <div class="col-lg-6">
                                            <label>UserID</label>
                                            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" placeholder="Enter text" />
                                            <p class="help-block">Brief Summary of what Contract Covers</p>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label>Email</label>
                                            <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control" placeholder="Enter text" />
                                            <p class="help-block">The Name of the Company</p>
                                        </div>
                                        <div class="col-lg-6">
                                            <label>Is Activated</label>
                                            <asp:DropDownList ID="ddIsActive" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="TRUE">YES</asp:ListItem>
                                                <asp:ListItem Value="FALSE">NO</asp:ListItem>
                                            </asp:DropDownList>
                                            <p class="help-block">The Code to be associated with the Client. Unique Identifier for Client</p>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label>Send Email with Credentials</label>
                                            <asp:DropDownList ID="ddSendEmail" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="YES">YES</asp:ListItem>
                                                <asp:ListItem Value="NO">NO</asp:ListItem>
                                            </asp:DropDownList>
                                            <p class="help-block">Send an Email with Credentials</p>
                                        </div>
                                    </div>

                                    

                                </div>

                                <div class="panel-footer">
                                    <div class="text-center">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" Width="200px" CssClass="btn btn-success btn-lg" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnEdit" runat="server" Text="Save" Width="200px" CssClass="btn btn-success btn-lg" OnClick="btnEdit_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-lg-2"></div>
                    </div>
                </div>
            </div>
        </div>
    </asp:View>

    <%------------------------------------------------------------ Confirm View ------------------------------- --%>
    <asp:View ID="ConfirmView" runat="server">
        <div class="container">
            <div class="text-center">
                <div class="row" style="padding-top: 70px;">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-8">
                        <div class="alert alert-info">
                            This Company Already Exists! Are you sure you want to Update it.
                        </div>
                    </div>
                    <div class="col-lg-2"></div>
                </div>
                <hr />
                <div class="row">
                    <asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-success" Text="Confirm Operation" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel Operation" OnClick="btnCancel_Click" />
                </div>
            </div>
            <hr />
        </div>
    </asp:View>
</asp:MultiView>