using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace BookStore.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Category AddCategory(Category category)
        {
            string createdAt = category.date.ToString("yyyy-MM-dd");
            comm.Connection = conn;
            comm.CommandText = "insert into category values ("+category.catId+",'"+category.catName+"','"+category.desc+"','"+category.imageURL+"',"+category.status+","+category.pos+",'"+createdAt+"')";
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)   
                return category;
            else 
                return null;
            
        }

        public bool DeleteCategory(int Id)
        {
            comm.CommandText = "delete from category where categoryId=" + Id;
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
                return true;
            else
                return false;
        }

        public bool EditCategory(int Id,Category category)
        {
            comm.Connection = conn;
            comm.CommandText = "update category"
                +" set categoryId="+category.catId+ ", categoryName='"+category.catName
                +"', description='"+category.desc+ "', image='"+category.imageURL+"',"
                +"status="+category.status+",position="+category.pos+",createdAt='"+category.date.ToString("yyyy-MM-dd")
                +"' where categoryId="+Id;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
                return true;
            else
                return false;
        }

        public List<Category> GetCategories()
        {
            List<Category> catList = new List<Category>();
            comm.CommandText = "select * from category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["categoryId"]);
                int status = Convert.ToInt32(reader["status"]);
                int pos = Convert.ToInt32(reader["position"]);
                string name = reader["categoryName"].ToString();
                string imageURL = reader["image"].ToString();
                string desc = reader["description"].ToString();
                //string date = reader["createdAt"].ToString();
                //DateTime date = DateTime.ParseExact(reader["createdAt"].ToString(),"yyyy",CultureInfo.InvariantCulture);
                DateTime date = Convert.ToDateTime(reader["createdat"].ToString());
                Category cat = new Category(id, name, desc, imageURL, status, pos, date);
                catList.Add(cat);
            }

            conn.Close();
            return catList;
        }
    }
}