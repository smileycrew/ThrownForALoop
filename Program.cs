﻿List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.20M,
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 1999,
        Condition = 3.9
    },
    new Product()
    {
        Name = "Basketball",
        Price = 15.00M,
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 2000,
        Condition = 4.1
    },
    new Product()
    {
        Name = "Hoop",
        Price = 50.00M,
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 2001,
        Condition = 3.4
    },
    new Product()
    {
        Name = "Mountain Bike",
        Price = 199.00M,
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 2002,
        Condition = 4.8
    },
    new Product()
    {
        Name = "Electric Jeep",
        Price = 349.00M,
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 2003,
        Condition = 3.1
    },
    new Product()
    {
        Name = "Electric Scooter",
        Price = 179.00M,
        SoldOnDate = new DateTime(2023, 11, 26),
        StockDate = new DateTime(2023, 11, 24),
        ManufactureYear = 2004,
        Condition = 3.8
    },
    new Product()
    {
        Name = "Outdoor Boots",
        Price = 39.99M,
        SoldOnDate = new DateTime(2023, 11, 26),
        StockDate = new DateTime(2023, 11, 14),
        ManufactureYear = 2022,
        Condition = 4.5
    },
    new Product()
    {
        Name = "Protable Chair",
        Price = 49.99M,
        SoldOnDate = new DateTime(2023, 11, 26),
        StockDate = new DateTime(2023, 11, 14),
        ManufactureYear = 2022,
        Condition = 4.8
    },
    new Product()
    {
        Name = "Hunting Hat",
        Price = 6.99M,
        SoldOnDate = new DateTime(2023, 11, 26),
        StockDate = new DateTime(2023, 11, 14),
        ManufactureYear = 2022,
        Condition = 4.2
    }
};

string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

string choice = null;

while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. View All products
    2. View product details
    3. View latest products
    4. monthly sales report
    5. add a product
    6. buy a product
    7. average time stocked
    8. average time sold");

    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("Goodbye");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
    else if (choice == "4")
    {
        MonthlySalesReport();
    }
    else if (choice == "5")
    {
        AddProduct();
    }
    else if (choice == "6")
    {
        BuyProduct();
    }
    else if (choice == "7")
    {
        AverageTimeStocked();
    }
    else if (choice == "8")
    {
        AverageTimeSold();
    }
}

void ViewProductDetails()
{

    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number:");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }
    Console.WriteLine(@$"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    It is {DateTime.Now.Year - chosenProduct.ManufactureYear} years old.
    It {(chosenProduct.SoldOnDate != null ? "is not available" : $"has been in stock for {chosenProduct.TimeInStock.Days} days.")}
    The item's condition rating is {chosenProduct.Condition} out of 5.");
    if (chosenProduct.SoldOnDate == null)
    {
        Console.WriteLine("would you like to buy the product? yes or no?");
        string response = Console.ReadLine().Trim();
        if (response == "yes")
        {
            chosenProduct.SoldOnDate = DateTime.Now;
        }
        else
        {
            Console.WriteLine("returning to main menu...");
        }
    }
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    Console.WriteLine($"Total inventory value: ${totalValue}");
    foreach (Product product in products)
    {
        if (product.SoldOnDate == null)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty list to store the latest products
    List<Product> latestProducts = new List<Product>();
    // calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    // loop through the products
    foreach (Product product in products)
    {
        // add a products to latestProducts if it fits the criteria
        // if (product.StockDate > threeMonthsAgo && !product.Sold)
        // {
        //     latestProducts.Add(product);
        // }
    }
    // print out the latest products to the console
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

void MonthlySalesReport()
{
    int month = 0;
    while (month == 0)
    {
        try
        {
            Console.WriteLine("enter a month");
            int response = int.Parse(Console.ReadLine().Trim());
            if (response > 0 && response < 13)
            {
                month = response;
            }
            else
            {
                Console.WriteLine("try again");
            }
        }
        catch (FormatException)
        { Console.WriteLine("you entered a string"); }

    }
    int year = 0;
    while (year == 0)
    {
        try
        {
            Console.WriteLine("enter a year");
            int response = int.Parse(Console.ReadLine().Trim());
            if (response > 0 && response <= DateTime.Now.Year)
            {
                year = response;
            }
            else
            {
                Console.WriteLine("try again");
            }
        }
        catch (FormatException)
        { Console.WriteLine("you entered a string"); }
    }
    List<Product> monthlySales = new List<Product>();
    monthlySales = products.Where((product) => product.SoldOnDate != null).ToList();
    decimal totalPrice = 0M;
    foreach (Product monthlySale in monthlySales)
    {
        if (monthlySale.SoldOnDate.Value.Year == year && monthlySale.SoldOnDate.Value.Month == month)
            Console.WriteLine($"{monthlySale.Name} was sold");
        totalPrice += monthlySale.Price;
    }
    Console.WriteLine($"total price of monthly sales... {totalPrice}");
}
// this needs to be updated
void AddProduct()
{
    Product newProduct = new Product();

    Console.WriteLine("name of product...");
    newProduct.Name = Console.ReadLine().Trim();
    Console.WriteLine($"given name is ... {newProduct.Name}");

    Console.WriteLine("price of product...");
    newProduct.Price = decimal.Parse(Console.ReadLine().Trim());
    Console.WriteLine($"given price is ... {newProduct.Price}");

    newProduct.StockDate = DateTime.Now;
    Console.WriteLine($"given product will be stocked on ... {newProduct.StockDate}");

    Console.WriteLine("manufactured year of product...");
    newProduct.ManufactureYear = int.Parse(Console.ReadLine().Trim());
    Console.WriteLine($"given manufactured year is ... {newProduct.ManufactureYear}");

    Console.WriteLine("condition of product...");
    newProduct.Condition = int.Parse(Console.ReadLine().Trim());
    Console.WriteLine($"given condition is ... {newProduct.Condition}");

    products.Add(newProduct);
}
// this needs to be updated
void BuyProduct()
{
    List<Product> unsoldList = products.Where((product) => product.SoldOnDate == null).ToList();
    for (int i = 0; i < unsoldList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {unsoldList[i].Name}");
    }
    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        try
        {
            chosenProduct = unsoldList[int.Parse(Console.ReadLine().Trim()) - 1];
            chosenProduct.SoldOnDate = DateTime.Now;
            Console.WriteLine($"you bought... {chosenProduct.Name}");
        }
        catch (FormatException)
        { Console.WriteLine("wrong format"); }
    }
}

void AverageTimeStocked()
{
    // Allow the user to see the average time that currently stocked products have been on the shelf (in days).
    List<Product> unsoldProducts = products.Where((product) => product.SoldOnDate == null).ToList();
    TimeSpan averageDays = TimeSpan.Zero;
    unsoldProducts.ForEach((product) => averageDays += product.TimeInStock);
    Console.WriteLine($"average shelf time of products in stock is... {averageDays.Days / unsoldProducts.Count} days");
}

void AverageTimeSold()
{
    List<Product> soldProducts = products.Where((product) => product.SoldOnDate != null).ToList();
    TimeSpan timeSpan = TimeSpan.Zero;
    soldProducts.ForEach((product) => timeSpan += product.TimeInStock);
    Console.WriteLine($"average time on shelf before products were sold... {timeSpan.Days / soldProducts.Count} days");
}
// come back and add the hours challenge