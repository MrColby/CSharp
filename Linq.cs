namespace com.logancolby.CSharp;

using System;
using System.Linq;
using System.Reflection;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
 * LINQ: Language Integrated Query
 * 
 * Source for shuffle: https://stackoverflow.com/questions/273313/randomize-a-listt
*/
public class Linq : IFunctionDriver {
    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        var priceCutoff = 3.00;

        var itemsForSale = InitializeItemsForSale();


        // without linq

        var cheapItems = new List<ItemForSale>();
        foreach (var item in itemsForSale)
        {
            if (item.Price < priceCutoff)
            {
                cheapItems.Add(item);
            }
        }


        ///////////////////////// LINQ Extension Methods /////////////////////

        // you can use a lambda expression to convert items to price comparison
        var w = itemsForSale
            .Where(item => item.Price < priceCutoff).ToArray();

        // you can chain expressions together
        var x = itemsForSale
            .Where(item => item.Price < priceCutoff)
            .OrderBy(item => item.Name)
            .ToArray();

        // you can pull out their fields
        var y = itemsForSale
            .Where(item => item.Price < priceCutoff)
            .OrderBy(item => item.Name)
            .Select(item => item.Name)
            .ToArray();


        // or use this traditional format instead. 

        ///// LINQ Query Operators ///////

        var z = from item in itemsForSale
                where item.Price < priceCutoff
                orderby item.Name
                select item.Name;
                

        LoggerBase.INSTANCE.msg(string.Join(", ", z.ToArray()));

        // you can get one item (if you're sure there's one)
        var a = itemsForSale
            .Single(item => item.Name == "potato")
            .Category;
        LoggerBase.INSTANCE.msg("single result's category: " + a);

        // no errors if there's none, or if there's more than one. May return null in this case.
        var b = itemsForSale
            .FirstOrDefault(item => item.Name == "potato");

        // paging. Skip 2, take the next 3.
        var threeItems = itemsForSale
            .Skip(2)
            .Take(3);

        // find the max whatever
        var highestPrice = itemsForSale.Max(item => item.Price);
        LoggerBase.INSTANCE.msg("Max: " + highestPrice);
        


        LoggerBase.INSTANCE.exit();
        return true;
    }

    private static List<ItemForSale> InitializeItemsForSale()
    {
        List<ItemForSale> itemsForSale = new List<ItemForSale>();

        String[] categories = { "books", "electronics", "cookware"};

        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"things.txt");
        string[] things = File.ReadAllLines(path);
        var random = new Random();
        for (var i=0; i < things.Length; i++)
        {
            var thing = things[i];
            var cost = Math.Round(random.NextDouble() * 10 + 1, 2);
            var category = categories[random.Next(0, categories.Length - 1)];
            itemsForSale.Add(new ItemForSale(thing, cost, category));
        }
        itemsForSale.Add(new ItemForSale("potato", 0.50, "food"));

        itemsForSale.Shuffle();

        return itemsForSale;

    }
}



public class ItemForSale
{
    public ItemForSale(string name, double price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

    public override string ToString()
    {
        return Name + " (" + Category + ") $" + Price;
    }


}

public static class ThreadSafeRandom {
    [ThreadStatic] private static Random Local;

    public static Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}

static class MyExtensions {

    // based on the Fisher-Yates shuffle
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}





