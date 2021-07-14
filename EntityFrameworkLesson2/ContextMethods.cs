using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson2
{
    class ContextMethods
    {
        MusicalCollection mc = null;
        public ContextMethods(MusicalCollection mc)
        {
            this.mc = mc;
        }
    }
}
