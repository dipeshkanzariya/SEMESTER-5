using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Student_Registration_Theme.Areas.City.Models;
using Student_Registration_Theme.Areas.Country.Models;
using Student_Registration_Theme.Areas.State.Models;

namespace Student_Registration_Theme.Areas.City.Controllers
{
    [Area("City")]
    public class LOC_CityController : Controller
    {
        public IConfiguration Configuration;

        public LOC_CityController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult LOC_CityList()
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_SelectAll";

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View("LOC_CityList", dt);
        }

        public IActionResult LOC_CitySave(LOC_CityModel cm)
        {
            string connecction_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connecction_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (cm.CityID == 0)
            {
                cmd.CommandText = "PR_LOC_City_Insert";
            }
            else
            {
                cmd.CommandText = "PR_LOC_City_UpdateByPK";
                cmd.Parameters.AddWithValue("@CityID", cm.CityID);
            }
            cmd.Parameters.AddWithValue("@CityName", cm.CityName);
            cmd.Parameters.AddWithValue("@CityCode", cm.CityCode);
            cmd.Parameters.AddWithValue("@StateID", cm.StateID);
            cmd.Parameters.AddWithValue("@CountryID", cm.CountryID);
            cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("LOC_CityList");
        }

        public IActionResult LOC_CityAddEdit(int CityID = 0)
        {

            string connection_String = this.Configuration.GetConnectionString("MyConnectionString");

            if (CityID == 0)
            {
                // Insert

                SqlConnection connection12 = new SqlConnection(connection_String);
                connection12.Open();
                SqlCommand command12 = connection12.CreateCommand();
                command12.CommandType = CommandType.StoredProcedure;
                command12.CommandText = "PR_LOC_Country_ComboBox";
                SqlDataReader reader12 = command12.ExecuteReader();
                DataTable dt12 = new DataTable();
                dt12.Load(reader12);
                connection12.Close();

                List<LOC_Country_DropdownModel> list12 = new List<LOC_Country_DropdownModel>();

                foreach (DataRow dr in dt12.Rows)
                {
                    LOC_Country_DropdownModel model1 = new LOC_Country_DropdownModel();
                    model1.CountryID = Convert.ToInt32(dr["CountryID"]);
                    model1.CountryName = dr["CountryName"].ToString();
                    list12.Add(model1);
                }

                ViewBag.CountryList = list12;
                List<LOC_State_DropdownModel> list13 = new List<LOC_State_DropdownModel>();

                ViewBag.StateList = list13;
                return View();
            }
            SqlConnection connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_City_SelectByPK";
            command.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
            SqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            LOC_CityModel city = new LOC_CityModel();

            foreach (DataRow row in dt.Rows)
            {
                city.CityID = Convert.ToInt32(row["CityID"]);
                city.CityName = row["CityName"].ToString();
                city.CityCode = row["CityCode"].ToString();
                city.StateID = Convert.ToInt32(row["StateID"]);
                city.CountryID = Convert.ToInt32(row["CountryID"]);
            }

            string connection_String4 = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection connection4 = new SqlConnection(connection_String4);
            connection4.Open();
            SqlCommand command4 = connection.CreateCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "PR_State_StateByCountryID";
            command4.Parameters.AddWithValue("@CountryID", city.CountryID);

            SqlDataReader reader4 = command4.ExecuteReader();
            DataTable dt4 = new DataTable();
            dt4.Load(reader4);
            connection4.Close();

            List<LOC_State_DropdownModel> list4 = new List<LOC_State_DropdownModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_State_DropdownModel state = new LOC_State_DropdownModel();
                state.StateID = Convert.ToInt32(dr["StateID"]);
                state.StateName = dr["StateName"].ToString();
                list4.Add(state);

            }

            ViewBag.StateList = list4;

            SqlConnection connection2 = new SqlConnection(connection_String);
            connection2.Open();
            SqlCommand command2 = connection2.CreateCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "PR_LOC_Country_ComboBox";
            SqlDataReader reader2 = command2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(reader2);
            connection2.Close();

            List<LOC_Country_DropdownModel> list2 = new List<LOC_Country_DropdownModel>();


            foreach (DataRow dr in dt2.Rows)
            {
                LOC_Country_DropdownModel model1 = new LOC_Country_DropdownModel();
                model1.CountryID = Convert.ToInt32(dr["CountryID"]);
                model1.CountryName = dr["CountryName"].ToString();
                list2.Add(model1);
            }

            ViewBag.CountryList = list2;

            return View(city);

        }

        public IActionResult DeleteCity(int CityID)
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_DeleteByPK";
            cmd.Parameters.AddWithValue("@CityID", CityID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("LOC_CityList");
        }

        public dynamic StatesForComboBox(int CountryID)
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_State_StateByCountryID";
            cmd.Parameters.AddWithValue("@CountryID", CountryID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();

            List<LOC_State_DropdownModel> list = new List<LOC_State_DropdownModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_State_DropdownModel state = new LOC_State_DropdownModel();
                state.StateID = Convert.ToInt32(dr["StateID"]);
                state.StateName = dr["StateName"].ToString();
                list.Add(state);
            }

            ViewBag.StateList = list;

            return Json(list);
        }

        public IActionResult LOC_CityFilter(string? CityName, string? CityCode, string? StateName, string? CountryName)
        {

            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_City_Filter";

            if (CityName == null)
            {
                CityName = DBNull.Value.ToString();
            }

            if (CityCode == null)
            {
                CityCode = DBNull.Value.ToString();
            }

            if (StateName == null)
            {
                StateName = DBNull.Value.ToString();
            }

            if (CountryName == null)
            {
                CountryName = DBNull.Value.ToString();
            }

            cmd.Parameters.AddWithValue("@CityName", CityName);
            cmd.Parameters.AddWithValue("@CityCode", CityCode);
            cmd.Parameters.AddWithValue("@StateName", StateName);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            return View("LOC_CityList", dt);
        }
    }
}
