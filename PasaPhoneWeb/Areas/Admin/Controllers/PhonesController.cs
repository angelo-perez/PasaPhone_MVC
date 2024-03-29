using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PasaPhone.DataAccess.Data;
using PasaPhone.DataAccess.Repository.IRepository;
using PasaPhone.Models;
using PasaPhoneWeb.Areas.Admin.ViewModels;

namespace PasaPhoneWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhonesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhonesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Phone.GetAll().ToListAsync());
        }

        // GET: Phones/Details/Id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(m => m.Id == id);
            var spec = await _unitOfWork.Specification.Get(s => s.SpecificationId == id);

            if (phone == null)
            {
                return NotFound();
            }

            var viewModel = new PhoneAndSpecificationsViewModel
            {
                Phone = phone,
                Specification = spec
            };

            return View(viewModel);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Phones/CreateSpecifications
        public IActionResult CreateSpecifications()
        {
            return View();
        }

        // POST: Phones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Condition,Price,Description,Issues,Location,MeetupPreference,ImageUrl")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                // Serialize the Phone object to JSON and store it in TempData
                TempData["PhoneData"] = JsonConvert.SerializeObject(phone);
                return RedirectToAction(nameof(CreateSpecifications));
            }
            return View(phone);
        }

        // POST: Phones/CreateSpecifications
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecifications([Bind("Id,PhoneId,Phone,Os,Chipset,Memory,Storage,Camera,DisplayResolution,DisplayType,BatteryCapacity,ChargingSpeed,OtherSpecs")] Specification spec)
        {
            // Retrieve the serialized Phone object from TempData and deserialize it
            var phoneData = TempData["PhoneData"] as string;
            var phone = JsonConvert.DeserializeObject<Phone>(phoneData);

            if (phone != null && ModelState.IsValid)
            {
                spec.Phone = phone;
                _unitOfWork.Phone.Add(phone);
                _unitOfWork.Specification.Add(spec);
                await _unitOfWork.Save();
                TempData["success"] = "Phone listed successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(spec);
        }

        // GET: Phones/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);

            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // GET: Phones/EditSpecifications/Id
        public async Task<IActionResult> EditSpecifications(int? phoneId)
        {
            if (phoneId == null)
            {
                return NotFound();
            }

            var spec = await _unitOfWork.Specification.Get(s => s.SpecificationId == phoneId);

            if (spec == null)
            {
                return NotFound();
            }
            return View(spec);
        }

        // POST: Phones/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Condition,Price,Description,Issues,Location,MeetupPreference")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_unitOfWork.Phone.Update(phone);
                    //await _unitOfWork.Save();
                    TempData["editedPhoneData"] = JsonConvert.SerializeObject(phone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditSpecifications", new {phoneId = phone.Id});
            }
            return View(phone);
        }

        // POST: Phones/EditSpecifications/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSpecifications(int phoneId, [Bind("Id,PhoneId,Phone,Os,Chipset,Memory,Storage,Camera,DisplayResolution,DisplayType,BatteryCapacity,ChargingSpeed,OtherSpecs")] Specification spec)
        {
            if (phoneId != spec.SpecificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var phoneData = TempData["editedPhoneData"] as string;
                    var phone = JsonConvert.DeserializeObject<Phone>(phoneData);
                    _unitOfWork.Phone.Update(phone);
                    _unitOfWork.Specification.Update(spec);
                    await _unitOfWork.Save();
                    TempData["success"] = "Phone updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificationExists(spec.SpecificationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(spec);
        }

        // GET: Phones/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _unitOfWork.Phone.Get(u => u.Id == id);
            if (phone != null)
            {
                _unitOfWork.Phone.Remove(phone);
            }

            await _unitOfWork.Save();
            TempData["success"] = "Phone deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public void Back() { 
        
        }

        private bool PhoneExists(int id)
        {
            return _unitOfWork.Phone.IsItemExists(e => e.Id == id);
        }

        private bool SpecificationExists(int id)
        {
            return _unitOfWork.Specification.IsItemExists(u => u.SpecificationId == id);
        }
    }

}
