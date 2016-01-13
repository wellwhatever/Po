using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Po
{
    class SqliteDatabase
    {
        private SQLiteConnection connect;

        private SQLiteCommand command;

        private SQLiteDataReader reader;

        private SQLiteDataAdapter adapter;

        private string connectiondetails = Properties.Settings.Default["connectionstring"].ToString();

        private bool isConnected = false;

        private List<string> parameters;

        private DataTable Table;

        private int affected_rows;

        private string squery;

        public SqliteDatabase()
        {
            Connect();
            Table = new DataTable();
            parameters = new List<string>();
        }

        private void Connect()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectiondetails);
                connection.Open();
                connect = connection;
                isConnected = true;
            }
            catch (SQLiteException ex)
            {
                string exception = "Exception : " + ex.Message.ToString() + "\n\rApplication will close now. \n\r" + squery;
                MessageBox.Show(exception, "Uncaught SQLite Exception");
                Debug(exception);

                Environment.Exit(1);
            }
        }

        public void CloseConn()
        {
            isConnected = false;
            connect.Close();
            connect.Dispose();
        }

        private void Init(string Query, string[] bindings = null)
        {
            // No connection with database? make connection
            if (isConnected == false)
            {
                Connect();
            }

            // Automatically disposes the MySQLcommand instance
            using (command = new SQLiteCommand(Query, connect))
            {
                // 
                bind(bindings);

                // Prevents SQL injection
                if (parameters.Count > 0)
                {
                    parameters.ForEach(delegate(string parameter)
                    {
                        string[] sparameters = parameter.ToString().Split('\x7F');
                        command.Parameters.AddWithValue(sparameters[0], sparameters[1]);
                    });
                }

                this.squery = Query.ToLower();

                if (squery.Contains("select"))
                {
                    this.Table = execDatatable();
                }
                if (squery.Contains("delete") || squery.Contains("update") || squery.Contains("insert"))
                {
                    this.affected_rows = execNonquery();
                }

                // Clear de parameters, 
                this.parameters.Clear();
            }
        }

        public void bind(string field, string value)
        {
            parameters.Add("@" + field + "\x7F" + value);
        }

        public void bind(string[] fields)
        {
            if (fields != null)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    bind(fields[i], fields[i + 1]);
                    i += 1;
                }
            }
        }

        public void qBind(string[] fields)
        {
            if (fields != null)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    bind(i.ToString(), fields[i]);
                }
            }
        }

        private DataTable execDatatable()
        {
            DataTable dt = new DataTable();
            try
            {
                reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch (SQLiteException ex)
            {
                string exception = "Exception : " + ex.Message.ToString() + "\n\r SQL Query : \n\r" + squery;

                MessageBox.Show(exception, "Uncaught SQLite Exception");

                Debug(exception);
            }

            return dt;
        }

        private int execNonquery()
        {

            int affected = 0;

            try
            {
                affected = command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                string exception = "Exception : " + ex.Message.ToString() + "\n\r SQL Query : \n\r" + squery;

                MessageBox.Show(exception, "Uncaught SQLite Exception");

                Debug(exception);
            }

            return affected;
        }

        public DataTable table(string table, string[] bindings = null)
        {
            Init("SELECT * FROM " + table, bindings);
            return this.Table;
        }

        public List<object> table(string table, Type t)
        {
            return new List<object>();
        }

        public DataTable query(string query, string[] bindings = null)
        {
            Init(query, bindings);
            return this.Table;
        }

        public int nQuery(string query, string[] bindings = null)
        {
            Init(query, bindings);
            return this.affected_rows;
        }

        public string single(string query, string[] bindings = null)
        {
            Init(query, bindings);

            if (Table.Rows.Count > 0)
            {
                return Table.Rows[0][0].ToString();
            }

            return string.Empty;
        }

        public string[] row(string query, string[] bindings = null)
        {
            Init(query, bindings);

            string[] row = new string[Table.Columns.Count];

            if (Table.Rows.Count > 0)
                for (int i = 0; i++ < Table.Columns.Count; row[i - 1] = Table.Rows[0][i - 1].ToString()) ;

            return row;
        }

        public List<string> column(string query, string[] bindings = null)
        {
            Init(query, bindings);

            List<string> column = new List<string>();

            for (int i = 0; i++ < Table.Rows.Count; column.Add(Table.Rows[i - 1][0].ToString())) ;

            return column;
        }

        public void Debug(string error)
        {
            Console.WriteLine(error + "/n/r");
        }
    }
}
