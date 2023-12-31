﻿using Microsoft.AspNetCore.Mvc;
using Hospital.ViewModels;
using Hospital.Services;

namespace Room.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private IRoomService _Room;

        public RoomsController(IRoomService Room)
        {
            _Room = Room;
        }

        public IActionResult Index(int pageNumber=1,int pageSize=10)
        {
            return View(_Room.GetAll(pageNumber,pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel=_Room.GetRoomById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm) 
        {
            _Room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModel vm) 
        {
            _Room.InsertRoom(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            _Room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
            return View(_Room.GetRoomById(id));

        }
    }
}
