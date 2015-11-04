using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeWebservice
{
    public enum ePaymentMethod
    {
       boleto = 1,
       credit_card = 2
    }
    public enum eTransactionStatus
    {
        processing = 1,
        authorized = 2,
        paid = 3,
        refunded = 4,
        waiting_payment = 5,
        pending_refund = 6,
        refused = 7
    }
    public enum eTransactionStatusReason
    {
        acquirer = 1,
        antifraud = 2,
        internal_error = 3,
        no_acquirer = 4,
        acquirer_timeout = 5
    }

    public enum eSubscriptionStatus
    {
        trialing = 1,
        paid = 2,
        pending_payment = 3,
        unpaid = 4,
        canceled = 5,
        ended = 6
    }

    public enum eGender
    {
        female = 1,
        male = 2
    }

    public enum eCreditCardBrand
    {
        visa = 1,
        mastercard = 2
    }

    public enum eCustomerDocumentType
    {
        cpf = 1,
        cnpj = 2
    }
}
