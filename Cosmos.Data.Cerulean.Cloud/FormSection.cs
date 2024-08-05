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

        public int CopyVersion { get; set; } = 0;

        public List<FormElement> Elements { get; set; }

        public List<FormSection> SubSections { get; set; }
        public FormSection GetElementCopy(int copyVersion = 0)
        {
            var newVersion = CopyVersion + 1;
            if (copyVersion != 0)
            {
                newVersion = copyVersion;
            }

            var copiedFormElements = new List<FormElement>();
            foreach (var item in Elements ?? []) {
                copiedFormElements.Add(item.GetElementCopy(newVersion));
            }

            var copiedFormSubSections = new List<FormSection>();
            foreach (var item in SubSections ?? [])
            {
                var subSectionVersion = item.CopyVersion + 1;
                copiedFormSubSections.Add(item.GetElementCopy(subSectionVersion));
            }

            return new FormSection()
            {
                Label =   $"{Label}_{newVersion}",
                IsRepeatable = false,
                CopyVersion = newVersion,
                Elements = copiedFormElements,
                SubSections = copiedFormSubSections
            };
        }
    }
}
