using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTextDataApi.Data;
using Z.EntityFramework.Plus;

namespace UserTextDataApi.Controllers;

public class DatabaseInteractionController : Controller
{
    private readonly UserDataDbContext _context;

    public async Task<UserData?> FindWithText(int userId) =>
        await _context.UserData.Include(x => x.Texts).FirstOrDefaultAsync(x => x.Id == userId);

    public UserText Text(string text) => new UserText(text);

    public DatabaseInteractionController(UserDataDbContext context)
    {
        _context = context;
    }

    [HttpGet("RetrieveAll")]
    public async Task<UserData?> RetrieveAll()
    {
        int userId = GetUserId();
        var userData = await FindWithText(userId);
        return new UserData() {Id = userId, Texts = userData!.Texts};
    }
    
    [HttpGet("Retrieve/{id:int}")]
    public async Task<UserData?> Retrieve(int id)
    {
        int userId = GetUserId();
        var userData = await FindWithText(userId);
        if (userData != null || id > userData!.Texts.Count - 1 || id < 0) return null;
        return new UserData() {Id = userId, Texts = {userData!.Texts.ElementAt(id)}};
    }
    
    [HttpPost("Add/{userText}")]
    public async Task Add(string userText)
    {
        int userId = GetUserId();

        var existingData = await FindWithText(userId);
        existingData?.Texts.Add(Text(userText));
        _context.UserData.Update(existingData!);
        await _context.SaveChangesAsync();
    }
    
    [HttpPost("Update/{index:int}/{userText}")]
    public async Task Update(int index, string userText)
    {
        int userId = GetUserId();

        var existingData = await FindWithText(userId);
        if (index > existingData!.Texts.Count - 1 || index < 0) return;
        existingData!.Texts[index] = new UserText(userText);
        _context.UserData.Update(existingData!);
        await _context.SaveChangesAsync();
    }
    
    [HttpPost("Delete/{index:int}")]
    public async Task Delete(int index)
    {
        int userId = GetUserId();
        var userData = await FindWithText(userId);
        
        if (userData is null) return;
        if (index > userData.Texts.Count - 1 || index < 0) return;

        userData.Texts.RemoveAt(index);
        _context.Update(userData);
        await _context.SaveChangesAsync();
    }
    
    [HttpPost("DeleteAll/")]
    public async Task DeleteAll()
    {
        int userId = GetUserId();
        var record = await FindWithText(userId);

        if (record is null) return;
        record.Texts.Clear();
        await _context.SaveChangesAsync();
    }

    public int GetUserId()
    {
        string? userIdStr = User.Claims.FirstOrDefault(x =>
            x.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
        if (string.IsNullOrEmpty(userIdStr))
        {
            throw new ArgumentNullException("userId cannot be null - Resource Server Add method" + userIdStr);
        }

        if (!int.TryParse(userIdStr, out int userId))
        {
            throw new ArgumentNullException("userId is invalid - Resource Server Add method" + userIdStr);
        }

        return userId;
    }
}