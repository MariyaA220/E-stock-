using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class UserBL
    {
        public int saveVendor(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.addVendor(objBO1);
        }

        public object showVendorL()
        {
            //GRIDVIEW DISPLAY
            UserDA da = new UserDA();
            return da.showVendor();
        }        public object findVendor(UserBO objBO1)
        {
            //GRIDVIEW DISPLAY
            UserDA da = new UserDA();
            return da.seachVendor(objBO1);
        }        public int removeVendor(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.deleteVendor(objBO1);
        }        public int updtVendor(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.updateVendor(objBO1);
        }
        public string validateVendorName(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.validateVendor(objBO1);
        }

        public DataTable LoadAll()
        {
            UserDA da = new UserDA();
            return da.DropLoadAll();
        }

        public DataTable LoadProduct()
        {
            UserDA da = new UserDA();
            return da.DropProduct();
        }

        public string getVendorMobile(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.getMobile(objBO1);
        }
        
        public int getStockCount(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.StockCount(objBO1);
        }

        public int saveStock(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.addStock(objBO1);
        }

        public int saveStockSummary(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.addStockSummary(objBO1);
        }

        public object showStockSummaryL()
        {
            //GRIDVIEW DISPLAY
            UserDA da = new UserDA();
            return da.showStockSummary();
        }
        
        public void ProductDetails(UserBO objBO1)
        {
            UserDA da = new UserDA();
            da.getProductDetails(objBO1);
        }

        public int saveSellingProduct(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.addSellingProduct(objBO1);
        }
        public object getSellingProduct()
        {
            UserDA da = new UserDA();
            return da.showSellingProduct();
        }

        public int updtSellingPrice(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.updateSellingPrice(objBO1);
        }
        public int updtStockSummary(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.updateStockSummary(objBO1);
        }
        public int updtStock(UserBO objBO1)
        {
            UserDA da = new UserDA();
            return da.updatestock(objBO1);
        }
    }
}
