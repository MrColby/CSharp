namespace com.logancolby.CSharp;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

/*
 * This base abstract implementation handles common function that specialized classes (
 * file, console, etc) shouldn't have to duplicate.
 * The methods track entering and exiting functions (plus messages from within).
 * Each invocation writes indented based upon its depth in the stack.
 * Untyped objects support primitives and objects (toString).
 */
public abstract class LoggerBase : ILogger {

    protected bool tracing = true;
    protected bool msging = true;
        

    public void enableTrace(bool enable)
    {
        this.tracing = enable;
    }
    public void enableMsg(bool enable)
    {
        this.msging = enable;
    }
    public abstract void enter();
    public abstract void enter(object p1);
    public abstract void enter(object p1, object p2);
    public abstract void enter(object[] ps);
    public abstract void exit();
    public abstract void exit(object rv);
    public abstract void msg(object msg);
    public abstract void Dispose();

    public static ILogger? INSTANCE = null;

    // TODO: use a system configuration of some sort to determine which logger to initialize
    public static ILogger setInstance(ILogger logger)
    {
        if (INSTANCE != null)
        {
            throw new ArgumentException("The logger instance may only be set once");
        }
        INSTANCE = logger;
        return INSTANCE;
    }

    /*
     * every invocation uses this to start the message:
     *     it indents based upon the stack trace
     *     it builds the class.method( signature
     *     it prepends the >, <, or + msg
     */
       
    private StringBuilder getBuilder(string entrySymbol)
    {
        StringBuilder builder = new StringBuilder();
        StackTrace stackTrace = new StackTrace();
        builder.Append(new String(' ', stackTrace.FrameCount-2));
        builder.Append(entrySymbol).Append(" ");
        var methodBase = stackTrace.GetFrame(3).GetMethod();
        var cls = methodBase.DeclaringType.Name;
        builder.Append(cls).Append(".").Append(methodBase.Name);
        return builder;
    }

    protected object getEnter()
    {
        StringBuilder builder = getBuilder(">");
        builder.Append("()");
        return builder.ToString();

    }

 

    protected object getEnter(object p1)
    {
        StringBuilder builder = getBuilder(">");
        builder.Append($"({p1})");
        return builder.ToString();

    }

    protected object getEnter(object p1, object p2)
    {
        StringBuilder builder = getBuilder(">");
        builder.Append($"({p1},{p2})");
        return builder.ToString();
    }

    protected object getEnter(object [] parms)
    {
        StringBuilder builder = getBuilder(">");
        builder.Append($"({parms})");
        return builder.ToString();

    }

    protected object getExit()
    {
        StringBuilder builder = getBuilder("<");
        builder.Append("()");
        return builder.ToString();
    }

    protected object getExit(object rv)
    {
        StringBuilder builder = getBuilder("<");
        builder.Append($"() -> {rv}");
        return builder.ToString();
    }

    protected object getMsg(object msg)
    {
        StringBuilder builder = getBuilder("  +");
        builder.Append($"({msg})");
        return builder.ToString();
    }

   
}
