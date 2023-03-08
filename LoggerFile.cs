namespace com.logancolby.CSharp;

using System;
using System.Reflection;


/*
 * This class writes trace messages to a file. 
 * TODO: specify the location of the file using an environment property.
 * TODO: test that the file is writable by the user. 
 */
public class LoggerFile : LoggerBase {

    private const string FILE_PATH = @"C:\Temp\CSharp.txt";
    private static StreamWriter _writer;

    static LoggerFile()
    {
        var file = File.Open(FILE_PATH, FileMode.Create, FileAccess.Write);
        _writer = new StreamWriter(file);
    }

    public override void Dispose()
    {
        _writer.Flush();
        _writer.Close();

    }


    public override void enter()
    {
        if (this.tracing)
        {
            var str = this.getEnter();
            _writer.WriteLine(str);
        }
    }

    public override void enter(object p1)
    {
        if (this.tracing)
        {
            var str = this.getEnter(p1);
            _writer.WriteLine(str);
        }

    }

    public override void enter(object p1, object p2)
    {
        if (this.tracing)
        {
            var str = this.getEnter(p1, p2);
            _writer.WriteLine(str);
        }
    }

    public override void enter(object[] ps)
    {
        if (this.tracing)
        {
            var str = this.getEnter(ps);
            _writer.WriteLine(str);
        }
    }

    public override void exit()
    {
        if (this.tracing)
        {
            var str = this.getExit();
            _writer.WriteLine(str);
        }
    }

    public override void exit(object rv)
    {
        if (this.tracing)
        {
            var str = this.getExit(rv);
            _writer.WriteLine(str);
        }
    }

    public override void msg(object msg)
    {
        if (this.msging)
        {
            var str = this.getMsg(msg);
            _writer.WriteLine(str);
        }
    }
}
