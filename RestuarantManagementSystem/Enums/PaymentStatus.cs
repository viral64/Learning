using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantManagementSystem.Enums
{
    public enum PaymentStatus
    {
        UNPAID, PENDING, COMPLETED, FAILED, DECLINED, CANCELLED, ABANDONED, SETTLING, SETTLED, REFUNDED
    }
}
