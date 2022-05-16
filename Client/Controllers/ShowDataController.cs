using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Routes.Controllers;

namespace Client.Controllers;

public class ShowDataController : Controller
{
    // GET: ShowData
    public async Task<IActionResult> Index()
    {
        var data = await DatabaseCaller.RetrieveAll();
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
        await DatabaseCaller.Add(text);
        return ShowData.Index().Redirect(this);
    }

    [HttpGet]
    public IActionResult Edit(int id, string text)
    {
        if (string.IsNullOrEmpty(text)) return ShowData.Index().Redirect(this);
        return View(model: (id, text));
    }

    [HttpPost]
    public async Task<IActionResult> EditPost(int id, string text)
    {
        await DatabaseCaller.Update(id,text);
        return ShowData.Index().Redirect(this);
    }
}