// Create a class to Greet friends

class cGreet
{
	public void greet(){
		System.Console.WriteLine("Hello Friends!!!");
	}
}

class TestGreet
{
	public static void Main(System.String[] args)
	{
		cGreet objcGreet = new cGreet();
		objcGreet.greet();
	}
}