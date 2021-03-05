using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : BaseAdo, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityRolePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Roles]
           ([Id]
           ,[Role]
           ,[Is_Inactive])
     VALUES
           (@Id, 
           @Role,
           @IsInactive)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Role", item.Role);
                cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT *
                FROM [dbo].[Security_Roles]";
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            int counter = 0;
            SecurityRolePoco[] pocos = new SecurityRolePoco[1000];
            while (rdr.Read())
            {
                SecurityRolePoco poco = new SecurityRolePoco();
                poco.Id = rdr.GetGuid(0);
                poco.Role = rdr.GetString(1);
                poco.IsInactive = rdr.GetBoolean(2);
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityRolePoco item in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Security_Roles]
                WHERE [Id]= @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityRolePoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Security_Roles]
                SET [Role] = @Role
                ,[Is_Inactive] = @IsInactive
                WHERE [Id]= @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Role", item.Role);
                cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
