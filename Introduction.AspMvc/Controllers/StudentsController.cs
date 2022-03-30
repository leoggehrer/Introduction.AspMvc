using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.AspMvc.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        public async Task<ActionResult> Index()
        {
            var models = await Data.StudentRepository.GetAllAsync();

            return View("Index", models);
        }

        // GET: StudentsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await Data.StudentRepository.GetByIdAsync(id);

            return View(model);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Student model)
        {
            try
            {
                await Data.StudentRepository.InsertAsync(model);
                await Data.StudentRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        // GET: StudentsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await Data.StudentRepository.GetByIdAsync(id);

            return View(model);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.Student model)
        {
            try
            {
                await Data.StudentRepository.UpdateAsync(model);
                await Data.StudentRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        // GET: StudentsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await Data.StudentRepository.GetByIdAsync(id);

            return View(model);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Models.Student model)
        {
            try
            {
                await Data.StudentRepository.DeleteAsync(id);
                await Data.StudentRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
