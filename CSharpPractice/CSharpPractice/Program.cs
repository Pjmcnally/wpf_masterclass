using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPractice.Classes;
using CSharpPractice.Interfaces;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //BankAccount bankAccount = new BankAccount(1000);
            //bankAccount.AddToBalance(100);
            //Console.WriteLine(bankAccount.Balance);

            //ChildBankAccount childBankAccount = new ChildBankAccount();
            //childBankAccount.AddToBalance(10);
            //Console.WriteLine(childBankAccount.Balance);

            //double[] nums = new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //var mathRes = SimpleMath.Add(nums);
            //Console.WriteLine(mathRes);

            BankAccount bankAccount = new BankAccount(1000);
            bankAccount.AddToBalance(100);

            SimpleMath simpleMath = new SimpleMath();

            Console.WriteLine(Information(bankAccount));
            Console.WriteLine(Information(simpleMath));

            // Write above this line
            Console.ReadLine();
        }

        private static string Information(IInformation information)
        {
            return information.GetInformation();
        }
    }

    class SimpleMath : IInformation
    {
        static public double Add(params double[] args)
        {
            double result = 0;
            foreach (var num in args)
            {
                result += num;
            }

            return result;
        }

        public string GetInformation()
        {
            return "Class that solves simple math.";
        }
    }
}
