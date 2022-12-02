
var myTask = Task.Factory.StartNew((Object) =>
{
    Console.WriteLine("myTask Çalıştı");
    var status = Object as Status;

    status.threadId = Thread.CurrentThread.ManagedThreadId;

}, new Status() { date = DateTime.Now });


await myTask;

Status s = myTask.AsyncState as Status;

Console.WriteLine(s.date);
Console.WriteLine(s.threadId);




public class Status
{
    public int threadId { get; set; }
    public DateTime date { get; set; }
}

public class Content
{
    public string Site { get; set; }
    public int Len { get; set; }
}