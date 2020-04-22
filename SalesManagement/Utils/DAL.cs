using MySql.Data.MySqlClient;
using System.Data;

namespace SalesManagement.Utils
{
    //Data Access Layer.
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "sistema_venda";
        private static string User = "root";
        private static string Password = "";
        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};";
        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        //Espera um parâmetro do tipo string 
        //com um comando do SQL do tipo SELECT.
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(Command);
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        //Espera um parâmetro do tipo string
        //contendo um comando SQL do tipo INSERT, UPDATE, DELETE.
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
