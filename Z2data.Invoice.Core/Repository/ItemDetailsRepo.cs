using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Z2data.Invoice.Core.Entity;
using Z2data.Invoice.Core.Interfaces;

namespace Z2data.Invoice.Core.Repository
{
    public class ItemDetailsRepo : ItemDetailsInterface
    {

        private IConfiguration _config;

        public ItemDetailsRepo(IConfiguration config)
        {
            _config = config;
        }
        public ItemDetails AddItemDetails(ItemDetails itemDetails)
        {
            try
            {
                var ItemDetails = new ItemDetails();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("InsertItemDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ItemID", itemDetails.ItemID);
                    cmd.Parameters.AddWithValue("@ProductName", itemDetails.ProductName);
                    cmd.Parameters.AddWithValue("@Price", itemDetails.Price);
                    var res = cmd.ExecuteNonQuery();
                    if (res > 0)
                        return itemDetails;
                    else
                        return itemDetails;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ItemDetails DeleteItemDetails(int ID)
        {
            try
            {
                var ItemDetails = new ItemDetails();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {
                    var data = GetItemDetailsByID(ID);
                    if (data != null)
                    {
                        SqlCommand cmd = new SqlCommand("DeleteItemDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@ItemDetails", ID);
                        var res = cmd.ExecuteNonQuery();
                        if (res > 0)
                            return data;

                    }

                    return ItemDetails;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

     

        public IEnumerable<ItemDetails> GetItemDetails()
        {
            try
            {
                var CS = _config.GetConnectionString("DefaultConnection");
                List<ItemDetails> itemDetails = new List<ItemDetails>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("GetItemDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var ItemDetails = new ItemDetails()
                        {
                            KeyID = Convert.ToInt32(rdr["KeyID"]),
                            ItemID = Convert.ToInt32(rdr["ItemID"]),
                            ProductName = rdr["ProductName"].ToString(),
                            Price = rdr["Price"].ToString() == null ? (decimal)rdr["Price"] : default,


                        };
                        itemDetails.Add(ItemDetails);
                    }
                    return (itemDetails);
                }
            }
            catch (Exception)
            {
                throw;
            }
            }

        public ItemDetails GetItemDetailsByID(int KayID)
        {
            try
            {
                var itemDetails = new ItemDetails();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("GetItemDetailsById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@KayID", KayID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        itemDetails = new ItemDetails()
                        {
                            KeyID = Convert.ToInt32(rdr["KeyID"]),
                            ItemID = Convert.ToInt32(rdr["ItemID"]),
                            ProductName = rdr["ProductName"].ToString(),
                            Price = rdr["Price"].ToString() == null ? (decimal)rdr["Price"] : default,
                            

                        };
                    }
                }
                return itemDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ItemDetails UpdateItemDetails(ItemDetails itemDetails)
        {
            try
            {
                var ItemDetails = new ItemDetails();
                var CS = _config.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(CS))
                {
                    var data = GetItemDetailsByID(itemDetails.KeyID);
                    if (data != null)
                    {
                        SqlCommand cmd = new SqlCommand("UpdateItemDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@KeyID", ItemDetails.KeyID);
                        cmd.Parameters.AddWithValue("@ItemID", ItemDetails.ItemID);
                        cmd.Parameters.AddWithValue("@ProductName", ItemDetails.ProductName);
                        cmd.Parameters.AddWithValue("@Price", ItemDetails.Price);
                        var res = cmd.ExecuteNonQuery();
                        if (res > 0)
                            return itemDetails;
                    }

                }
                return ItemDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
   

