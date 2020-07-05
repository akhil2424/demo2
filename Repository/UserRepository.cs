using demo2.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.ModelBinding;

namespace demo2.Repository
{
    //*******Both Linque and sql querry approach is written************ 
   //********First part Linque query method
    public class UserRepository
    {
        public bool SignUp(User u)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Users.Add(u);
                ctx.SaveChanges();
            }
            return true;
        }
        public Boolean Login(User u) 
        {
            using (var ctx = new DatabaseContext())
            {
                var result = ctx.Users
                           .Where(x => x.Email == u.Email && x.Password== u.Password)
                           .Select(row => row).FirstOrDefault();
                if (result != null)
                {
                    
                    System.Web.HttpContext.Current.Session["sessionString"] =result.Username;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public User GetUser(int userId)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Users.Where(x => x.Userid == userId).SingleOrDefault();
            }
        }
        public List<Product> GetProducts()
        {
            using (var ctx = new DatabaseContext())
            {
                List<Product> p = ctx.Products.Select(row => row).ToList();
                return p;
            }
        }
        public Product GetProduct(int Productid)
        {
            using (var ctx = new DatabaseContext())
            {
                var result = ctx.Products
                            .Where(x => x.Productid == Productid)
                            .Select(row => row).FirstOrDefault();
                return result;
            }
        }
        public bool UpdateProduct(Product p)
        {
            using (var ctx = new DatabaseContext())
            {
                var currentValue = ctx.Products.Where(x => x.Productid == p.Productid).FirstOrDefault();
                currentValue.Productname = p.Productname;
                currentValue.Description = p.Description;
                currentValue.Price = p.Price;
                ctx.SaveChanges();
                return true;
            }
        }
        public bool SaveProduct(Product p)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Products.Add(p);
                ctx.SaveChanges();
            }
            return true;
        }
        public bool DeleteProduct(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                var currentValue = ctx.Products.Where(x => x.Productid == id).FirstOrDefault();
                ctx.Products.Remove(currentValue);
                ctx.SaveChanges();
            }
            return true;
        }
        public List<Product> SearchProduct(string s)
        {
            using (var ctx = new DatabaseContext())
            {
                List<Product> p = ctx.Products.Select(row => row)
                                  .Where(x => x.Productname == s)
                                  .ToList();
                return p;
            }
        }
        //*********Simple Sql querry Below******************
        // public bool SignUp(User u)
        // {
        //     string Username = u.Username;
        //     string Email = u.Email;
        //     string Password = u.Password;
        //     SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //     con.Open();
        //     string query = "INSERT INTO users(Email,Password,Username) VALUES('" + Email + "','" + Password + "','" + Username + "')";
        //     SqlCommand cmd = new SqlCommand(query, con);
        //     cmd.ExecuteNonQuery();
        //     return true;
        // }
        //public bool Login(User u)
        // {
        //     //string username = u.username;
        //     string Email = u.Email;
        //     string Password = u.Password;
        //     SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //     con.Open();
        //     string query = "SELECT * FROM users where Email='" + Email + "' AND Password='" + Password + "'";
        //     SqlCommand cmd = new SqlCommand(query, con);
        //     //cmd.ExecuteNonQuery();
        //     //SqlDataReader count = cmd.ExecuteNonQuery();
        //     SqlDataReader rdr = cmd.ExecuteReader();
        //     if (rdr.HasRows == false)
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return true;

        //     }

        // }
        //        public List<Product> GetProducts()
        //         {
        //             SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //             con.Open();
        //             var retVal = new List<Product>();
        //             string query = "SELECT * FROM products";
        //             SqlCommand cmd = new SqlCommand(query, con);
        //             SqlDataReader rdr = cmd.ExecuteReader();
        //             while (rdr.Read())
        //             {
        //                 var product = new Product();
        //                 product.Productid = int.Parse(rdr["Productid"].ToString());
        //                 product.Productname = rdr["Productname"].ToString();
        //                 product.Price= int.Parse(rdr["Price"].ToString());
        //                 product.Description = rdr["Description"].ToString();
        //                 retVal.Add(product);
        //             }       
        //             return retVal;
        //        }
        //  public bool SaveProduct(Product p)
        //     {
        //         string Productname = p.Productname;
        //         int Price = p.Price;
        //         string Description = p.Description;   



        //     SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //             con.Open();
        //             string query = "INSERT INTO products(Productname,Price,Description) VALUES('" + Productname+ "','" + Price+ "','" + Description + "')";
        //             SqlCommand cmd = new SqlCommand(query, con);
        //             cmd.ExecuteNonQuery();
        //             return true;
        //         }
        //  public bool DeleteProduct(int Productid)
        //   {
        //             SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //             con.Open();
        //             string query = "DELETE FROM products WHERE Productid='" + Productid + "'";
        //             SqlCommand cmd = new SqlCommand(query, con);
        //             cmd.ExecuteNonQuery();
        //             return true;
        //   }
        // public Product GetProduct(int Productid)
        // {
        //     SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //     con.Open();
        //     var retVal = new Product();
        //     string query = "SELECT * FROM products WHERE Productid='" + Productid + "'";
        //     SqlCommand cmd = new SqlCommand(query, con);
        //     var reader = cmd.ExecuteReader();
        //      while (reader.Read())
        //              {
        //                     retVal.Productid = int.Parse(reader["Productid"].ToString());
        //                     retVal.Productname = reader["Productname"].ToString();
        //                     retVal.Description = reader["Description"].ToString();
        //                     retVal.Price = int.Parse(reader["Price"].ToString());
        //                 }

        //                     return retVal;


        // }

        // public bool UpdateProduct(Product p)
        // {
        //     int Productid = p.Productid;
        //     string Productname = p.Productname;
        //     int Price = p.Price;
        //     string Description = p.Description;

        //     SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //     con.Open();
        //     string query = "UPDATE products SET Productname='" + Productname + "',Description='" + Description + "', Price='" + Price + "' where Productid='" + Productid + "'";
        //     SqlCommand cmd = new SqlCommand(query, con);
        //     cmd.ExecuteNonQuery();
        //     return true;
        // }
        // public List<Product> SearchProduct(string s)
        //{
        //     SqlConnection con = new SqlConnection("Data Source=LAPTOP-20VVHH05;Initial Catalog=sample;Integrated Security=True");
        //      con.Open();
        //     var retVal = new List<Product>();
        // string query = "SELECT * FROM products where Productname like '" + s + "'order by Productid";
        // SqlCommand cmd = new SqlCommand(query, con);
        // SqlDataReader rdr = cmd.ExecuteReader();
        //     while (rdr.Read())
        //     {
        //         var product = new Product();
        //         product.Productid = int.Parse(rdr["Productid"].ToString());
        //         product.Productname = rdr["Productname"].ToString();
        //         product.Price = int.Parse(rdr["Price"].ToString());
        //         product.Description = rdr["Description"].ToString();
        //         retVal.Add(product);
        //     }
        //     return retVal;
        // }

    }
}