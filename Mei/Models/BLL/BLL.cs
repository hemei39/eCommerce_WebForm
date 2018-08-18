using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Runtime.Caching;
using DataAccess;



namespace Mei.Models
{
    public class BLL
    {
        public List<Category> GetCategories()
        {
            DAL dal = new DAL();

            List<Category> categories = dal.GetCategories();
            return categories;
        }

        public List<Product> GetProducts(int categoryID, string sortColumn)
        {
            List<Product> products;

            DAL_EF dal_EF = new DAL_EF();
            products = dal_EF.GetProducts(categoryID,sortColumn);
            
            return products;
        }

        public int AddToShoppingCart(DataAccess.ShoppingCart cart)
        {
            DAL dal = new DAL();
            int retVal = dal.AddToShoppingCart(cart);

            return retVal;
        }

        public List<DataAccess.ShoppingCart> GetShoppingCart()
        {
            DAL dal = new DAL();

            List<DataAccess.ShoppingCart> shoppingCart = dal.GetShoppingCart("vistor");

            return shoppingCart;
        }

        //public List<ShoppingCart> GetShoppingCartFromService()
        //{
        //    DataService1

        //    List<ShoppingCart> shoppingCart = dal.GetShoppingCart("vistor");

        //    return shoppingCart;
        //}
        public int DeleteFromShoppingCart(string username, int productID)
        {
            DAL dal = new DAL();
            int retVal = dal.DeleteFromShoppingCart(username,productID);

            return retVal;
        }

        public int UpdateShoppingCart(DataAccess.ShoppingCart cart)
        {
            DAL dal = new DAL();
            int retVal = dal.UpdateShoppingCart(cart);

            return retVal;
        }

    }
}