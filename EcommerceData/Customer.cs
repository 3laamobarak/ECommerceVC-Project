namespace EcommercModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }
        public decimal Salary { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
