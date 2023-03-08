using System;
using System.Reflection;
/*
 * Different possible loggers:
 *		one that does nothing - not debugging
 *		one that write to the console
 *		one that writes to a file
 *		etc.
 */

public interface ILogger : IDisposable 
{

	public void enableTrace(bool enable);
	public void enableMsg(bool enable);

	public void enter();
	public void enter(object p1);
	public void enter(object p1, object p2);
	public void enter(object[] ps);
	public void msg(object msg);

	public void exit();

	public void exit(object rv);
}
