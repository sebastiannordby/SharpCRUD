﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Shared.Models
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
    }
}
