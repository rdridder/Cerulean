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

        public List<FormSection> SubSections { get; set; }
        public FormSection GetElementCopy(int copyVersion)
        {
            var copiedFormElements = new List<FormElement>();
            foreach (var item in Elements ?? []) {
                copiedFormElements.Add(item.GetElementCopy(copyVersion));
            }

            //var copiedFormSubSections = new List<FormSection>();
            //foreach (var item in SubSections ?? [])
            //{
            //    copiedFormSubSections.Add(item.GetElementCopy(copyVersion));
            //}

            return new FormSection()
            {
                Label = $"{Label}_{copyVersion}",
                IsRepeatable = false,
                Elements = copiedFormElements,
                SubSections = null
            };
        }
    }
}
