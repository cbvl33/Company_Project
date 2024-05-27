using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Enums
{
    public enum Experts
    {
        [Description("Walter White")]
        WalterWhite,
        [Description("Sarah Jhonson")]
        SarahJhonson,
        [Description("William Anderson")]
        WilliamAnderson,
        [Description("Amanda Jepson")]
        AmandaJepson
    }
}

