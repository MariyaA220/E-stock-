using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class UserDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["myDB"]);
        SqlCommand com;
        SqlDataAdapter sda;
        SqlDataReader dr;
        public int addVendor(UserBO objBO)
        {
            com = new SqlCommand("InsertVendor", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", objBO.ID);
            com.Parameters.AddWithValue("name", objBO.VendorName);
            com.Parameters.AddWithValue("city", objBO.City);
            com.Parameters.AddWithValue("address", objBO.Address);
            com.Parameters.AddWithValue("mobile", objBO.Mobile);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }

        public object showVendor()
        {
            con.Open();
            DataSet ds = new DataSet();
            com = new SqlCommand("SELECT * from vendorDB", con);
            sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            return ds;
        }        public int deleteVendor(UserBO objBO)
        {
            com = new SqlCommand("DeleteVendorByName", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", objBO.VendorName);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }        public int updateVendor(UserBO objBO)
        {
            com = new SqlCommand("UpdateVendorStatus", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", objBO.VendorName);
            com.Parameters.AddWithValue("status", objBO.Status);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }        public object seachVendor(UserBO objBO)
        {
            con.Open();
            DataSet ds = new DataSet();
            com = new SqlCommand("GetVendorByMobile", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("mobile", objBO.Mobile);
            sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            return ds;
        }        public string validateVendor(UserBO objBO)
        {
            string valname = "";
            com = new SqlCommand("GetVendorByName", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", objBO.VendorName);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                valname = dr["name"].ToString();
            }
            return valname;
        }        public DataTable DropLoadAll()
        {
            com = new SqlCommand("GetUnblockedVendors", con);
            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            com.CommandType = CommandType.Text;
            dr = com.ExecuteReader();
            DataTable dt = null;
            dt = new DataTable("vendorDB");
            dt.Load(dr);
            return dt;
        }        public DataTable DropProduct()
        {
            com = new SqlCommand("SELECT DISTINCT product FROM stockDB", con);
            con.Open();
            com.CommandType = CommandType.Text;
            dr = com.ExecuteReader();
            DataTable dt = null;
            dt = new DataTable("product");
            dt.Load(dr);
            return dt;
        }        public string getMobile(UserBO objBO)
        {
            string mobile = "";
            com = new SqlCommand("GetMobileByName", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", objBO.VendorName);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                mobile = dr["mobile"].ToString();
            }
            dr.Close();
            return mobile;
        }        public int StockCount(UserBO objBO)
        {
            int oldstock = 0;
            com = new SqlCommand("GetMaxScountByProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@product", objBO.Product);
            con.Open();
            oldstock = int.Parse(com.ExecuteScalar().ToString());
            return oldstock;
        }        public int addStock(UserBO objBO)
        {
            com = new SqlCommand("InsertStock", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", objBO.ID);
            com.Parameters.AddWithValue("vendor", objBO.VendorName);
            com.Parameters.AddWithValue("mobile", objBO.Mobile);
            com.Parameters.AddWithValue("product", objBO.Product);
            com.Parameters.AddWithValue("cost", objBO.Cost);
            com.Parameters.AddWithValue("qty", objBO.Quantity);
            com.Parameters.AddWithValue("total", objBO.Total);
            com.Parameters.AddWithValue("scount", objBO.Stock_Count);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }        public int addStockSummary(UserBO objBO)
        {
            com = new SqlCommand("InsertStockSummary", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", objBO.ID);
            com.Parameters.AddWithValue("product", objBO.Product);
            com.Parameters.AddWithValue("stock", objBO.Stock_Count);
            com.Parameters.AddWithValue("totalstock", objBO.Total_Stock);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }        public int updateStockSummary(UserBO objBO)
        {
            com = new SqlCommand("UPDATE stock_summary SET stock=@stock, totalstock=@totalstock WHERE product = @product", con);
            com.Parameters.AddWithValue("product", objBO.Product);
            com.Parameters.AddWithValue("stock", objBO.Stock_Count);
            com.Parameters.AddWithValue("totalstock", objBO.Total_Stock);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }        public int updatestock(UserBO objBO)
        {
            com = new SqlCommand("UPDATE stockDB SET qty= @qty , total =@total WHERE product= @product", con);
            com.Parameters.AddWithValue("product", objBO.Product);
            com.Parameters.AddWithValue("qty", objBO.Quantity);
            com.Parameters.AddWithValue("total", objBO.Total);
            com.Parameters.AddWithValue("scount", objBO.Stock_Count);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }        public object showStockSummary()
        {
            con.Open();
            DataSet ds = new DataSet();
            com = new SqlCommand("SELECT * from stock_summary", con);
            sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            return ds;
        }        
        public void getProductDetails(UserBO objBO)
        {
            con.Open();
            com = new SqlCommand("GetMaxScountAndCostByProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("product", objBO.Product);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                objBO.Cost = int.Parse(dr["cost"].ToString());
                objBO.Stock_Count = int.Parse(dr["max_scount"].ToString());
            }
        }

        public int addSellingProduct(UserBO objBO)
        {
            com = new SqlCommand("InsertSellRecord", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", objBO.ID);
            com.Parameters.AddWithValue("product", objBO.Product);
            com.Parameters.AddWithValue("maxcost", objBO.Cost);
            com.Parameters.AddWithValue("sellcost", objBO.Selling_Price);
            com.Parameters.AddWithValue("cstock", objBO.Stock_Count);
            com.Parameters.AddWithValue("date", objBO.Date);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }

        public object showSellingProduct()
        {
            con.Open();
            DataSet ds = new DataSet();
            com = new SqlCommand("SELECT * from sellDB", con);
            sda = new SqlDataAdapter(com);
            sda.Fill(ds);
            return ds;
        }

        public int updateSellingPrice(UserBO objBO)
        {
            com = new SqlCommand("UpdateSellCost", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("product", objBO.Product);
            com.Parameters.AddWithValue("sellcost", objBO.Selling_Price);
            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }
    }
}
