using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ChattingClient
{
    class DbParameterInfo
    {
        public string sParamName = "";
        public object objParamData = "";
        public SqlDbType sqlDbType;

        public DbParameterInfo()
        {
        }

        public DbParameterInfo(string sParamName, object objParamData, SqlDbType sqlDbType)
        {
            this.sParamName = sParamName;
            this.objParamData = objParamData;
            this.sqlDbType = sqlDbType;
        }
    }

    class DbReturnInfo
    {
        public DataTable dtSelectInfo = null;
        public int nReturn = 0;
        public int nOut1 = 0;
        public string sOut2 = "";

        public DbReturnInfo()
        {
            dtSelectInfo = new DataTable();
        }
    }

    class DbConnection
    {
        static List<DbParameterInfo> lstParamterInfo = new List<DbParameterInfo>();

        public DbConnection()
        {
        }

        static public void AddParam(string sParamName,int objParamData)
        {
           lstParamterInfo.Add(new DbParameterInfo(sParamName,objParamData,SqlDbType.Int));
        }

        static public void AddParam(string sParamName, string objParamData)
        {
            lstParamterInfo.Add(new DbParameterInfo(sParamName, objParamData, SqlDbType.VarChar));
        }

        static public DbReturnInfo ExcuProcedure(string sProcName)
        {
            DbReturnInfo clsReturnInfo = new DbReturnInfo();
            //접속해주는 친구

            using (SqlConnection conn = new SqlConnection("Server = DESKTOP-64KK2M7\\SQLEXPRESS; Uid = jsg; Pwd = 1q2w3e!!; database = TestDB;"))
            {
                conn.Open();

                //쿼리날리는 친구
                using (SqlCommand sqlComm = new SqlCommand(sProcName,conn))
                {
                    try
                    {
                        sqlComm.CommandType = CommandType.StoredProcedure;

                        //OUTPUT 고정 2개
                        SqlParameter pOutput = new SqlParameter("@Out1", SqlDbType.Int);
                        pOutput.Direction = ParameterDirection.Output;
                        sqlComm.Parameters.Add(pOutput);

                        SqlParameter pOutput2 = new SqlParameter("@Out2", SqlDbType.VarChar);
                        pOutput2.Direction = ParameterDirection.Output;
                        pOutput2.Size = 20;
                        sqlComm.Parameters.Add(pOutput2);
                        
                        foreach (DbParameterInfo item in lstParamterInfo)
                        {
                            sqlComm.Parameters.Add(item.sParamName, item.sqlDbType).Value = item.objParamData;
                        }

                        //리턴용 파라미터 지정
                        SqlParameter pReturn = new SqlParameter();
                        pReturn.Direction = ParameterDirection.ReturnValue;
                        sqlComm.Parameters.Add(pReturn);

                        SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                        da.Fill(clsReturnInfo.dtSelectInfo);

                        clsReturnInfo.nReturn = Convert.ToInt32(pReturn.Value);

                        if (pOutput.Value.ToString() != "")
                            clsReturnInfo.nOut1 = Convert.ToInt32(pOutput.Value);
                        if (pOutput2.Value.ToString() != "")
                            clsReturnInfo.sOut2 = Convert.ToString(pOutput2.Value);

                        return clsReturnInfo;
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                        return clsReturnInfo;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                        lstParamterInfo.Clear();
                    }
                }
            }
        }


    }
}
