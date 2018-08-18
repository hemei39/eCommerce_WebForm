using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace DataAccess
{
    public static class Helper
    {
        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, row[prop.Name], null);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<Product> SortList(List<Product> data, bool isPageIndexChanging, 
            string sortExpression, string sortDirection)
        {
            List<Product> result = new List<Product>();
            if (data != null)
            {
                if (sortExpression != string.Empty)
                {
                    if (data.Count > 0)
                    {
                        PropertyInfo[] propertys = data[0].GetType().GetProperties();
                        foreach (PropertyInfo p in propertys)
                        {
                            if (p.Name == sortExpression)
                            {
                                if (sortDirection == "ASC")
                                {
                                    if (isPageIndexChanging)
                                    {
                                        result = data.OrderByDescending(key => p.GetValue(key, null)).ToList();
                                    }
                                    else
                                    {
                                        result = data.OrderBy(key =>
                                        p.GetValue(key, null)).ToList();
                                        sortDirection = "DESC";
                                    }
                                }
                                else
                                {
                                    if (isPageIndexChanging)
                                    {
                                        result = data.OrderBy(key =>
                                        p.GetValue(key, null)).ToList();
                                    }
                                    else
                                    {
                                        result = data.OrderByDescending(key => p.GetValue(key, null)).ToList();
                                        sortDirection = "ASC";
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}