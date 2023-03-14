
using System;

namespace BootCamp.Service.Contract
{
    /// <summary>
    /// Product item model object.
    /// </summary>
    public class BookModel : ProductModel
    {
        /// <summary>
        /// Book author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book publish date.
        /// </summary>
        public DateTime? PublishDate { get; set; }

    }
}
