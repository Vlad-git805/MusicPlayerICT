﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte Picture { get; set; }
        public string WayToSongs { get; set; }
    }
}
