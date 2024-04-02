using System;

namespace ERMM.GenericData.Utility
{
    public class DisplayText : Attribute
    {
        public DisplayText(string Text)
        {
            this.text = Text;
        }


        private string text;


        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public bool compareIgnoreCase(string value)
        {
            return text.Equals(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
