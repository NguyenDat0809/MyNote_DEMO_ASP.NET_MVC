using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNote.Data;
using MyNote.Models;

namespace MyNote.Controllers
{
	public class ExpensesController : Controller
	{
		private readonly ApplicationDbContext _context;
		public ExpensesController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var ExList = _context.Expenses.ToList();
			return View(ExList);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Expenses obj)
		{
			if (ModelState.IsValid)
			{
				_context.Expenses.Add(obj);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? Id)
		{

			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			var obj = _context.Expenses.Find(Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		[HttpPost]
		public IActionResult DeletePost(int? Id)
		{
			var obj = _context.Expenses.Find(Id);
			if (obj == null)
			{
				return NotFound();
			}
			_context.Expenses.Remove(obj);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Update(int? Id)
		{

			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			var obj = _context.Expenses.Find(Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}
		[HttpPost]
		public IActionResult Update(Expenses obj)
		{
			if (ModelState.IsValid)
			{
				_context.Expenses.Update(obj);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
