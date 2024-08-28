//Manage Book Table in Database
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ControllerAPI2
{
    //Controller Setting
    [Route("api/[controller]")]
    [ApiController]
    //Class
    public class TbBookController : ControllerBase
    {
        //Endpont for get data from database (ADO.NET)
        [HttpGet("[action]")]
        public IActionResult List()
        {
            try
            {
                using (NpgsqlConnection conn = new Connect().CreateConnection())
                {
                    List<object> list = new List<object>();
                    NpgsqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM tb_book";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            author = Convert.ToInt32(reader["price"])
                        });
                    }
                    return Ok(list);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //Endpont for create data in database (ADO.NET)
        [HttpPost("[action]")]
        public IActionResult Create(TbBookModel model)
        {
            try
            {
                //Connect to database
                using (NpgsqlConnection conn = new Connect().CreateConnection())
                {
                    NpgsqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO tb_book(name,price) VALUES(@name,@price)";
                    cmd.Parameters.AddWithValue("name",model.name!);
                    cmd.Parameters.AddWithValue("price",model.price);
                    cmd.ExecuteNonQuery();

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }


}
