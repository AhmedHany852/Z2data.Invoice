using System;
using System.Collections.Generic;
using System.Text;
using Z2data.Invoice.Core.Entity;


namespace Z2data.Invoice.Core.Interfaces
{
    public interface CategoryInterfaces
    {
        /// <summary>
        /// Get all Category
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategory();
        /// <summary>
        /// Get Item By id 
        /// </summary>
        /// <param name="ID">int Param</param>
        /// <returns></returns>
        Category GetCategoryById(int ID);
        /// <summary>
        /// add new Category
        /// </summary>
        /// <param name="Category">Object Param</param>
        Category AddCategory(Category category);
        /// <summary>
        /// delete exist Category
        /// </summary>
        /// <param name="ID">int Param</param>
        Category DeleteCategory(int ID);
        /// <summary>
        /// update exist Category
        /// </summary>
        /// <param name="Category">Object Param</param>
        /// <returns></returns>
        Category UpdateCategory(Category category);
    }
}
