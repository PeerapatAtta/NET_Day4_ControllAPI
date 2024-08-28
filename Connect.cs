//
using Npgsql;

public class Connect
{
    //Field
    private readonly string strConn = "Host=localhost;Port=5432;Database=db_dotnet_samit;Username=postgres;Password=123456;";
    //Method
    public NpgsqlConnection CreateConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(strConn);
        conn.Open();
        return conn;
    }

}