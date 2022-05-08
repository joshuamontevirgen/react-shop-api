using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments
{
    //https://stackoverflow.com/questions/42402064/using-a-strategy-and-factory-pattern-with-dependency-injection
    public class PaymentMethodSelector : IPaymentMethodSelector
    {
        IPaymentMethod _paymaya;
        public PaymentMethodSelector(IPaymentMethod paymaya)
        {
            _paymaya = paymaya;
        }
        public IPaymentMethod SelectPaymentMethod(string name)
        {
            return _paymaya;
        }
    }
}
