<%@ Page Title="" Language="C#" MasterPageFile="~/E-Stock.Master" AutoEventWireup="true" CodeBehind="sellList.aspx.cs" Inherits="E_Stock.sellList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mx-auto mt-1" style="width: 100%;">
            <div class="card-header bg-black bg-opacity-75 text-white">
                <h4 class="card-title fw-bold">Product Selling List</h4>
            </div>
            <div class="card-body">
                <div class="col-md-11 container1">
                    <div class="row mb-1">
                        <label for="txtID" class="col-sm-3 col-form-label">Enter ID</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-1">
                        <label for="ddlProduct" class="col-sm-3 col-form-label">Select Product</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mb-1">
                        <label for="txtMCost" class="col-sm-3 col-form-label">Max Purchase Cost</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtMCost" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-1">
                        <label for="txtSCost" class="col-sm-3 col-form-label">Enter Sell Cost</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtSCost" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-1">
                        <label for="txtCurrentStock" class="col-sm-3 col-form-label">Current Stock</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtCurrentStock" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-1">
                        <label for="txtDate" class="col-sm-3 col-form-label">Date</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-9 offset-sm-3 mb-1">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-outline-secondary" OnClick="btnSubmit_Click"/>
                        <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-outline-dark" OnClick="btnShow_Click"/>
                    </div>
                </div>

                <div class="table-responsive">
                <asp:GridView ID="grdSelling" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product">
                            <ItemTemplate>
                                <asp:Label ID="lblproduct" runat="server" Text='<%#Eval("product") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Max Cost">
                            <ItemTemplate>
                                <asp:Label ID="lblmaxcost" runat="server" Text='<%#Eval("maxcost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Selling Cost">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSellCost" runat="server" Text='<%#Eval("sellcost") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock">
                            <ItemTemplate>
                                <asp:Label ID="lblStock" runat="server" Text='<%#Eval("cstock") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
        </div>
</asp:Content>
