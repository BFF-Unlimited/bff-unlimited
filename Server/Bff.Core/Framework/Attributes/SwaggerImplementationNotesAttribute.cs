namespace Bff.Core.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerImplementationNotesAttribute : Attribute
    {
        public string ImplementationNotes { get; private set; }

        public SwaggerImplementationNotesAttribute(string implementationNotes)
        {
            this.ImplementationNotes = implementationNotes;
        }
    }
}
