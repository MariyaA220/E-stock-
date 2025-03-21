<%@ Page Title="" Language="C#" MasterPageFile="~/E-Stock.Master" AutoEventWireup="true" CodeBehind="vendorReg.aspx.cs" Inherits="E_Stock.vendorReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mx-auto mt-1">
        <div class="card-header bg-black bg-opacity-75 text-white">
            <h4 class="card-title fw-bold">Vendor Registration</h4>
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
                    <label for="txtName" class="col-sm-3 col-form-label">Enter Vendor Name</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-1">
                    <label for="txtCity" class="col-sm-3 col-form-label">Enter City</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AutoPostBack="True">
                            <asp:ListItem>Select City</asp:ListItem>
                            <asp:ListItem>Nagpur</asp:ListItem>
                            <asp:ListItem>Pune</asp:ListItem>
                            <asp:ListItem>Mumbai</asp:ListItem>
                            <asp:ListItem>Pune</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="row mb-1">
                    <label for="txtAddress" class="col-sm-3 col-form-label">Enter Address</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-1">
                    <label for="txtMobile" class="col-sm-3 col-form-label">Enter Mobile</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-9 offset-sm-3 mt-2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-outline-secondary" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-outline-dark" OnClick="btnShow_Click" />
                </div>

                <div class="mb-3 mt-3 row">
                    <label for="txtFindMobile" class="col-sm-3 col-form-label">Enter Venodr Mobile</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtFindMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <asp:Button ID="btnFind" runat="server" Text="Find" CssClass="btn btn-outline-dark" OnClick="btnFind_Click" />
                    </div>
                </div>

            </div>

            <div class="table-responsive">
                <asp:GridView ID="grdVendor" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGID" runat="server" Text='<%#Eval("id") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGName" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGCity" runat="server" Text='<%#Eval("city") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGAddress" runat="server" Text='<%#Eval("address") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGMobile" runat="server" Text='<%#Eval("mobile") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlGStatus" runat="server">
                                    <asp:ListItem>Select Status</asp:ListItem>
                                    <asp:ListItem>BLOCK</asp:ListItem>
                                    <asp:ListItem>UNBLOCK</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGUpdate" runat="server" Text="Update" OnClick="btnGUpdate_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGDelete" runat="server" Text="Delete" OnClick="btnGDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
