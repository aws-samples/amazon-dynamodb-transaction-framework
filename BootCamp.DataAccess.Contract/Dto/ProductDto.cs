
using System;

namespace BootCamp.DataAccess.Contract
{
    /// <summary>
    /// Class for product
    /// </summary>
    public abstract class ProductDto
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
        /// Movie title.
        /// </summary>
        public string Title { get; set; }

    }
}
