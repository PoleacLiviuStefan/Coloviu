using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient; // Required for SqlConnection, SqlCommand, SqlDataReader
using Microsoft.Extensions.Configuration; // Required for IConfiguration

namespace Coloviu.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration _configuration;

        public TestController(IConfiguration config) // Constructor name corrected
        {
            _configuration = config;
        }

        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes() // Corrected bracket placement
        {
            string query = "select * from dbo.Note";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("colocviuDBCon");
            SqlDataReader myReader;
            using (SqlConnection sqlConn = new SqlConnection(sqlDatasource)) // Corrected variable name
            {
                sqlConn.Open(); // Corrected variable name
                using (SqlCommand myCommand = new SqlCommand(query, sqlConn)) // Corrected SqlCommand constructor
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    sqlConn.Close(); // Corrected variable name
                }
              
            }

            return new JsonResult(table); // Return the DataTable as JsonResult
        }

        

        [HttpDelete]
        [Route("DeleteNotes")]
        public JsonResult DeleteNotes(int id) // Corrected bracket placement
        {
            string query = "delete from dbo.Note where id=@id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("colocviuDBCon");
            SqlDataReader myReader;
            using (SqlConnection sqlConn = new SqlConnection(sqlDatasource)) // Corrected variable name
            {
                sqlConn.Open(); // Corrected variable name
                using (SqlCommand myCommand = new SqlCommand(query, sqlConn)) // Corrected SqlCommand constructor
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    sqlConn.Close(); // Corrected variable name
                }

            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
