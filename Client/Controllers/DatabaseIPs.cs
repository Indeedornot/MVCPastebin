namespace Client.Controllers;

public static class DatabaseIPs
{
    private const string WebApiUri = @"https://localhost:6001/";
    
    public static string Retrieve(int id) => WebApiUri + $"Retrieve/{id}";
    public static string RetrieveAll => WebApiUri + $"RetrieveAll";
    public static string Delete(int id) => WebApiUri + $"Delete/{id}" ;
    public const string DeleteAll = WebApiUri + "DeleteAll";
    public static string Add(string userText) => WebApiUri + $"Add/{userText}";
    public static string Update(int id, string text) => WebApiUri + $"Update/{id}/{text}";
    public const string Identity = WebApiUri + "identity";
}