namespace TEDU_MVC.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceProjectlist = new ReferenceProject();
        }

        public ReferenceProject ReferenceProjectlist { get; set; }
    }
}
