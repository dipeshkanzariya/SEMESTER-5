using DatabaseDemo.Areas.Branch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseDemo.Areas.Branch.Controllers
{
    [Area("Branch")]
    public class MST_BranchController : Controller
    {
        public IConfiguration Configuration;
        public MST_BranchController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult MST_BranchList()
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Branch_SelectAll";

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();
            return View(dt);
        }

        public IActionResult MST_BranchSave(MST_BranchModel bm)
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (bm.BranchID == 0)
            {
                cmd.CommandText = "PR_MST_Branch_Insert";
            }
            else
            {
                cmd.CommandText = "PR_MST_Branch_UpdateByPK";
                cmd.Parameters.AddWithValue("@BranchID", bm.BranchID);
            }
            cmd.Parameters.AddWithValue("@BranchName", bm.BranchName);
            cmd.Parameters.AddWithValue("@BranchCode", bm.BranchCode);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("MST_BranchList");
        }

        public IActionResult MST_BranchAddEdit(int? BranchID = 0)
        {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Branch_SelectByPK";
            cmd.Parameters.AddWithValue("@BranchID", BranchID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            conn.Close();

            MST_BranchModel bm = new MST_BranchModel();

            foreach (DataRow dr in dt.Rows)
            {
                bm.BranchID = Convert.ToInt32(dr["BranchID"]);
                bm.BranchName = dr["BranchName"].ToString();
                bm.BranchCode = dr["BranchCode"].ToString();
            }

            return View("MST_BranchAddEdit", bm);
        }

        public IActionResult DeleteBranch(int? BranchID) {
            string connection_string = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_MST_Branch_DeleteByPK";
            cmd.Parameters.AddWithValue("@BranchID", BranchID);
            cmd.ExecuteNonQuery();
            return RedirectToAction("MST_BranchList");
        }

    }
}
