using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    internal interface IBuzzer
    {
        void BuzzOnCookingDone();
        void BuzzOnButtonPress();
    }
}