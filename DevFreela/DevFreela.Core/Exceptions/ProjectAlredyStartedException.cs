﻿using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectAlredyStartedException : Exception
    {
        public ProjectAlredyStartedException() :base("Project is alredy started")
        {
            
        }
    }
}
