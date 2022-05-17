using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Routes.Controllers;

namespace Client.Controllers;

public class ShowDataController : Controller
{
    // GET: ShowData
    public async Task<IActionResult> Index(bool succeeded)
    {
        var data = await DatabaseCaller.RetrieveAll();
        ViewBag.succeeded = succeeded;
        return View(data);
    }
        
    public async Task<IActionResult> Claims()
    {
        return Content(await DatabaseCaller.RetrieveClaimsJson()); 
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePost(string text)
    {
        bool succeeded = await DatabaseCaller.Add(text);
        return ShowData.Index(succeeded).Redirect(this);
    }

    [HttpGet]
    public IActionResult Edit(int id, string text)
    {
        if (string.IsNullOrEmpty(text)) return ShowData.Index(false).Redirect(this);
        return View(model: (id, text));
    }

    [HttpPost]
    public async Task<IActionResult> EditPost(int id, string text)
    {
        bool succeeded = await DatabaseCaller.Update(id,text);
        return ShowData.Index(succeeded).Redirect(this);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        bool succeeded = await DatabaseCaller.Delete(id);
        return ShowData.Index(succeeded).Redirect(this);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteAll()
    {
        bool succeeded = await DatabaseCaller.DeleteAll();
        return ShowData.Index(succeeded).Redirect(this);
    }
}