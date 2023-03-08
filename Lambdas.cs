namespace com.logancolby.CSharp;

using System;
using System.Security.Cryptography.X509Certificates;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
 * Lambda expressions and anonymous functions
*/
public class Lambdas : IFunctionDriver {

    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        // lambda expressions create anonymous functions. The lambda operator => separates the parameter list
        // from its body. 
        // expression lambda: (input-parameters) => expression
        // statement lambda: (input parameters) => { sequence of statements }

        int factor = 5;
        // remember: the first int is the parameter, the second int is the return value.
        // so this is equivalent public int square (int x) { return x * x; }
        // it defines a named function scoped to the method in which it is declared
        // and executed as a delegate func.
        Func<int, int> square = x => x * x;
        Console.WriteLine("The square of " + factor + " = " + square(factor));

        // this shows how lamba expressions can define predicates to search lists, for example.
        this.bookExamples();

        // here's a lamda that takes no parameters and does something.
        var h = () =>  Console.WriteLine("yo");
        h();

        LoggerBase.INSTANCE.exit(true);

        return true;

    }

    private void bookExamples()
    {
        LoggerBase.INSTANCE.enter();
        List<Book> books = new List<Book>()
        {new Book("A", 5.00),new Book("B", 7.00), new Book("C", 9.00), new Book("D", 11.00)};

        // this uses a static function predicate to search
        List<Book> expensiveBooks = books.FindAll(isMoreExpensiveThan);
        Console.WriteLine("Expensive books: " + expensiveBooks.Count);

        // this uses a lambda. 
        expensiveBooks = books.FindAll(book => book.cost > 10) ;
        Console.WriteLine("Expensive books: " + expensiveBooks.Count);
        LoggerBase.INSTANCE.exit();

    }

    // a predicate for searching our list
    static bool isMoreExpensiveThan(Book book)
    {
        LoggerBase.INSTANCE.enter(book);
        var rv = book.cost > 10;
        LoggerBase.INSTANCE.exit(rv);
        return rv;
    }

    class Book
    {
        public string title { get; set; }
        public double cost { get; set; }

        public Book (string title, double cost)
        {
            this.title = title;
            this.cost = cost;

        }


    }
}







