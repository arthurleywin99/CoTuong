using DemoAPI.Models;
using DemoAPI.ViewModels;
using Lib.Entities;
using Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPI.Controllers.api
{
    public class ChessController: Controller
    {
        ChessService chessService = new ChessService();
        
        [Route("api/chess/insertroom")]
        [HttpPost]
        public ActionResult insertroom(RoomModel rmodel)
        {
            Room r = new Room();
            r.Id = Guid.NewGuid();
            r.Name = rmodel.RoomName;
            r.JoinedCount = 0;
            chessService.createRoom(r);
            return
            Json(new
            {
                message = "success",
               // data = stList //_dbContext.Student.OrderBy(s=>s.Id).Skip(2).Take(3).ToList() //Where(s=>s.Id == Guid.Parse(id)).FirstOrDefault()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoom(RoomViewModel viewModel)
        {
            Room room = new Room
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                JoinedCount = 0,
                Password = viewModel.Password,
            };
            chessService.createRoom(room);
            return RedirectToAction("GetAllRoom", "Chess");
        }
        
        [HttpGet]
        public ActionResult GetAllRoom()
        {
            List<Room> roomList = chessService.getAllRoom();
            List<RoomViewModel> roomModels = new List<RoomViewModel>();
            foreach(var item in roomList)
            {
                RoomViewModel model = new RoomViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    JoinedCount = item.JoinedCount
                };
                roomModels.Add(model);
            }
            return View(roomModels);
        }

        [Route("api/chess/getchessnode")]
        [HttpPost]
        public ActionResult getAllNode(List<MoveModel> movelist)
        {
            string chessJson = System.IO.File.ReadAllText(Server.MapPath("/Data/ChessJson.txt"));
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<ChessNode> chessnode = js.Deserialize<List<ChessNode>>(chessJson);
            return Json(new
            {
                message = "success",
                chessnode = chessnode
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/chess/movenode")]
        [HttpPost]
        public ActionResult getMoveNode(List<MoveModel> movelist)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            Requestlog.PostToClient(js.Serialize(movelist));
            return Json(new
            {
                message = "success"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}