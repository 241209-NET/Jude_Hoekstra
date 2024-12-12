// See https://aka.ms/new-console-template for more information
class bankingSimulator
{
    private decimal balance = 0;
    private decimal cashOnHand = 1000;
    private int year = 0;

    public static void Main(string[] args)
    {
        bankingSimulator BS = new bankingSimulator();
        BS.balance = 0;
        BS.cashOnHand = 1000;
        BS.year = 0;
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = BS.MainMenu();
        }
    }


    private bool MainMenu()
    {
        //Console.WriteLine("");
        Console.Clear();
        Console.WriteLine("Year: " + year);
        Console.WriteLine("Cash on hand: " + cashOnHand);
        Console.WriteLine("Balance: " + balance);
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Add Money");
        Console.WriteLine("2) Withdraw Money");
        Console.WriteLine("3) Invest Money in Account");
        Console.WriteLine("4) Exit");
        Console.Write("Select an option: ");
        bool entered = false;
        switch (Console.ReadLine())
        { 
                
            case "1":
                entered = false;
                while (entered == false)
                {
                    Console.WriteLine("Please enter the amount you would like to add: ");

                    string? input = Console.ReadLine();
                    try
                    {
                        int num = int.Parse(input!);
                        AddMoney(num);
                        return true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                return true;
            case "2":
                entered = false;
                while (entered == false)
                {
                    Console.WriteLine("Please enter the amount you would like to withdraw: ");

                    string? input = Console.ReadLine();
                    try
                    {
                        int num = int.Parse(input!);
                        WithdrawMoney(num);
                        return true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                return true;
            case "3":
                investMoney();
                return true;
                
            case "4":
                return false;
            default:
                return true;
        }
    }
    

    private void AddMoney(int startingNumber)
    {
        Console.WriteLine("Current balance:" + balance);
        if (startingNumber <= cashOnHand)
        {
            balance += startingNumber;
            cashOnHand -= startingNumber;
            Console.WriteLine("Current balance:" + balance);
        }
        else
        {
            balance += cashOnHand;
            cashOnHand = 0;
            Console.WriteLine("Adding all cash on hand");
            Console.WriteLine("Current balance:" + balance);
        }
    }

    private void WithdrawMoney(int startingNumber)
    {
        if (startingNumber > balance)
        {
            decimal returnAmount = balance;
            cashOnHand += balance;
            balance = 0;
            Console.WriteLine("Withdraw exceeded balance, withdrawing available balance");
        }
        else
        {
            balance -= startingNumber;
            cashOnHand += startingNumber;
        }
    }

    private void investMoney()
    {
        Console.WriteLine("A year passes");
        year += 1;
        balance *= 1.08m;
    }
}





