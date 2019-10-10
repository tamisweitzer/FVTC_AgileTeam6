﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandZone.UI.Model
{
    public class Authenticate
    {
        public static bool IsAuthenticated()
        {
            if (HttpContext.Current.Session == null)
                return false;
            else
                return HttpContext.Current.Session["musician"] != null;
        }
    }
}