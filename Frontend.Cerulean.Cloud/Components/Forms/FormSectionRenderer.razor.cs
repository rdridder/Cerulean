using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Statics;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;

namespace Frontend.Cerulean.Cloud.Components.Forms
{
    public partial class FormSectionRenderer
    {
        [Parameter, EditorRequired]
        public required FormSection Section { get; init; }

        [Parameter, EditorRequired]
        public required Dictionary<string, object> ElementValues { get; init; }

        private bool IsRepeatable { get; set; }

        protected override void OnInitialized()
        {
            IsRepeatable = Section.IsRepeatable;
            //copyNumber = Section?.SubSections?.Count + 2 ?? 2;
        }

        private void AddFormSection()
        {
            //var copiedSection = Section.GetElementCopy(copyNumber);
            var copiedSection = Section.GetElementCopy();
            GenerateBindingKeys(copiedSection);
            if (Section.SubSections == null)
            {
                Section.SubSections = new List<FormSection>();
            }
            Section.SubSections.Add(copiedSection);
        }

        private void GenerateBindingKeys(FormSection section)
        {
            foreach (var formElement in section.Elements)
            {
                //var key = FormHelper.GetKeyRepeatableKey(formElement.Name, Section.CopyVersion);
                ElementValues[formElement.Name] = "";
            }
            if (section.SubSections != null)
            {
                foreach (var subSection in section.SubSections)
                {
                    GenerateBindingKeys(subSection);
                }
            }
        }

    }
}
