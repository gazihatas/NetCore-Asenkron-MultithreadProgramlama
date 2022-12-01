// See https://aka.ms/new-console-template for more information
Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);
List<string> urlsList = new List<string>()
{
    "https://google.com",
    "https://microsoft.com",
    "https://amazon.com",
    "https://m11.com",
    "https://haberturk.com",
    "https://facebook.com"
};

List<Task<Content>> taskList = new List<Task<Content>>();


urlsList.ToList().ForEach(x =>
{
    taskList.Add(GetContentAsync(x));
});

Console.WriteLine("WaitAny methodundan önce");
var firstTaskIndex = Task.WaitAny(taskList.ToArray());

Console.WriteLine($"{taskList[firstTaskIndex].Result.Site} - {taskList[firstTaskIndex].Result.Len}");

static async Task<Content> GetContentAsync(string url)
{
    Content c = new Content();
    var data = await new HttpClient().GetStringAsync(url);

    c.Site = url;
    c.Len = data.Length;
    Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
    return c;
}


//Console.WriteLine($"{FirstData.Result.Site} - {FirstData.Result.Len}");

public class Content
{
    public string Site { get; set; }
    public int Len { get; set; }
}