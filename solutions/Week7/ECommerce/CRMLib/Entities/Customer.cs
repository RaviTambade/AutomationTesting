namespace CRMLib.Entities
{

    //POCO class as Customer
    //Plain Old CLR Object

    public class Customer
    {
        //Auto Property
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
