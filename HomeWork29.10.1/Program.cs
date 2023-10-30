class Program
{
    static void Main(string[] args)
    {
        Money money = new Money(9, 28);
        Product product = new Product("Potato", new Money(10, 50));

        System.Console.WriteLine("Money object:");
        money.Print();
        Console.WriteLine(money);

        Console.WriteLine("\nProduct object:");
        product.Print();
        System.Console.WriteLine(product);

        Console.WriteLine("\nSybstracting 2 dollars and 30 cents from the prodect price: ");
        product.Substraction(2, 30);
        product.Print();

    }
    class Money
    {
        private int dollar;
        private int cent;

        public int Dollar
        {
            get { return dollar; }
            set { dollar = value; }
        }
        public int Cent
        {
            get { return cent; }
            set { cent = value; }
        }

        public Money() : base() { }

        public Money(int d, int c)
        {
            dollar = d;
            cent = c;
        }
        public virtual void Print()
        {
            System.Console.WriteLine($"Dollar: {dollar}");
            System.Console.WriteLine($"Cent: {cent}");
        }
        public override string ToString()
        {
            return $"Price : {dollar}.{cent}";
        }
        public void AddSum(int dollars, int cent)
        {
            dollar += dollars;
            cent += cent;

            if (cent > 99)
            {
                dollar += cent / 100;
                cent %= 100;
            }
        }
    }

    class Product : Money
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Product() : base() { name = "No name"; }
        public Product(string n, Money p)
        {
            name = n;
            Dollar = p.Dollar;
            Cent = p.Cent;
        }
        public void Substraction(int dollars, int cent)
        {
            Dollar -= dollars;
            Cent -= cent;

            if (Cent < 0)
            {
                Dollar -= 1;
                Cent = 100 + Cent;
            }

            if (Dollar < 0)
            {
                Dollar = 0;
                Cent = 0;
            }
        }
        public override void Print()
        {
            Console.WriteLine($"Product name: {name}");
            Console.WriteLine(this);

        }
    }
}

