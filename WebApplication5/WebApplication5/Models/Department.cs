using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5.Models
{
    public class Department
    {
        // Declaration of connection string
        private string connnectionstring = ConfigurationManager.ConnectionStrings["DepartmentString"].ConnectionString;

        #region "GetData Method Fetches Data From Department Table "
        /// <summary>
        /// GetData method fetches all the data from Department table 
        /// </summary>
        /// <returns></returns>
        public List<DepartmentAccess> GetData()
        {
            List<DepartmentAccess> li = new List<DepartmentAccess>();

            try
            {
                SqlConnection conn = new SqlConnection(connnectionstring);
                SqlCommand cmd = new SqlCommand("sp_getdata", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();

                //loop fetches data untill records are founds in Department table
                while (rdr.Read())
                {
                    DepartmentAccess department = new DepartmentAccess();
                    department.Dept_Id = Convert.ToInt32(rdr.GetValue(0).ToString());
                    department.Dept_Name = rdr.GetValue(1).ToString();
                    department.Dept_Details = rdr.GetValue(2).ToString();
                    li.Add(department);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return li;
        }
        #endregion
    }
}