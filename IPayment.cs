﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    interface IPayment
    {
        int ToBePaid { get; set; }
        int NumberOfPayments { get; set; }

    }
}
