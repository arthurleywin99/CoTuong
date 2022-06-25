using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAPI.ViewModels
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên Phòng")]
        public string Name { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
        public int JoinedCount { get; set; }
    }
}