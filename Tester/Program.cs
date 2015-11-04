using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagarmeWebservice;
using PagarmeWebservice.Base;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //CardTest();
            //PlanFullTest();
            //SubsTest();
            TestTransactions();
            Console.Read();
        }
        #region Card
        private static void CardTest()
        {
            var obj = new Card
            {
                CardNumber = "5216005329772352",
                CardExpirationDate = "0822",
                HolderName = "Jose Silva",
                Cvv = "544"
            };
            Console.Write("Testing Card");
            obj.Create();
            Console.WriteLine(obj.Id != null ? " - Success" : " - Fail");
        }
        #endregion
        #region Plan
        private static void PlanFullTest()
        {
            var obj = CreatingPlan();
            obj = GettingPlan(obj.Id);
            UpdatingPlan(obj);
            var plans = GettingAllPlans();
        }
        private static Plan CreatingPlan()
        {
            var obj = new Plan
            {
                Amount = 9999, //99,99
                Days = 90,
                Name = "Plano teste Renan (R$ 49,99)",
                Color = "#F05",
                Charges = 4,
                Installments = 3
            };
            Console.Write("Creating plan");
            obj.Create();
            Console.WriteLine(obj.Id > 0 ? " - Success" : " - Fail");
            return obj;
        }
        private static Plan GettingPlan(int id)
        {
            Console.Write("Getting plan");
            var p = Plan.GetPlanById(id);
            Console.WriteLine(p.Id > 0 ? " - Success" : " - Fail");
            return p;
        }
        private static Plan UpdatingPlan(Plan plan)
        {
            Console.Write("Updating plan");
            plan.Name = "Altered plan (R$ 59,99)";
            plan.TrialDays = 1;
            plan.Update();
            Console.WriteLine(plan.Id > 0 ? " - Success" : " - Fail");
            return plan;
        }
        public static List<Plan> GettingAllPlans()
        {
            Console.Write("Getting all plans");
            var plans = Plan.GetAllPlans();
            if (plans != null && plans.Count > 0)
            {
                Console.WriteLine(" - Success");
                return plans;
            }
            Console.WriteLine(" - Fail");
            return null;
        }
        #endregion
        #region Subscription
        public static void SubsTest()
        {
            var obj = SubsCreate();
            SubsGetById(obj.Id);
            SubsGetAll();
            SubsUpdate(obj);
            SubsCancel(obj);
        }

        public static Subscription SubsCreate()
        {
            //any plan
            var plan = Plan.GetAllPlans().First();

            //fake credit card
            var card = new Card
            {
                CardNumber = "5367624274512386", //master card
                HolderName = "Jose Silva",
                Cvv = "547",
                CardExpirationDate = "0822"
            };

            //gererating a hash to be used for subscription
            var hash = card.GenerateHash();

            //client data
            var customer = new Customer
            {
                Email = "jose.silva@pagarme.me",
                Name = "José Silva",
                Phones = new List<Phone> { new Phone { Ddd = "11", Ddi = "+55", Number = "987456321" } }
            };
            var obj = new Subscription
            {
                PlanId = plan.Id,
                Customer = customer,
                CardHash = hash
            };
            obj.Create();
            return obj;
        }

        public static Subscription SubsGetById(int id)
        {
            return null;
        }

        public static List<Subscription> SubsGetAll()
        {
            return null;
        }

        public static Subscription SubsUpdate(Subscription obj)
        {
            return null;
        }

        public static Subscription SubsCancel(Subscription obj)
        {
            return null;
        }
        #endregion
        #region Transaction
        private static void TestTransactions()
        {
            CreditCardTransaction();
        }

        private static void CreditCardTransaction()
        {
            var obj = new Card
            {
                CardNumber = "5216005329772352",
                CardExpirationDate = "0822",
                HolderName = "Jose Silva",
                Cvv = "544"
            };
            obj.Create();
            var t = new Transaction
            {
                Amount = 9999, //R$ 99,99
                CardId = obj.Id,
                SoftDescriptor = "", //Invoice description
                Capture = false, //Just authorize
                Metadata = new Metadata { IdData = 1, NomeData = "Sale 1" }, //Just to tag
                Customer = new Customer
                {
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            City = "São Paulo",
                            Complementary = "AP3",
                            Neighborhood = "Bela Vista",
                            Country = "BR",
                            State = "SP",
                            Street = "Av Paulista",
                            StreetNumber = "1000",
                            Zipcode = "01318002"
                        }
                    },
                    BornAt = new DateTime(1980, 1, 1),
                    DocumentNumber = "02460608322",
                    DocumentType = eCustomerDocumentType.cpf,
                    Email = "emanuel.metallica@hotmail.com",
                    Gender = eGender.male,
                    Name = "Emanuel Lima",
                    Phones = new List<Phone>{
                        new Phone
                        {
                            Ddd = "11",
                            Ddi = "55",
                            Number = "984628620"
                        }
                    }
                }
            };
            t.Create();
        }
        #endregion
    }
}
