// Adapted from the Rotary Control described in https://www.codeproject.com/Articles/4044072/A-WPF-Rotary-Control.  

using System.Windows.Media;

namespace RotaryControl
{
    /// <summary>
    /// Represents one segment within an Arc on the Rotary Control.
    /// </summary>
    public class RotaryControlSegment
    {
        public Brush Fill { get; set; }

        public int AngleInDegrees { get; set; }
    }
}
