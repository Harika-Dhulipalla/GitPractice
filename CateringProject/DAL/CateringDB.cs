using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using CateringProject.Models;

namespace CateringProject.DAL
{
    public class CateringDB
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["CateringDB"].ToString();
            con = new SqlConnection(constring);
        }
        public bool AddUser(OrderModel omodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UserInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", omodel.UserName);
            cmd.Parameters.AddWithValue("@CreatedDate", omodel.CreatedDate);
            cmd.Parameters.AddWithValue("@PhoneNo", omodel.PhoneNo);
            cmd.Parameters.AddWithValue("@EmailId", omodel.EmailId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        public List<OrderModel> GetUsers()
        {
            connection();
            List<OrderModel> productlist = new List<OrderModel>();
            SqlCommand cmd = new SqlCommand("GetUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                productlist.Add(
                    new OrderModel
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                        EmailId = Convert.ToString(dr["EmailId"]),
                        PhoneNo = Convert.ToString(dr["PhoneNo"]),
                    });
            }
            return productlist;
        }
        public bool UpdateUser(OrderModel omodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", omodel.UserId);
            cmd.Parameters.AddWithValue("@UserName", omodel.UserName);
            cmd.Parameters.AddWithValue("@CreatedDate", omodel.CreatedDate);
            cmd.Parameters.AddWithValue("@PhoneNo", omodel.PhoneNo);
            cmd.Parameters.AddWithValue("@EmailId", omodel.EmailId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeleteUser(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}