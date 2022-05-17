using Client.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client.Controllers;

public static class DatabaseCaller
{
    
    
    private static HttpContext HttpContext => new HttpContextAccessor().HttpContext!;

    private static async Task<HttpClient> SetToken()
    {
        string? token = await HttpContext.GetTokenAsync("access_token");
        var apiClient = new HttpClient();
        apiClient.SetBearerToken(token);
        return apiClient;
    }

    public static async Task<string> RetrieveClaimsJson()
    {
        using var apiClient = await SetToken();

        var response = await apiClient.GetAsync(DatabaseIPs.Identity);
        string content = await response.Content.ReadAsStringAsync();
        return JArray.Parse(content).ToString();
    }
    public static async Task<UserData?> RetrieveAll()
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(DatabaseIPs.RetrieveAll);
        string responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserData?>(responseJson);
    }
    
    public static async Task<UserData?> Retrieve(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(DatabaseIPs.Retrieve(id));
        string responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserData>(responseJson);
    }
    
    public static async Task<bool> Add(string userText)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync(DatabaseIPs.Add(userText), null);
        return response.IsSuccessStatusCode;
    }
    
    public static async Task<bool> DeleteAll()
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync(DatabaseIPs.DeleteAll,null);
        return response.IsSuccessStatusCode;
    }
    
    public static async Task<bool> Delete(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync(DatabaseIPs.Delete(id),null);
        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> Update(int id, string text)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.PostAsync(DatabaseIPs.Update(id, text),null);
        return response.IsSuccessStatusCode;
    }
}