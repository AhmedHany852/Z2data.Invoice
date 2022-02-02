using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Z2data.Invoice.Core.Entity;
using Z2data.Invoice.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Z2data.Invoice.Core.Repository
{
    public class CategoryRepo : CategoryInterfaces

    {
        private IConfiguration _config;

        public CategoryRepo(IConfiguration config )
        {
            _config = config;
        }
        public Category AddCategory(Category category)
        {
            try
            {
                var Category = new Category();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("InsertCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                  
                    var res = cmd.ExecuteNonQuery();
                    if (res > 0)
                        return category;
                    else
                        return category;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category DeleteCategory(int ID)
        {
            try
            {

                var Category = new Category();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {
                    var data = GetCategoryById(ID);
                    if (data != null)
                    {
                        SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@CategoryID", ID);
                        var res = cmd.ExecuteNonQuery();
                        if (res > 0)
                            return data;

                    }

                    return Category;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Category> GetCategory()
        {
            try
            {
                var CS =_config.GetConnectionString("DefaultConnection");
                List<Category> categories = new List<Category>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("GetCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var Category = new Category()
                        {
                            CategoryID = Convert.ToInt32(rdr["CategoryID"]),
                            CategoryName = rdr["CategoryName"].ToString(),
                            
                        };
                        categories.Add(Category);
                    }
                    return (categories);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category GetCategoryById(int ID)
        {
            try
            {
                var Category = new Category();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("GetCategoryById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Category = new Category()
                        {
                            CategoryID= Convert.ToInt32(rdr["CategoryID"]),
                            CategoryName = rdr["CategoryName"].ToString(),
                           

                        };
                    }
                }
                return Category;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category UpdateCategory(Category category)
        {
            try
            {
                var Category = new Category();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {
                    var data = GetCategoryById(category.CategoryID);
                    if (data != null)
                    {
                        SqlCommand cmd = new SqlCommand("UpdateCateory", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                        cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                       
                        var res = cmd.ExecuteNonQuery();
                        if (res > 0)
                            return category;
                    }

                }
                return category;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
