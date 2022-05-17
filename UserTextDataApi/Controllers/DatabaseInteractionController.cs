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

    [HttpGet(DatabaseIPs.RetrieveAll)]
    public async Task<UserData?> RetrieveAll()
    {
        int userId = GetUserId();
        var userData = await FindWithText(userId);
        return new UserData() {Id = userId, Texts = userData!.Texts};
    }
    
    [HttpGet(DatabaseIPs.Retrieve)]
    public async Task<UserData?> Retrieve(int id)
    {
        int userId = GetUserId();
        var userData = await FindWithText(userId);
        if (userData != null || id > userData!.Texts.Count - 1 || id < 0) return null;
        return new UserData() {Id = userId, Texts = {userData!.Texts.ElementAt(id)}};
    }
    
    [HttpPost(DatabaseIPs.Add)]
    public async Task<IActionResult> Add(string userText)
    {
        int userId = GetUserId();

        var existingData = await FindWithText(userId);
        if(existingData is null) return NotFound();
        existingData.Texts.Add(Text(userText));
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost(DatabaseIPs.Update)]
    public async Task<IActionResult> Update(int index, string userText)
    {
        int userId = GetUserId();

        var existingText = await _context.Texts.FindAsync(index);
        if (existingText is null) return NotFound();
        existingText.TextValue = userText;
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost(DatabaseIPs.Delete)]
    public async Task<IActionResult> Delete(int index)
    {
        int userId = GetUserId();
        var existingText = await _context.Texts.FindAsync(index);
        
        if (existingText is null) return NotFound();

        _context.Remove(existingText);
        await _context .SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost(DatabaseIPs.DeleteAll)]
    public async Task<IActionResult> DeleteAll()
    {
        int userId = GetUserId();
        var record = await FindWithText(userId);

        if (record is null) return NotFound();
        record.Texts.Clear();
        await _context.SaveChangesAsync();
        return Ok();
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