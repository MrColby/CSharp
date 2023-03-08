namespace com.logancolby.CSharp;

using Microsoft.VisualBasic.FileIO;
using System;
using System.Reflection;




/**
 * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
 * https://www.tutorialsteacher.com/csharp/csharp-func-delegate
 * Delegates are function pointers! 
*/
public class Events : IFunctionDriver {

    public bool driveFunction()
    {
        LoggerBase.INSTANCE.enter();

        var video = new Video() { Title = "Video 1" };
        var videoEncoder = new VideoEncoder(); // publisher of events
        var mailService = new MailService(); // subscriber
        var messageService = new MessageService(); // another subscriber

        // add the mail service as a subscriber
        videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
        videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

        // now run the encoding and event handling
        videoEncoder.Encode(video);



        LoggerBase.INSTANCE.exit();
        return true;
    }

}

public class Video
{
    public string Title { get; set; } = "";
}

public class VideoEventArgs : EventArgs
{
    public Video Video { get; set; }
}

public class MessageService {
    // this is the delegate handler method, same signature as the delegate
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        LoggerBase.INSTANCE.enter(source, e);

        Console.WriteLine("Sent message: video encoded: " + e.Video.Title);

        LoggerBase.INSTANCE.exit();
    }
}

public class MailService
{
    // this is the delegate handler method, same signature as the delegate
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        LoggerBase.INSTANCE.enter(source, e);

        Console.WriteLine("Sent message: video encoded: " + e.Video.Title);

        LoggerBase.INSTANCE.exit();
    }
}

public class VideoEncoder
{
    // this is the delegate for anyone wanted to be notified
    public event EventHandler<VideoEventArgs> VideoEncoded;

    //  this method raises the event
    protected virtual void OnVideoEncoded(Video video)
    {
        LoggerBase.INSTANCE.enter(video);

        if (VideoEncoded != null) VideoEncoded(this, new VideoEventArgs() { Video = video});

        LoggerBase.INSTANCE.exit();
    }
    public void Encode(Video video)
    {
        LoggerBase.INSTANCE.enter(video);

        Console.WriteLine("Encoding . . .");
        Thread.Sleep(3000);
        OnVideoEncoded(video);
        LoggerBase.INSTANCE.exit();
    }
}
