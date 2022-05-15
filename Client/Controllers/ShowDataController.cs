using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ShowDataController : Controller
    {
        // GET: ShowData
        public async Task<IActionResult> Index()
        {
            var data = await DatabaseCaller.RetrieveAll();
            return View(data?.Text);
        }

        // GET: ShowData/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userTextData = await DatabaseCaller.Retrieve(id);
            if (userTextData == null)
            {
                return NotFound();
            }

            return View(userTextData);
        }

        // GET: ShowData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShowData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string text)
        {
            if (ModelState.IsValid)
            {
                await DatabaseCaller.Add(text);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ShowData/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userData = await DatabaseCaller.Retrieve(id);
            if (userData is null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // POST: ShowData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, string Text)
        // {
        //
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(userTextDataWrapper);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!UserTextDataWrapperExists(userTextDataWrapper.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(userTextDataWrapper);
        // }

        // GET: ShowData/Delete/5
        public IActionResult Delete(int id)
        {
            var userData = DatabaseCaller.Retrieve(id);

            return View(userData);
        }

        // POST: ShowData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await DatabaseCaller.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
