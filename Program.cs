using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
   /// <summary>
   /// Password Strength Check
   /// </summary>
   class Program
   {
      static string convertSecondsToTime(double seconds)
      {
         string formattedTime;

         if (seconds > 1)
         {
            //If Estimated Time would be very long, there would be an exception
            try
            {
               TimeSpan diff = TimeSpan.FromSeconds(seconds);
               formattedTime = "Estimated computer time for Brute Force attack is ";
               if ((diff.Days / 365) > 0)
               {
                  formattedTime += string.Format(" {0} years", diff.Days / 365);
               }
               
               if (((diff.Days - (diff.Days / 365) * 365) / 30) > 0)
               {
                  formattedTime += string.Format(" {0} months", (diff.Days - (diff.Days / 365) * 365) / 30);
               }
               
               if ((diff.Days - ((diff.Days / 365) * 365) - ((diff.Days - (diff.Days / 365) * 365) / 30) * 30) > 0)
               {
                  formattedTime += string.Format(" {0} days", diff.Days - ((diff.Days / 365) * 365) - ((diff.Days - (diff.Days / 365) * 365) / 30) * 30);
               }
               
               if (diff.Hours > 0)
               {
                  formattedTime += string.Format(" {0} hours", diff.Hours);
               }
               
               if (diff.Minutes > 0)
               {
                  formattedTime += string.Format(" {0} minutes", diff.Minutes);
               }
               
               if (diff.Seconds > 0)
               {
                  formattedTime += string.Format(" {0} seconds", diff.Seconds);
               }
            }
            catch (Exception)
            {
               formattedTime = "Your password is too strong to calculate!";
            }
         }
         else
         {
            formattedTime = "Estimated computer time for Brute Force attack is less then 1 second";
         }
         return formattedTime;
      }

      static void CalculatePasswordStrength()
      {
         string[] arrayOfCommonPasswords = {
            "password", "123456", "12345678", "1234", "qwerty", "12345", "dragon",
            "pussy", "baseball", "football", "letmein", "monkey", "696969", "abc123",
            "mustang", "michael", "shadow", "master", "jennifer", "111111", "2000",
            "jordan", "superman", "harley", "1234567", "fuckme", "hunter", "fuckyou",
            "trustno1", "ranger", "buster", "thomas", "tigger", "robert", "soccer",
            "fuck", "batman", "test", "pass", "killer", "hockey", "george", "charlie",
            "andrew", "michelle", "love", "sunshine", "jessica", "asshole", "6969",
            "pepper", "daniel", "access", "123456789", "654321", "joshua", "maggie",
            "starwars", "silver", "william", "dallas", "yankees", "123123", "ashley",
            "666666", "hello", "amanda", "orange", "biteme", "freedom", "computer",
            "sexy", "thunder", "nicole", "ginger", "heather", "hammer", "summer",
            "corvette", "taylor", "fucker", "austin", "1111", "merlin", "matthew",
            "121212", "golfer", "cheese", "princess", "martin", "chelsea", "patrick",
            "richard", "diamond", "yellow", "bigdog", "secret", "asdfgh", "sparky", "cowboy" };

         //Geting the password from a user
         string password = Console.ReadLine();

         int length = password.Length;
         int possibleChars = 0;
         double possibleCombinations = 0;
         int upperCharsMatch = 0;
         int lowerCharsMatch = 0;
         int digitalCharsMatch = 0;
         int specialCharsMatch = 0;
         double computerTimeInSeconds = 0;
         double calculationsPerSecond = 2E+11; // some value for PC calculations per second.

         const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
         const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
         const string digitalChars = "1234567890";
         const string specialChars = "~!@#$%^&*()_+{}<>?|-=[],./\\";


         //Checking for a match with the TOP 100 common passwords
         for (int i = 0; i < arrayOfCommonPasswords.Length; i++)
         {
            if (password.ToLower() == arrayOfCommonPasswords[i])
            {
               int place = i + 1;
               Console.WriteLine("Your password is on the {0} place of Top 100 Common Passwords! It is very weak!", place);
            }
         }

         //Defining the types of a characters used in the password
         for (int j = 0; j < length; j++)
         {
            if ((upperCharsMatch == 0) && (upperChars.Contains(password.Substring(j, 1))))
            {
               upperCharsMatch = 26;
               Console.WriteLine("There is uppercase character in your password");
               continue;

            }
            else if ((lowerCharsMatch == 0) && (lowerChars.Contains(password.Substring(j, 1))))
            {
               lowerCharsMatch = 26;
               Console.WriteLine("There is lowercase character in your password");
               continue;

            }
            else if ((digitalCharsMatch == 0) && (digitalChars.Contains(password.Substring(j, 1))))
            {
               digitalCharsMatch = 10;
               Console.WriteLine("There is digit character in your password");
               continue;

            }
            else if ((specialCharsMatch == 0) && (specialChars.Contains(password.Substring(j, 1))))
            {
               specialCharsMatch = 27;
               Console.WriteLine("There is special char in your password");
               continue;
            }
         }

         //Calculating possible characters used in the password
         possibleChars = upperCharsMatch + lowerCharsMatch + digitalCharsMatch + specialCharsMatch;

         //Caculating possible combinations of the password based on the password length and possible characters
         possibleCombinations = Math.Pow(possibleChars, length);

         //Calculating estimated computer time for Brute Force attack on the password
         computerTimeInSeconds = possibleCombinations / calculationsPerSecond;

         Console.Write(convertSecondsToTime(computerTimeInSeconds));
      }

      static void Main(string[] args)
      {
         CalculatePasswordStrength();
         Console.ReadKey();
      }
   }
}

