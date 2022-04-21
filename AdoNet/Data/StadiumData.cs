using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.Data
{
    public  class StadiumData
    {
        public void Add(Stadiums stadium)
        {
            using(SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"insert into Stadiums (Name,HourPrice,Capacity) VALUES ('{stadium.Name}',{stadium.HourlyPrice},{stadium.Capacity})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Stadiums> GetStadiums()
        {
            List<Stadiums> stadiums1 = new List<Stadiums>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "select * from Stadiums";
                SqlCommand cmd = new SqlCommand(query, con);

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Stadiums stadiums = new Stadiums()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetInt32(2),
                            Capacity = dr.GetInt32(3)

                        };
                     stadiums1.Add(stadiums);

                    }
                }
            }
            return stadiums1;
        }


        public Stadiums GetStadiumsId(int id)
        {
            Stadiums stadiums1 = null;
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "select * from Stadiums Where Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id",id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                         stadiums1 = new Stadiums()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetInt32(2),
                            Capacity = dr.GetInt32(3)

                        };
                       

                    }
                }
            }
              return stadiums1 ;
        }



        public void DeleteById(int id)
        {

            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"delete from Stadiums Where Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
              
                cmd.Parameters.AddWithValue("@id",id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
