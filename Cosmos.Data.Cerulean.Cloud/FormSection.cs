using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Data.Cerulean.Cloud
{
    public class FormSection
    {
        public string Label { get; set; }

        public bool IsRepeatable { get; set; }

        public List<FormElement> Elements { get; set; }

        public FormSection SubSection { get; set; }
    }
}
