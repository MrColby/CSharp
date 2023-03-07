namespace com.logancolby.CSharp;

using System;
using System.Reflection;

/*
 * Tracing is very expensive performance-wise: it uses a stack trace on every
 * invocation. So this does nothing. There are other ways to design this. Each
 * call could test, so the compiler could potentially pull it out. But good enough
 * for a toy environment.
 */
public class LoggerDisabled : LoggerBase {

    public override void Dispose()
    {
        
    }

    public override void enter()
    {
    }

    public override void enter(object p1)
    {
    }

    public override void enter(object p1, object p2)
    {
    }


    public override void enter(object[] ps)
    {
    }

    public override void exit()
    {
    }

    public override void exit(object rv)
    {
    }

    public override void msg(object msg)
    {
    }
}
