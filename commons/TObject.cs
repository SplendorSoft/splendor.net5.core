using System.Text.Json;
using System.Text.Json.Serialization;

namespace splendor.net5.core.commons
{
    /// <summary>
    /// Base transfer object class
    /// </summary>
    public abstract class TObject
    {
        [JsonIgnore] public DTrace Trace { get; set; }
        [JsonIgnore] public bool Valid { get; set; } = true;
    }
}