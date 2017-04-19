using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Console
{
    public class ProcessorThing
    {
        public (int result, string message, string error) Process(object data)
        {
            if (data is string s && s.Any(c => c == '!'))
                return (0, $"{s}? Wow!", string.Empty);
            if (data is Task t)
            {
                t.Wait();
                return (1, "Task Completed", $"{(t.IsFaulted ? "with" : "without")} fault");
            }
            return (-1, "Error", "Unknown Object Data Cannot Be Processed.");
        }
    }
}
