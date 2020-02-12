using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    /// <summary>
    /// Interface with required "id" property.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Property represents an identity code.
        /// </summary>
        int id { get; set; }
    }
}
