using DataBaseUniv.Models;
using DataBaseUniv.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataBaseUniv.Controllers
{
    public class QueriesController : Controller
    {
        DataBaseUniv2Context context;
        SqlQueriesSettings sqlQueriesSettings;
        public QueriesController(DataBaseUniv2Context context, IOptions<SqlQueriesSettings> sqlQueriesSettings)
        {
            this.sqlQueriesSettings = sqlQueriesSettings.Value;
            this.context = context;

        }
        public IActionResult Index()
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query1 = "SELECT * FROM Levels";

            ViewData["LevelId"] = new SelectList(context.Levels, "Id", "Status");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SimpleQuery1(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query1 = System.IO.File.ReadAllText(sqlQueriesSettings.SimpleQuery1);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.CourceCount is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query1;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_CC", 
                            Value = querySearchModel.CourceCount,
                            SqlDbType = System.Data.SqlDbType.Int
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Teacher> results = new List<Teacher>();
                    while (await reader.ReadAsync())
                    {
                        Teacher teacher = new Teacher
                        {
                            Id = (int)reader["Id"],
                            Email = (string)reader["Email"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"]
                        };
                        results.Add(teacher);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> SimpleQuery2(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query2 = System.IO.File.ReadAllText(sqlQueriesSettings.SimpleQuery2);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.LevelStatus is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query2;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_LSTATUS",
                            Value = querySearchModel.LevelStatus,
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Cource> results = new List<Cource>();
                    while (await reader.ReadAsync())
                    {
                        Cource cource = new Cource
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            LevelId = (int)reader["LevelId"],

                        };
                        results.Add(cource);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> SimpleQuery3(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query3 = System.IO.File.ReadAllText(sqlQueriesSettings.SimpleQuery3);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.TaskCount is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query3;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_TC",
                            Value = querySearchModel.TaskCount,
                            SqlDbType = System.Data.SqlDbType.Int
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<SimpleQueryResultModel3> results = new List<SimpleQueryResultModel3>();
                    while (await reader.ReadAsync())
                    {
                        SimpleQueryResultModel3 simpleQueryResultModel3 = new SimpleQueryResultModel3
                        {
                            Classroom = (int)reader["Classroom"]

                        };
                        results.Add(simpleQueryResultModel3);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> SimpleQuery4(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query4 = System.IO.File.ReadAllText(sqlQueriesSettings.SimpleQuery4);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.CourceCount is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query4;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_CC",
                            Value = querySearchModel.CourceCount,
                            SqlDbType = System.Data.SqlDbType.Int
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Cource> results = new List<Cource>();
                    while (await reader.ReadAsync())
                    {
                        Cource cource = new Cource
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            LevelId = (int)reader["LevelId"],

                        };
                        results.Add(cource);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> SimpleQuery5(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query5 = System.IO.File.ReadAllText(sqlQueriesSettings.SimpleQuery5);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.Email is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query5;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_TE",
                            Value = querySearchModel.Email,
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Models.Task> results = new List<Models.Task>();
                    while (await reader.ReadAsync())
                    {
                        Models.Task task = new Models.Task
                        {
                            Id = (int)reader["Id"],
                            CourceId = (int)reader["CourceId"],
                            Name = (string)reader["Name"],
                            TaskContent = (string)reader["TaskContent"],

                        };
                        results.Add(task);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> SetQuery6(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query6 = System.IO.File.ReadAllText(sqlQueriesSettings.SetQuery6);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.Email is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query6;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_TE",
                            Value = querySearchModel.Email,
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Teacher> results = new List<Teacher>();
                    while (await reader.ReadAsync())
                    {
                        Teacher teacher = new Teacher
                        {
                            Id = (int)reader["Id"],
                            Email = (string)reader["Email"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"]
                        };
                        results.Add(teacher);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> SetQuery7(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query7 = System.IO.File.ReadAllText(sqlQueriesSettings.SetQuery7);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.LevelStatus is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query7;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_LSTATUS",
                            Value = querySearchModel.LevelStatus,
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<SimpleQueryResultModel3> results = new List<SimpleQueryResultModel3>();
                    while (await reader.ReadAsync())
                    {
                        SimpleQueryResultModel3 simpleQueryResultModel3 = new SimpleQueryResultModel3
                        {
                            Classroom = (int)reader["Classroom"]

                        };
                        results.Add(simpleQueryResultModel3);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> SetQuery8(QuerySearchModel querySearchModel)
        {
            string connectionString = sqlQueriesSettings.ConnectionString;
            string query8 = System.IO.File.ReadAllText(sqlQueriesSettings.SetQuery8);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (querySearchModel.TaskCount is null)
                    {
                        throw new ArgumentNullException();
                    }
                    await connection.OpenAsync();
                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = query8;
                    command.Parameters.Add(
                        new SqlParameter
                        {
                            ParameterName = "@P_TC",
                            Value = querySearchModel.TaskCount,
                            SqlDbType = System.Data.SqlDbType.Int
                        }
                    );
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<Teacher> results = new List<Teacher>();
                    while (await reader.ReadAsync())
                    {
                        Teacher teacher = new Teacher
                        {
                            Id = (int)reader["Id"],
                            Email = (string)reader["Email"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"]
                        };
                        results.Add(teacher);
                    }
                    return View(results);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
