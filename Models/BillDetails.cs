namespace MockPrj.Models
{
    public class BillDetails
    {
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; } 
    }
}