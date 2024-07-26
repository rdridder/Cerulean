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

        protected override void OnInitialized()
        {
            IsRepeatable = Section.IsRepeatable;
        }

    }
}
