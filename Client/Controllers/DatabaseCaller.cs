﻿using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserTextDataApi.Data;

namespace Client.Controllers;

/*TODO: Add IsSuccess handlers
 if (!response.IsSuccessStatusCode)
 {
     Console.WriteLine(response.StatusCode);
 }
*/
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

    public static async Task<UserData?> RetrieveAll()
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(DatabaseIPs.RetrieveAll);
        string responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserData?>(responseJson);
    }
    
    /// <summary>
    /// Returns UserTextData model with a single text in a list Texts
    /// or null if index is outside of bounds
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static async Task<UserData?> Retrieve(int id)
    {
        using var apiClient = await SetToken();
        var response = await apiClient.GetAsync(DatabaseIPs.Retrieve(id));
        string responseJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserData>(responseJson);
    }
    
    public static async Task Add(string userText)
    {
        using var apiClient = await SetToken();
        _ = await apiClient.PostAsync(DatabaseIPs.Add(userText), null);
    }
    
    public static async Task DeleteAll()
    {
        using var apiClient = await SetToken();
        _ = await apiClient.PostAsync(DatabaseIPs.DeleteAll,null);
    }
    
    public static async Task Delete(int id)
    {
        using var apiClient = await SetToken();
        _ = await apiClient.PostAsync(DatabaseIPs.Delete(id),null);
    }

    public static async Task Update(int id, string text)
    {
        using var apiClient = await SetToken();
        _ = await apiClient.PostAsync(DatabaseIPs.Update(id, text),null);
    }
    
    public static async Task<string> RetrieveClaimsJson()
    {
        using var apiClient = await SetToken();

        var response = await apiClient.GetAsync(DatabaseIPs.Identity);
        string content = await response.Content.ReadAsStringAsync();
        return JArray.Parse(content).ToString();
    }
}