<%@ Page Title="" Language="C#" MasterPageFile="~/E-Stock.Master" AutoEventWireup="true" CodeBehind="stockReg.aspx.cs" Inherits="E_Stock.stockReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mx-auto mt-1" style="width: 100%;">
        <div class="card-header bg-black bg-opacity-75 text-white">
            <h4 class="card-title fw-bold">Stock Registration</h4>
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
                    <label for="ddlVendorName" class="col-sm-3 col-form-label">Select Vendor Name</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlVendorName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlVendorName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-1">
                    <label for="txtMobile" class="col-sm-3 col-form-label">Vendor Mobile</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-1">
                    <label for="ddlProduct" class="col-sm-3 col-form-label">Select Product</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                </div>

                <div class="col-sm-9 offset-sm-3 mb-1">
                    <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>

                <div class="row mb-1">
                    <label for="txtCost" class="col-sm-3 col-form-label">Cost</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtCost" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-1">
                    <label for="txtQuantity" class="col-sm-3 col-form-label">Quantity</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-9 offset-sm-3 mb-1">
                    <asp:Button ID="btnCalc" runat="server" Text="Calculate" CssClass="btn btn-outline-dark" OnClick="btnCalc_Click" />
                </div>

                <div class="row mb-1">
                    <label for="txtAmount" class="col-sm-3 col-form-label">Total Amount</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-1">
                    <label for="txtStockCount" class="col-sm-3 col-form-label">Stock Count</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtStockCount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-9 offset-sm-3 mb-1">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-outline-secondary" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-outline-dark" OnClick="btnShow_Click" />
                </div>

                <div class="table-responsive">
                <asp:GridView ID="grdStock" runat="server" ShowFooter="true" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdID" runat="server" ReadOnly="true" Text='<%#Eval("id") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name">
                            <FooterTemplate>
                                <span class="fw-bold text-center">Total</span>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdProduct" runat="server" ReadOnly="true" Text='<%#Eval("product") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalStock" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdStock" runat="server" Text='<%#Eval("stock") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <FooterTemplate>
                                <asp:Label ID="lblFinalTotal" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdTotal" runat="server" ReadOnly="true" Text='<%#Eval("totalstock") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnHistory" runat="server" Text="View History" OnClick="btnHistory_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            </div>

            <div class="table-responsive">
                <asp:GridView ID="grdHistory" runat="server" ShowFooter="True" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <HeaderTemplate>
                                <asp:Label ID="lblgrdPost" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdid" runat="server" Text='<%#Eval("id") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vendor Name">
                            <FooterTemplate>
                                <span class="fw-bold text-center">Sum Footer</span>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdVendor" runat="server" Text='<%#Eval("vendor") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost">
                            <FooterTemplate>
                                <asp:Label ID="lblSumCost" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdCost" runat="server" Text='<%#Eval("cost") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <FooterTemplate>
                                <asp:Label ID="lblTotalQuantity" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdQty" runat="server" Text='<%#Eval("qty") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <FooterTemplate>
                                <asp:Label ID="lblAllTotal" runat="server"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgrdTotal" runat="server" Text='<%#Eval("total") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnQtyUpdate" runat="server" Text="Update" OnClick="btnQtyUpdate_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
