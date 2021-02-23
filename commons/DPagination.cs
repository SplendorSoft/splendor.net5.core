using System.Collections.Generic;

namespace splendor.net5.core.commons
{
     /// <summary>
    /// Class representing a pagination used in data stores queries
    /// </summary>
    public class DPagination
    {
        public short? Limit { get; set; }
        public int? Page { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
        public string Filters { get; set; }
        public List<DFilter> DFilters { get; set; }
    }
}