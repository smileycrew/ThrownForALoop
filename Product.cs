public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime? SoldOnDate { get; set; }
    public DateTime StockDate { get; set; }
    public int ManufactureYear { get; set; }
    public double Condition { get; set; }
    public TimeSpan TimeInStock
    {
        get
        {
            // DateTime lastDay;
            // if (SoldOnDate == null)
            // {
            //     lastDay = DateTime.Now;
            // }
            // else
            // {
            //     lastDay = (DateTime)SoldOnDate;
            // }
            // return lastDay - StockDate;
            DateTime lastDay = SoldOnDate == null ? DateTime.Now : (DateTime)SoldOnDate;
            return lastDay - StockDate;
        }
    }
}
