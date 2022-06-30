namespace Standardly.Core.Models.FileItems
{
    public class FileItem
    {
        public string Template { get; set; }
        public string Target { get; set; }
        public bool? Replace { get; set; } = false;
    }
}
