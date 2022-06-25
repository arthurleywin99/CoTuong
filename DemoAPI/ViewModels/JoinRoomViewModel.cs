using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAPI.ViewModels
{
    public class JoinRoomViewModel
    {
        [Required]
        public string Password { get; set; }
    }
}