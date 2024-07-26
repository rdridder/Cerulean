namespace Cosmos.Data.Cerulean.Cloud
{
    public class FormElement
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }

        public FormElement GetElementCopy(int copyVersion)
        {
            return new FormElement() { 
                Type = Type, 
                Name = $"{Name}_{copyVersion}", 
                Label = Label, 
                PlaceHolder = PlaceHolder };
        }
    }
}
