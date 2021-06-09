namespace ApiVersioningPoc.Models
{
    public class Version
    {
        public string Name { get; set; }

        public Version(string name)
        {
            Name = name;
        }
    }
}