﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Food.ApiResponseClass
{
    public class LoginRes : ApiResponse
    {
        public User response { get; set; }
    }
}
