using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
namespace CrudADO1.Models
{
    public class ChildrenDataAccess
    {
        DBConnection DbConnection;
        public ChildrenDataAccess()
        {
            DbConnection = new DBConnection();
        }
        public List<Children> GetChildren()
        {
            string Sp = "SP_ChildrenD";
            SqlCommand sql = new SqlCommand(Sp,DbConnection.Connection);
            sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            if (DbConnection.Connection.State == ConnectionState.Closed)
            {
                DbConnection.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<Children> children = new List<Children>();
            while (dr.Read())
            {
                Children Child = new Children();
                Child.Id = (int)dr["id"];
                Child.Name = dr["name"].ToString();
                Child.Email = dr["email"].ToString();
                Child.Mobile = dr["Mobile"].ToString();
                Child.Gender = dr["gender"].ToString();
               // Child.DName = dr["department"].ToString();
                children.Add(Child);


            }
            DbConnection.Connection.Close();
            return children;
        }
    }
}
