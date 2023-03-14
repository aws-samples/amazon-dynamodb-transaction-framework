
using System;

namespace BootCamp.Service.Contract
{
    /// <summary>
    /// Product item model object.
    /// </summary>
    public abstract class ProductModel
    {
        /// <summary>
        /// Table name.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Producr type.
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Book, Movie, Album product title.
        /// </summary>
        public string Title { get; set; }

    }
}
