﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Dtos
{
    public class TodoTaskDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
