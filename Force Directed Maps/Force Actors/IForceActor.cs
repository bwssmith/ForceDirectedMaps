﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Directed_Maps
{
    public interface IForceActor
    {
        string ForceName();
        void ActOn(Diagram d);
    }
}
