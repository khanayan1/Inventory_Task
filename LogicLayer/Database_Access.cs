using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
   public  class Database_Access
    {
        //this is ths connection string 
        SqlConnection con = new SqlConnection("Server = DESKTOP-HOSMNQP; Database=test;Trusted_Connection=True");
        List<InventoryEntity> inventory_data = new List<InventoryEntity>();
        // All Store-procedures which is store in Database
        private const string getdetails = "getinventory";
        private const string get_byid = "getinventory_byid";
        private const string Insert = "Insert_data";
        private const string delete = "delete_data";
        private const string update = "Update_data";

        // Method for getting all details from the DB
        public List<InventoryEntity> GetInventoryEntities()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(getdetails, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            con.Close();
            da.Fill(ds);
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                InventoryEntity inventory = new InventoryEntity();
                inventory.ID = Convert.ToInt32(ds.Rows[i]["Product_id"]);
                inventory.Name = ds.Rows[i]["Product_name"].ToString();
                inventory.Info = ds.Rows[i]["Product_info"].ToString();
                inventory.MD = ds.Rows[i]["Product_MD"].ToString();
                inventory.ED = ds.Rows[i]["Product_ED"].ToString();
                inventory.Price = Convert.ToInt32(ds.Rows[i]["Product_price"]);
                inventory_data.Add(inventory);
            }
            return inventory_data;
        }

        // Getting Inventory data with specific ID
        public List<InventoryEntity> GetInventoryEntities_byid(int id)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(get_byid, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            con.Close();
            da.Fill(ds);
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                InventoryEntity inventory = new InventoryEntity();
                inventory.ID = Convert.ToInt32(ds.Rows[i]["Product_id"]);
                inventory.Name = ds.Rows[i]["Product_name"].ToString();
                inventory.Info = ds.Rows[i]["Product_info"].ToString();
                inventory.MD = ds.Rows[i]["Product_MD"].ToString();
                inventory.ED = ds.Rows[i]["Product_ED"].ToString();
                inventory.Price = Convert.ToInt32(ds.Rows[i]["Product_price"]);
                inventory_data.Add(inventory);
            }
            return inventory_data;
        }

        // Method use for insert the data into DB
        public void Insert_Data(int id,string name,string info, string md , string ed, int price)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Insert, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@info", info);
            cmd.Parameters.AddWithValue("@md", md);
            cmd.Parameters.AddWithValue("@ed", ed);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Method use for delete the data with respect to given id 
        public void Delete_Data(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Use for update the Inventory data using id
        public void Update_Data(int id, string name, string info, string md, string ed, int price)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@info", info);
            cmd.Parameters.AddWithValue("@md", md);
            cmd.Parameters.AddWithValue("@ed", ed);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
