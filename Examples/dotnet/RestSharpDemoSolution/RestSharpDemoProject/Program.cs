using RestSharp;

Console.Write("Enter the product id: ");
var id = Console.ReadLine();

RestClient client = new RestClient("https://fakestoreapi.com/");

RestRequest request = new RestRequest($"products/{id}");
var response = client.Execute(request);

Console.WriteLine($"Status code = {response.StatusCode}");
Console.WriteLine($"Status Text = {response.ResponseStatus}");
Console.WriteLine($"Content type = {response.ContentType}");

if (response.IsSuccessful)
{
    Console.WriteLine($"Content = {response.Content}");
}
else
{
    Console.WriteLine(response.ErrorMessage);
}
