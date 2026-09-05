namespace ProductSystem.Models
{
    //Representação de um produto dentro do C#
    public class Product
    {
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string RegisteredBy { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }
    }
}
