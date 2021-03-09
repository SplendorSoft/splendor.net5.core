using System.Collections.Generic;
using System.Text.Json.Serialization;
using splendor.net5.core.enums;

namespace splendor.net5.core.commons
{
    public class Reply<E>
        where E: class, new()
    {
        public Reply(){ Success = true; }
        [JsonIgnore] public E Entity { get; set; }
        [JsonIgnore] public IEnumerable<E> Data { get; set; }
        [JsonIgnore] public DTrace Trace { get; set; }
        public bool Success { get; set; }
        public AppError Error { get; set; }
        public long Count { get; set; }
    }
}