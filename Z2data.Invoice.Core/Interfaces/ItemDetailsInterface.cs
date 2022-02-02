using System;
using System.Collections.Generic;
using System.Text;
using Z2data.Invoice.Core.Entity;

namespace Z2data.Invoice.Core.Interfaces
{
    public interface ItemDetailsInterface
    {
        /// <summary>
        /// Get all Items 
        /// </summary>
        /// <returns></returns>
       IEnumerable<ItemDetails> GetItemDetails();
        /// <summary>
        /// Get Item By id 
        /// </summary>
        /// <param name="ID">int Param</param>
        /// <returns></returns>
        ItemDetails GetItemDetailsByID(int KayID);
        /// <summary>
        /// add new Items
        /// </summary>
        /// <param name="ItemDetails">Object Param</param>
        ItemDetails AddItemDetails(ItemDetails itemDetails);
        /// <summary>
        /// delete exist Items
        /// </summary>
        /// <param name="ID">int Param</param>
        ItemDetails DeleteItemDetails(int ID);
        /// <summary>
        /// update exist Items
        /// </summary>
        /// <param name="ItemDetails">Object Param</param>
        /// <returns></returns>
        ItemDetails UpdateItemDetails(ItemDetails itemDetails);
    }
}
