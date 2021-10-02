using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    // this is entity class 
    // Having all the field which is create in DB 
    public class InventoryEntity
    {
        private int Product_id;
        private string Product_name;
        private string Product_info;
        private string Product_MD;
        private string Product_ED;
        private int Product_price;

        public int ID
        {
            get { return Product_id; }
            set { Product_id = value; }
        }

        public string Name
        {
            get { return Product_name; }
            set { Product_name = value; }
        }
        public string Info
        {
            get { return Product_info; }
            set { Product_info = value; }
        }
        public string MD
        {
            get { return Product_MD; }
            set { Product_MD = value; }
        }
        public string ED
        {
            get { return Product_ED; }
            set { Product_ED = value; }
        }
        public int Price
        {
            get { return Product_price; }
            set { Product_price = value; }
        }
    }
}
