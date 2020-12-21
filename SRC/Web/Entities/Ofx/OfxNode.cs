using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class OfxNode
    {
        public string Name { get; set; }
        public List<OfxNode> Children { get; set; }
        public string Value { get; set; }
        public bool ClosingTag { get; set; }

        public OfxNode()
        {
            Children = new List<OfxNode>();
        }

        public string ToXml()
        {
            if (ClosingTag)
                return $"<{Name}>{string.Concat(Children.Select(c => c.ToXml()))}</{Name}>";

            return $"<{Name}>{Value}</{Name}>";
        }
    }
}
