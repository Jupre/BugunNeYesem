﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugunNeYesem.Logic;

namespace BugunNeYesem.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var locationService = new LocationService();
            var location = locationService.GetLocation();


        }
    }
}
