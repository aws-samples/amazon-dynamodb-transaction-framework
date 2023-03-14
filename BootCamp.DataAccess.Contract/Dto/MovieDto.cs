
using System;

namespace BootCamp.DataAccess.Contract
{
    /// <summary>
    /// Class for product
    /// </summary>
    public class MovieDto : ProductDto
    {

        /// <summary>
        /// Movie genre
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Movie director.
        /// </summary>
        public string Director { get; set; }

    }
}
