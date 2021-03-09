using System.Collections.Generic;

namespace splendor.net5.core.commons
{
    public class ReplyTO<E, TO>: Reply<E>
        where TO: TObject
        where E: class, new()
    {
        public ReplyTO(): base(){}
        public TO Value { get; set; }
        public IEnumerable<TO> Rows { get; set; }
        public string Message { get; set; }
        public string Environment { get; set; }
    }
}