﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.BusinessLogic.MainBL;

namespace WebApplication1.BusinessLogic
{
    public class BusinessLogic
    {
        public LoginBL GetLoginBL()
        {
            return new LoginBL();
        }
    }
}
