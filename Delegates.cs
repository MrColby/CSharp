namespace com.logancolby.CSharp;

using System;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
 * https://www.tutorialsteacher.com/csharp/csharp-func-delegate
 * Delegates are function pointers! 
*/
public class Delegates : IFunctionDriver {

    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        // this is our text document. It holds text.
        // we can pass methods in as delegates to do things to that text.
        TextDocument textDocument = new TextDocument();

        LoggerBase.INSTANCE.msg("Before: " + textDocument.Text);


        // defines a method of a spell checker instance to be a delegate.
        SpellChecker spellChecker = new SpellChecker();
        TextDocument.TextEditorDelegate textEditorDelegate = spellChecker.spellCheck;

        // we can chain delegates together by adding them in.
        // here we add a static method.
        textEditorDelegate += EndPunctuationChecker.checkEndPunctuation;

        // send in the delegates to process the text
        textDocument.autoCorrectText(textEditorDelegate);

        // C# provides system delegates. Func delegates return values. Action delegates don't.
        // We can combine that with anonymous methods.
        // The last parameter is the return type.
        // This instance will capitalize the first letter.
        Action<TextDocument> actionDelegate = delegate (TextDocument doc)
        {
            LoggerBase.INSTANCE.enter(doc);
            doc.Text = "T" + doc.Text.Substring(1);
            LoggerBase.INSTANCE.exit();
        };

        // we can also use lambda expressions. This one is the best-word checker.
        // It'll replace the word leap with the word jump.
        actionDelegate += (doc) => { doc.Text= doc.Text.Replace("leap", "jump"); };

        // now have the text document run the two delegates.
        textDocument.autoCorrectText(actionDelegate);


        LoggerBase.INSTANCE.msg("After: " + textDocument.Text);



        LoggerBase.INSTANCE.exit();
        return true;
    }

}

/*
 * Because the delegate is just a method operating in the context of where it is
 * passed to, static methods work fine of course as well.
 */
public static class EndPunctuationChecker
{
    public static void checkEndPunctuation(TextDocument doc)
    {
        LoggerBase.INSTANCE.enter(doc);
        doc.Text = doc.Text + ".";
        LoggerBase.INSTANCE.exit();
    }
}





/*
 * This is a spell checker. It's going to be USED as a delegate, even though note it's not
 * declared as such. It's the method itself that will be passed to TextDocument to work on it.
 * It's like the method is being loaned to another class.
 */
public class SpellChecker
{
    public void spellCheck(TextDocument doc)
    {
        LoggerBase.INSTANCE.enter(doc);
        doc.Text = doc.Text.Replace("kwik", "quick");
        LoggerBase.INSTANCE.exit();
    }
}


/*
 * This is a class that represents a text document. 
 * It supports delegates to auto-edit content.
 * Different delegates can edit different aspects of the text.
 * 
 * */
public class TextDocument {

    public string Text { get; set; }

    public TextDocument() {
        this.Text = "the kwik brown fox leaps over the lazy dog";
    }


    // delegates auto-correct text. The string is the text to modify. because strings
    // are immutable, a new string is returned. This delegate is really just a method,
    // or a list of pointers to methods, ala C. New delegates can be designed and implemented
    // without the class ever needing to be changed to learn about that.
    public delegate void TextEditorDelegate(TextDocument textDocument);

    // the delegate is really just a method. So here it gets to do its thing.
    // interesting that because the method is passed into the class to execute,
    // it gets access to private data. Cool.
    public void autoCorrectText(TextEditorDelegate textEditorDelegate)
    {
        LoggerBase.INSTANCE.enter(textEditorDelegate);
        textEditorDelegate(this);
        LoggerBase.INSTANCE.exit();
    }

    // we don't need to define our own delegates. C# system defines Func delegates
    // that return values, and Action delegates that don't. 
    public void autoCorrectText(Action<TextDocument> textEditorDelegate)
    {
        LoggerBase.INSTANCE.enter(textEditorDelegate);
        textEditorDelegate(this);
        LoggerBase.INSTANCE.exit();
    }

}






