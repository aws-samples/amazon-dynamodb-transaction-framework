
using System;

namespace BootCamp.DataAccess.Contract
{
    /// <summary>
    /// Class for product
    /// </summary>
    public class BookDto : ProductDto
    {
        /// <summary>
        /// Book author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book publish date.
        /// </summary>
        public string PublishDate { get; set; }

    }
}
