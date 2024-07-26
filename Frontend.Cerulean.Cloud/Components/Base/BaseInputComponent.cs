using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Statics;
using Microsoft.AspNetCore.Components;

namespace Frontend.Cerulean.Cloud.Components.Base
{
    public class BaseInputComponent : ComponentBase
    {
        [Parameter, EditorRequired]
        public required Dictionary<string, object> ElementValues { get; init; }

        [Parameter, EditorRequired]
        public required FormElement Element { get; init; }

        [Parameter]
        public bool IsRepeatable { get; set; }

        public string Key { get; set; }

        protected override void OnInitialized()
        {
            Key = FormHelper.GetKeyRepeatableKey(IsRepeatable, Element.Name);
        }
    }
}
