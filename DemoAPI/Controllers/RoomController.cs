using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoAPI.ViewModels;
using Lib.Services;

namespace DemoAPI.Controllers
{
    public class RoomController : Controller
    {
        ChessService chessService = new ChessService();

        [HttpGet]
        public ActionResult JoinRoom(Guid Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JoinRoom(Guid Id, JoinRoomViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!chessService.checkRoom(Id, viewModel.Password))
            {
                ViewData["Error"] = "Sai mật khẩu";
                return View();
            }
            if (chessService.isFull(Id)) 
            {
                ViewData["Error"] = "Phòng đã đầy";
                return View();
            }
            else
            {
                chessService.increaseRoomMember(Id);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}