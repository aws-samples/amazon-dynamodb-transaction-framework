
using System;

namespace BootCamp.Service.Contract
{
    /// <summary>
    /// Product item model object.
    /// </summary>
    public class MovieModel : ProductModel
    {

        /// <summary>
        /// Movie director.
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// Movie genre
        /// </summary>
        public string Genre { get; set; }

    }
}
