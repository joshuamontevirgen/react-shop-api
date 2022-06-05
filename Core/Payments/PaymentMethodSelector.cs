using Core.Payments.PaymentMethods.COD;
using Core.Payments.PaymentMethods.Paymaya;
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
        IPaymayaPaymentMethod _paymaya;
        ICODPaymentMethod _cod;
        public PaymentMethodSelector(IPaymayaPaymentMethod paymaya, ICODPaymentMethod cod)
        {
            _paymaya = paymaya;
            _cod = cod;
        }
        public IPaymentMethod SelectPaymentMethod(string name)
        {
            if(name == _paymaya.Name)
                return _paymaya;
            return _cod ;
        }
    }
}
