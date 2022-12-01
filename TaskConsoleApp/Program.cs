 static void calis(Task<string> data)
{
    Console.WriteLine("data uzunluk:" + data.Result.Length);
}


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var mytask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(calis);

//ContinueWith((data) =>
//{
//    //Gelen data bir task oldupun dolayı sonucunu almak için Result Property sini kullanıyoruz.
//    Console.WriteLine("data uzunluk: " +data.Result.Length);
//});

Console.WriteLine("Arada yapılacak işler");

await mytask;

//var data = await mytask;
    
//Console.WriteLine("data uzunluk: " + data.Length);