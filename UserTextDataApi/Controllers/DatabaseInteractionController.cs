using Microsoft.AspNetCore.Mvc;
using UserTextDataApi.Data;
using Z.EntityFramework.Plus;

namespace UserTextDataApi.Controllers;

public class DatabaseInteractionController : Controller
{
    private readonly UserTextDataDbContext _context;
    public Wrapper ToWrapper(string text) => new Wrapper {textValue = text};
    
    public DatabaseInteractionController(UserTextDataDbContext context)
    {
        _context = context;
    }

        
    
    [HttpGet("Retrieve/{id:int}")]
    public async Task<UserTextData?> Retrieve(int id)
    {
        int userId = GetUserId();
        var userData = await _context.UserData.FindAsync(userId);
        if (userData != null || id > userData.Texts.Count - 1 || id < 0) return null;
        return new UserTextData(new UserTextDataWrapper(){Id = userId, Texts = {userData?.Texts.ElementAt(id)}});
    }

    // GET: UserData/Add
    [HttpPost("Add/{userText}")]
    public async Task Add(string userText)
    {
        int userId = GetUserId();

        var existingData = await _context.UserData.FindAsync(userId);
        if (existingData is not null)
        {
            existingData.Texts.Add(ToWrapper(userText));
            
        }
        else
        {
            await _context.UserData.AddAsync(new UserTextDataWrapper {Id = userId, Texts = {ToWrapper(userText)}});
        }
        
        await _context.SaveChangesAsync();
    }

    // GET: UserData/Delete/5
    [HttpPost("Delete/{index:int}")]
    public async Task Delete(int index)
    {
        int userId = GetUserId();
        var record = await _context.UserData.FindAsync(userId);
        
        if (record is null) return; 
        if(index > record.Texts.Count - 1 || index < 0) return;
        
        record.Texts.Remove(record.Texts.ElementAt(index));
        await _context.SaveChangesAsync();
    }
    
    // GET: UserData/Delete/5
    [HttpPost("Delete/")]
    public async Task Delete()
    {
        int userId = GetUserId();
        var record = await _context.UserData.FindAsync(userId);
        
        if (record is null) return;
        _context.UserData.Remove(record);
        await _context.SaveChangesAsync();
    }

    public int GetUserId()
    {
        string? userIdStr = User.Claims.FirstOrDefault(x => x.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
        if (string.IsNullOrEmpty(userIdStr))
        {
            throw new ArgumentNullException(nameof(userIdStr), "userId cannot be null - Resource Server Add method" + userIdStr);
        }

        if(!int.TryParse(userIdStr, out int userId))
        {
            throw new ArgumentNullException(nameof(userIdStr), "userId is invalid - Resource Server Add method" + userIdStr);
        };
        return userId;
    }
}