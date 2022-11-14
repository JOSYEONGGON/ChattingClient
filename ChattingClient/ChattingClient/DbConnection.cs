using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ChattingClient
{
    class DbConnection
    {
        public DbConnection()
        {

        }

        static public DataTable ExcuProcedure(string sProcedure)
        {
            DataTable dt = new DataTable();
            //접속해주는 친구
            using (SqlConnection conn = new SqlConnection())
            {
                //쿼리날리는 친구
                SqlCommand sqlComm = new SqlCommand();

               // SqlDataReader sd;
               // String SQL = "Select * from TestTable1";
                try
                {
                    //string connectionString = "Server = DESKTOP-64KK2M7\\SQLEXPRESS;"
                    //                        + "Trusted_Connection=true;"
                    //                        + "database = TestDB;"
                    //                        + "User Instance=true;"
                    //                        + "Connection timeout=30";

                    string connectionString = "Server = DESKTOP-64KK2M7\\SQLEXPRESS; Uid = jsg; Pwd = 1q2w3e!!; database = TestDB;";
                    //접속정보 적용
                    conn.ConnectionString = connectionString;
                    //DB 연결
                    conn.Open();
                    //쿼리 맵핑
                   // sqlComm.CommandText = SQL;
                    //쿼리 날릴 곳 
                   // sqlComm.Connection = conn;
                    ////쿼리 날리기
                    //sd = sqlComm.ExecuteReader();

                    ////한줄 한줄 불러오기
                    //while (sd.Read())
                    //{

                    //}

                    SqlDataAdapter da = new SqlDataAdapter(sProcedure, conn);
                   
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return dt;
                }
            }
        }
    }
}
