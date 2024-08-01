using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Statics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Text;

namespace Frontend.Cerulean.Cloud.Components.Base
{
    public abstract class BaseInputComponent : ComponentBase
    {
        [Parameter, EditorRequired]
        public required Dictionary<string, object> ElementValues { get; init; }

        [Parameter, EditorRequired]
        public required FormElement Element { get; init; }

        [Parameter]
        public bool IsRepeatable { get; set; }

        [CascadingParameter]
        public EditContext? EditContext { get; set; }

        public abstract string ElementClass { get; }

        public string ProcessedElementClass { get {
                if (HasErrors) {
                    return $"{ElementClass} is-invalid";
                }
                return ElementClass;
            } 
        }

        public bool HasErrors { 
            get {
                var messages = EditContext?.GetValidationMessages(() => Element.Name);
                if (messages?.Any() ?? false) {
                    return true;
                }
                return false;
            } 
        }

        public string elementClass { get {
                StringBuilder stringBuilder = new StringBuilder("");
                
                return "";    
            } 
        }

        public string Key { get; set; }

        protected override void OnInitialized()
        {
            Key = FormHelper.GetKeyRepeatableKey(IsRepeatable, Element.Name);
        }
    }
}
