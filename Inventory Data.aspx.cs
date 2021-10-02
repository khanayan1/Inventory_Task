using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryProject
{
    public partial class Inventory_Data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InventoryEntity entity = new InventoryEntity();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/");

            var api = hc.GetAsync("values");
            api.Wait();
            var data = api.Result;
            if(data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<List<InventoryEntity>>();
                display.Wait();
                GridView1.DataSource = display.Result;
                GridView1.DataBind();

            }


        }
    }
}