namespace com.logancolby.CSharp;

using System;
using System.Reflection;

/*
 * This class writes trace messages to the console.
 */
public class LoggerConsole : LoggerBase {

    public override void Dispose()
    {
        
    }

    public override void enter()
    {
        var str = this.getEnter();
        Console.WriteLine(str);
    }

    public override void enter(object p1)
    {
        var str = this.getEnter(p1);
        Console.WriteLine(str);

    }

    public override void enter(object p1, object p2)
    {
        var str = this.getEnter(p1, p2);
        Console.WriteLine(str);
    }

    public override void enter(object[] ps)
    {
        var str = this.getEnter(ps);
        Console.WriteLine(str);
    }

    public override void exit()
    {
        var str = this.getExit();
        Console.WriteLine(str);
    }

    public override void exit(object rv)
    {
        var str = this.getExit(rv);
        Console.WriteLine(str);
    }

    public override void msg(object msg)
    {
        var str = this.getMsg(msg);
        Console.WriteLine(str);
    }
}
