namespace CustomerPortal.Models.Entities
{
    public class Customer
    {
        //data member properties
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerRegion { get; set; }
        public bool isSubscribed { get; set; }
    }
}
