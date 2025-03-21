using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessObject;

namespace E_Stock
{
    public partial class vendorReg : System.Web.UI.Page
    {
        UserBL bl = new UserBL();
        UserBO bo = new UserBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bo.ID = int.Parse(txtID.Text);
            bo.VendorName = txtName.Text;
            bo.City = ddlCity.SelectedValue;
            bo.Address = txtAddress.Text;
            bo.Mobile = txtMobile.Text;

            string valVendor = bl.validateVendorName(bo);
            if (valVendor != txtName.Text)
            {
                int returnval = 0;
                
                returnval = bl.saveVendor(bo);
                Response.Write("<script>alert('Vendor Added')</script>");
                txtID.Text = "";
                txtName.Text = "";
                ddlCity.SelectedIndex = 0;
                txtAddress.Text = "";
                txtMobile.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Vendor Already Exist')</script>");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            display();
        }
        protected void display()
        {
            grdVendor.DataSource = bl.showVendorL();
            grdVendor.DataBind();
        }
        protected void btnGUpdate_Click(object sender, EventArgs e)
        {
            int returnval = 0;
            GridViewRow gr1 = ((Button)sender).NamingContainer as GridViewRow;
            TextBox txtGName = gr1.FindControl("txtGName") as TextBox;
            DropDownList ddlGStatus = gr1.FindControl("ddlGStatus") as DropDownList;

            if (ddlGStatus.SelectedIndex != 0)
            {
                bo.VendorName = txtGName.Text;
                bo.Status = ddlGStatus.SelectedValue;
                returnval = bl.updtVendor(bo);
                Response.Write("<script>alert('Vendor Updated')</script>");
                display();
            }
            else
            {
                Response.Write("<script>alert('Plese Select Status.')</script>");
            }
        }

        protected void btnGDelete_Click(object sender, EventArgs e)
        {
            GridViewRow gr1 = ((Button)sender).NamingContainer as GridViewRow;
            int returnval = 0;
            TextBox txtGName = gr1.FindControl("txtGName") as TextBox;
            bo.VendorName = txtGName.Text;
            returnval = bl.removeVendor(bo);
            Response.Write("<script>alert('Vendor Deleted')</script>");
            display();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFindMobile.Text != "")
            {
                bo.Mobile = txtFindMobile.Text;
                grdVendor.DataSource = bl.findVendor(bo);
                grdVendor.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Plese Enter Number.')</script>");
            }
        }
    }
}