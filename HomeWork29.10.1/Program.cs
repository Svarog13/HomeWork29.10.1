Money money = new Money(9,28);
Product product = new Product("Kartoplya",new Money(10,50));

//money.Print();

System.Console.WriteLine(money.ToString());
//System.Console.WriteLine(product);
product.Print();
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
	public void AddSum(int dollar, int cent)
	{
		if (cent > 99)
		{
			dollar++;
			cent = this.cent - 100;
			//this.dollar += cent / 100;
		}
		else
		{
            this.dollar += dollar;
            this.cent += cent;
        }
	}
}

class Product : Money
{
	private string name;
	private Money price;

	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public Money Price
	{
		get { return price; }
		set { price = value; }
	}
	public Product() : base() { name = "No name"; }
    public Product(string n, Money p)
	{
		this.name = n;
		this.price = p;
	}
	public void Substraction(int dollar, int cent)
	{
		price.Dollar -= dollar;
		price.Cent -= cent;
		if (cent > price.Cent)
		{
			price.Dollar -= 1;
			price.Cent = price.Cent + 100 - cent;
        }
		if (price.Dollar < 0 || price.Cent < 0)
		{
			price.Dollar = 0;
			price.Cent = 0;
		}
	}
    public override void Print()
    {
		System.Console.WriteLine($"Product name - {name}");
        Console.WriteLine($"{price.Dollar}.{price.Cent}");
		//base.Print();
	}

}
