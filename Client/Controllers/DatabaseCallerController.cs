using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserTextDataApi.Data;

namespace Client.Controllers;

//TODO: Add IsSuccess handlers
public class DatabaseCaller
{
    private static HttpContext HttpContext => new HttpContextAccessor().HttpContext!;

    private static async Task<HttpClient> SetToken()
    {
        string? token = await HttpContext.GetTokenAsync("access_token");
        var apiClient = new HttpClient();
        apiClient.SetBearerToken(token);
        apiClient.BaseAddress = new Uri(@"https://localhost:6001/");
        return apiClient;
    }
    
    //TODO Add retrieve single

    public static async Task<UserTextData?> RetrieveAll()
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync($"RetrieveAll");
        string responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserTextData?>(responseJson);
    }
    
    /// <summary>
    /// Returns UserTextData model with a single text in a list Texts
    /// or null if index is outside of bounds
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static async Task<UserTextData?> Retrieve(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync($"Retrieve/{id}");
        string responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserTextData>(responseJson);
    }

    // GET: UserData/Add
    public static async Task Add(string userText)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync($"Add/{userText}", null);
    }

    // GET: UserData/Delete/
    public static async Task Delete()
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync("Delete",null);
    }
    
    // GET: UserData/Delete/5
    public static async Task Delete(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync("Delete/{id}",null);
    }
    
    public static async Task<string> RetrieveClaimsJson()
    {
        using var apiClient = await SetToken();

        var response = await apiClient.GetAsync("identity");
        // if (!response.IsSuccessStatusCode)
        // {
        //     Console.WriteLine(response.StatusCode);
        // }
        string content = await response.Content.ReadAsStringAsync();
        return JArray.Parse(content).ToString();
    }
}