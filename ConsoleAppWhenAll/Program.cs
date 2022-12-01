// See https://aka.ms/new-console-template for more information
Console.WriteLine("Main Thread: "+ Thread.CurrentThread.ManagedThreadId);
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

var contents = Task.WhenAll(taskList.ToArray());

Console.WriteLine("WhenAll method'dan sonra başka işler yaptım");

var data = await contents;

data.ToList().ForEach(x =>
{
    Console.WriteLine($"{x.Site} boyut:{x.Len}");
});

//contents.ToList().ForEach(x =>
//{
//    Console.WriteLine($"{x.Site} boyut:{x.Len}");
//});

static async Task<Content> GetContentAsync(string url)
{
    Content c = new Content();
    var data = await new HttpClient().GetStringAsync(url);

    c.Site = url;
    c.Len = data.Length;
    Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
    return c;
}

public class Content
{
    public string Site { get; set; }
    public int Len { get; set; }
}