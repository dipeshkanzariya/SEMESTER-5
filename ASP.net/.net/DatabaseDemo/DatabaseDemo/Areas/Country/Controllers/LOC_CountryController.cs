using DatabaseDemo.Areas.Country.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseDemo.Areas.Country.Controllers
{
    [Area("Country")]
    public class LOC_CountryController : Controller
    {
        public IConfiguration Configuration;

        public LOC_CountryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult LOC_CountryList()
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_SelectAll";

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();
                return View("LOC_CountryList",dt);
        }

        /*public IActionResult From()
        {
            return View("LOC_CountrySave");
        }*/

        public IActionResult LOC_CountrySave(LOC_CountryModel cm)
        {
            string connecction_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connecction_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if(cm.CountryID == 0)
            {
                cmd.CommandText = "PR_LOC_Country_Insert";
            }
            else
            {
                cmd.CommandText = "PR_LOC_Country_UpdateByPK";
                cmd.Parameters.AddWithValue("@CountryID", cm.CountryID);
            }
            cmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
            cmd.Parameters.AddWithValue("@CountryCode", cm.CountryCode);
            cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("LOC_CountryList");
        }

        public IActionResult LOC_CountryAddEdit(int? CountryID = 0)
        {
            string connecction_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connecction_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_SelectByPK";
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt =  new DataTable();
            dt.Load(reader);

            LOC_CountryModel cm = new LOC_CountryModel();

            foreach(DataRow row in dt.Rows) 
            {
                cm.CountryID = Convert.ToInt32(row["CountryID"]);
                cm.CountryName = row["CountryName"].ToString();
                cm.CountryCode = row["CountryCode"].ToString();
            }

            return View("LOC_CountryAddEdit", cm);
        }

        public IActionResult DeleteCountry(int CountryID)
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_DeleteByPK";
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("LOC_CountryList");
        }
    }
}
