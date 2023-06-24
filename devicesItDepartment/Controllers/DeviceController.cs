using devicesItDepartment.Models;
using devicesItDepartment.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace devicesItDepartment.Controllers
{
    public class DeviceController : Controller
    {
        private readonly TaskContext context;

        IDeviceRepository devrepo;

        public DeviceController(IDeviceRepository devrepo, TaskContext _context)
        {
            this.devrepo = devrepo;
            context = _context;
        }

        public IActionResult Index()
        {
            List<Device> devices = devrepo.GetAll().ToList(); 
            return View(devices);
        }


        //public ActionResult AddDevice()
        //{
        //    ViewBag.Categories = context.DeviceCategories.ToList();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddDevice(Device device)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Devices.Add(device);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Categories = context.DeviceCategories.ToList();
        //    return View(device);
        //}

        //public ActionResult EditDevice(int id)
        //{
        //    var device = context.Devices.Include(d => d.Category).Include(d => d.PropertyValues).FirstOrDefault(d => d.Id == id);
        //    if (device == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.Categories = context.DeviceCategories.ToList();
        //    return View(device);
        //}

        //[HttpPost]
        //public ActionResult EditDevice(Device device)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(device).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Categories = context.DeviceCategories.ToList();
        //    return View(device);
        //}

        // GET: Device/Create
        public IActionResult Create()
        {
            ViewBag.Categories = context.DeviceCategories.ToList();

            return View();
        }

        // POST: Device/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Device device)
        {
            if (!ModelState.IsValid)
            {
                devrepo.Add(device);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = context.DeviceCategories.ToList();
            return View("Create", device);
        }
        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await devrepo.GetById(id.Value);
            if (device == null)
            {
                return NotFound();
            }
            ViewBag.Categories = context.DeviceCategories.ToList();

            return View(device);
        }

        // POST: Device/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AcuisitionDate,Memo,Category")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await devrepo.Update(device);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = context.DeviceCategories.ToList();

            return View(device);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await devrepo.GetById(id.Value);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await devrepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
