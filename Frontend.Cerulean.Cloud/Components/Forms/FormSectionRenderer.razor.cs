using Cosmos.Data.Cerulean.Cloud;
using Microsoft.AspNetCore.Components;

namespace Frontend.Cerulean.Cloud.Components.Forms
{
    public partial class FormSectionRenderer
    {
        [Parameter, EditorRequired]
        public required FormSection Section { get; init; }

        [Parameter, EditorRequired]
        public required Dictionary<string, object> ElementValues { get; init; }

        private bool IsRepeatable { get; set; }

        private int copyNumber;

        protected override void OnInitialized()
        {
            IsRepeatable = Section.IsRepeatable;
            copyNumber = Section?.SubSections?.Count + 2 ?? 2;
        }

        private void AddFormSection(string label)
        {
            var copiedSection = Section.GetElementCopy(copyNumber);
            GenerateBindingKeys(copiedSection);
            if (Section.SubSections == null)
            {
                Section.SubSections = new List<FormSection>();
            }
            copyNumber++;
            Section.SubSections.Add(copiedSection);
        }

        private void GenerateBindingKeys(FormSection section)
        {
            foreach (var formElement in section.Elements)
            {
                ElementValues[formElement.Name] = "";
            }
            if (section.SubSections != null)
            {
                foreach (var subSection in section.SubSections)
                {
                    GenerateBindingKeys(section);
                }
            }
        }

    }
}
