using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessObject;
using System.Data;

namespace E_Stock
{
    public partial class sellList : System.Web.UI.Page
    {
        UserBL bl = new UserBL();
        UserBO bo = new UserBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }
        }

        protected void display()
        {
            DataTable dtProduct = bl.LoadProduct();
            ddlProduct.DataSource = dtProduct;
            ddlProduct.DataTextField = "product";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, "Select");

            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bo.ID = int.Parse(txtID.Text);
            bo.Product = ddlProduct.SelectedValue;
            bo.Cost = int.Parse(txtMCost.Text);
            bo.Selling_Price = int.Parse(txtSCost.Text);
            bo.Stock_Count = int.Parse(txtCurrentStock.Text);
            bo.Date = txtDate.Text;

            int result = 0;
            if (bo.Selling_Price > bo.Cost)
            {
                result = bl.saveSellingProduct(bo);
                Response.Write("<script>alert('Data Added...')</script>");
            }
            else
            {
                Response.Write("<script>alert('Data Adding Fails...')</script>");
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            displayGrid();
        }
        protected void displayGrid()
        {
            grdSelling.DataSource = bl.getSellingProduct();
            grdSelling.DataBind();
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            bo.Product = ddlProduct.SelectedValue;
            bl.ProductDetails(bo);
            txtMCost.Text = bo.Cost.ToString();
            txtCurrentStock.Text = bo.Stock_Count.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int returnval = 0;
            GridViewRow gr1 = ((Button)sender).NamingContainer as GridViewRow;
            TextBox txtSellCost = gr1.FindControl("txtSellCost") as TextBox;
            Label lblproduct = gr1.FindControl("lblproduct") as Label;
            bo.Selling_Price = int.Parse(txtSellCost.Text);
            bo.Product = lblproduct.Text;
            returnval = bl.updtSellingPrice(bo);
            Response.Write("<script>alert('Data Updated...')</script>");
            displayGrid();
        }
    }
}