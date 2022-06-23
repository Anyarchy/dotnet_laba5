namespace Order.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        private static int amount = 0;

        public Client(string fio)
        {
            amount++;
            Id = amount;
            FIO = fio;
        }
    }
}
