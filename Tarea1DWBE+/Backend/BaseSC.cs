using System;
using System.Collections.Generic;
using System.Text;
using Tarea1DWBE_.DataAccess;

namespace Tarea1DWBE_.Backend
{
    public class BaseSC
    {
        protected NorthwindContext dbContext = new NorthwindContext();
    }
}
