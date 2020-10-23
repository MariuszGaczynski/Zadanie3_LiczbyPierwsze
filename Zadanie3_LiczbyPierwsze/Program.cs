using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3_LiczbyPierwsze
{
    class Program
    {                   // nie korzystałem z tych dodatkowych podpowiedzi. Sam wymyśliłem metodę która wydaje się działać
                         // podejrzewam że jest ona mniej efektywna niż jakieś profesjonalne rozwiązanie
                         // metoda sprawdza warunek "od tyłu" więc przy dużych liczbach może być wolniejsza 
                         // może trzeba by wpisać też profesjonalny kod na liczby pierwsze , założyć ten stoper "Time.Start"
                         // i sprawdzić jaka jest różnica w szybkości wykonywania obu wersji metod
                         // dodałem też wyświetlanie poprzedzających liczb pierwszych
                         // wykorzystałem kilkukrotnie pętlę for (bo chyba wystarcza) ale może jakieś inne byłyby lepsze
        static void Main(string[] args)
        {

            // szyld graficzny 

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t####################################\t\t\t");
            Console.WriteLine("\t\t####### Prime Number Checker #######\t\t\t");
            Console.WriteLine("\t\t####################################\t\t\t\n");
            Console.ResetColor();

            Console.WriteLine("\tA PRIME number is a natural number greater than 1\n" +
                "that cannot be formed by multiplying two smaller natural numbers.\n");

        OnceAgain1:
            Console.Write("\nWhat number would you like to check ? ...");  // pytnie o liczbę

            bool isParsable = Int32.TryParse(Console.ReadLine(), out int givenNumber);
            if (isParsable)
            {
                if (givenNumber <=1 || givenNumber > Int32.MaxValue) // dozwolony zakres liczb
                {
                    Console.WriteLine("You can check numbers between 2 and 2,147,483,647.\n\t");
                    goto OnceAgain1;
                }

            }
            else
            {
                Console.WriteLine("You can check numbers between 2 and 2,147,483,647.\n\t");
                goto OnceAgain1;
            }

            Console.WriteLine();

            if (IsItPrimeNumber(givenNumber))   // podświetlę jak będzie liczba pierwsza ;)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(IsItPrimeNumber(givenNumber) ?        // dwie wersje odpowiedzi czy jest pierwsza
                $"\t\tGiven number {givenNumber} is a Prime Number\t\t" :
                $"\t\tGiven number {givenNumber} is not a Prime Number\t\t");
            Console.ResetColor();

            if (IsItPrimeNumber(givenNumber))
            {// dodatkowa funkcjonalność - wyświetli wszystkie poprzedzające liczby pierwsze
                Console.Write("\nWould you like to see other primes up to your given Prime Number ?\n\t\t(Y)es or (N)o ? ...");
            OnceAgain2:
                string otherPrimes = Console.ReadLine().ToLower();
                if (otherPrimes == "y")
                {
                    Console.WriteLine("\nOther Primes are : ");
                    PrintPrimes(givenNumber);   // metoda do wyświtlania liczb pierwszych
                    Console.WriteLine();
                }
                else if (otherPrimes == "n")
                {

                }
                else
                {
                    Console.WriteLine("Want to see other prime numbers ? (Y)es or (N)o ?");
                    goto OnceAgain2;
                }
            }


            Console.Write("\n\tWould you like to check another number ? ( Y / N ) ? ...");
            OnceAgain3:
            string restart = Console.ReadLine().ToLower();
            if (restart == "y")
            {
                goto OnceAgain1;              // restart aplikacji 

            }
            else if (restart == "n")
            {

            }
            else
            {
                Console.WriteLine("Another check ? (Y)es or (N)o ?");
                goto OnceAgain3;
            }

            // pożegnanie
            Console.WriteLine("\n\t------------------------------------\t\t");
            Console.WriteLine("\tThank you for Prime Number checking !\n\n" +
                "Use Prime Number Checker again if you want to check some more numbers.");
            Console.WriteLine("\t------------------------------------\t\t");

           


            Console.ReadKey();
        }

        public static bool IsItPrimeNumber(int givenNumber)  // metoda do sprawdzania czy jest pierwsza
        {
            bool isPrime = true; // domyślnie zakładam że jest pierwsza

            for (int i = givenNumber - 1; i > 1; i--) // zaczynam sprawdzanie od "podanej liczby - 1". Aż do liczbt "2"
            {
                if ((givenNumber % i) == 0) // jak podzieli się bez reszty to nie jest pierwsza
                {

                    isPrime = false;
                    break;

                    // kolejnych przypadków już nie sprawdzam bo był co najmniej jeden dzielnik bez reszty
                }
                else
                {
                    //Console.WriteLine($"Liczba {givenNumber} to liczba pierwsza");
                    isPrime = true;

                }

            }
            return isPrime;
        }

        public static void PrintPrimes(int givenNumber) // metoda do wyświetlania ciągu liczb pierwszych z wykorzystaniem poprzedniej metody
        {
            for (int j = 3; j <givenNumber;j++)
            {

                if (IsItPrimeNumber(j) )
                    Console.Write(j + ",");

            
            }

            

            
        }
    }
}
