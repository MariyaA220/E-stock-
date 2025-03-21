using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLogic;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;

namespace E_Stock
{
    public partial class stockReg : System.Web.UI.Page
    {
        UserBL bl = new UserBL();
        UserBO bo = new UserBO();
        string product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bo.ID = int.Parse(txtID.Text);
            bo.VendorName = ddlVendorName.SelectedValue;
            bo.Mobile = txtMobile.Text;
            bo.Cost = int.Parse(txtCost.Text);
            bo.Quantity = int.Parse(txtQuantity.Text);
            bo.Total = int.Parse(txtAmount.Text);
            bo.Stock_Count = int.Parse(txtStockCount.Text);
            bo.Total_Stock = int.Parse(txtCost.Text) * int.Parse(txtStockCount.Text);

            if (ddlProduct.SelectedValue != "Add New Product")
            {
               
                bo.Product = ddlProduct.SelectedValue;
            }
            else
            {
                bo.Product = txtProduct.Text;
            }
            int returnval, returnval1 = 0;
            returnval = bl.saveStock(bo);
            returnval1 = bl.saveStockSummary(bo);
            Response.Write("<script>alert('Stock Added')</script>");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            grdStock.DataSource = bl.showStockSummaryL();
            grdStock.DataBind();
        }

        protected void display()
        {
            DataTable dtState = bl.LoadAll();
            ddlVendorName.DataSource = dtState;
            ddlVendorName.DataTextField = "name";
            ddlVendorName.DataBind();
            ddlVendorName.Items.Insert(0, "Select");

            DataTable dtProduct = bl.LoadProduct();
            ddlProduct.DataSource = dtProduct;
            ddlProduct.DataTextField = "product";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, "Select");
            ddlProduct.Items.Add("Add New Product");

        }

        protected void ddlVendorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bo.VendorName = ddlVendorName.SelectedValue;
            txtMobile.Text = bl.getVendorMobile(bo);
        }
        

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlProduct.SelectedValue == "Add New Product")
            {
                txtProduct.Visible = true;
            }
            else
            {
                txtProduct.Visible = false;
            }
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
            txtAmount.Text = (int.Parse(txtCost.Text) * int.Parse(txtQuantity.Text)).ToString();
            if (ddlProduct.SelectedValue != "Add New Product")
            {
                int newStockCount = int.Parse(txtQuantity.Text);
                bo.Product = ddlProduct.SelectedValue;
                int oldStockCount = bl.getStockCount(bo);
                txtStockCount.Text = (newStockCount + oldStockCount).ToString();
            }
            else
            {
                txtStockCount.Text = txtQuantity.Text;
            }
        }
        

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            GridViewRow gr1 = ((Button)sender).NamingContainer as GridViewRow;
            TextBox txtgrdProduct = gr1.FindControl("txtgrdProduct") as TextBox;
            bo.Product = txtgrdProduct.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["myDB"]);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM stockDB WHERE product = @product", con);
            com.Parameters.AddWithValue("product", bo.Product);
            SqlDataReader dr = com.ExecuteReader();
            grdHistory.DataSource = dr;
            grdHistory.DataBind();
            dr.Close();
            grdHistory.HeaderRow.Cells[0].Text = bo.Product;
            product = bo.Product;
        }

        protected void btnQtyUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow gr1 = ((Button)sender).NamingContainer as GridViewRow;
            bo.Product = product;
            int oldstock = bl.getStockCount(bo);
            TextBox txtgrdQty = gr1.FindControl("txtgrdQty") as TextBox;
            TextBox txtgrdCost = gr1.FindControl("txtgrdCost") as TextBox;
            TextBox txtgrdTotal = gr1.FindControl("txtgrdTotal") as TextBox;
            int newstock = int.Parse(txtgrdQty.Text);

            int stockcal = oldstock + newstock;
            int newtotal = (newstock * int.Parse(txtgrdCost.Text)) + int.Parse(txtgrdTotal.Text);

            bo.Quantity = stockcal;
            bo.Stock_Count = stockcal;
            bo.Total = newtotal;
            bo.Total_Stock = newtotal;

            bl.updtStockSummary(bo);
            bl.updtStock(bo);
            Response.Write("Stock Updated");


        }
    }
}