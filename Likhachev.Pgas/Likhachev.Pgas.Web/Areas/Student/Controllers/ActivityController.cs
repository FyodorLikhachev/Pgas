using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Likhachev.Pgas.Web.Areas.Student.Controllers
{
    using Services;
    using Services.Dtos;

    [Area("Activity")]
    public class ActivityController : Controller
    {
        public IActionResult CreateActivity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateActivity(ActivityDto model)
        {
            ActivityServices.AddActivity(model);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = ActivityServices.GetActivityDto(id.Value);
                if (model != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ActivityDto model)
        {
            ActivityServices.ModifyActivity(model);
            return RedirectToAction("Activities", "Activity");
        }


        public void Remove(string identificator)
        {
            ActivityServices.RemoveActivity(int.Parse(identificator));
        }
    }
}