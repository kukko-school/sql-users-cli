using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Number of the users: " + UserService.getNumberOfUsers());
                if (!AuthenticationService.isAuthenticated())
                {
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Quit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Username: ");
                            string loginUsername = Console.ReadLine();
                            Console.Write("Password: ");
                            string loginPassword = Console.ReadLine();
                            if (AuthenticationService.authenticate(loginUsername, loginPassword))
                            {
                                Console.WriteLine("Howdy!");
                            }
                            else
                            {
                                Console.WriteLine("No, no, no!");
                            }
                            break;
                        case "2":
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            UserService.registerNewUser(username, password);
                            break;
                        case "3":
                            finished = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    User authenticatedUser = AuthenticationService.getAuthenticatedUser();
                    Console.WriteLine("Hello, " + authenticatedUser.GetUername() + "!");
                    Console.WriteLine("1. List data");
                    Console.WriteLine("2. Record new data");
                    Console.WriteLine("3. Logout");
                    Console.WriteLine("4. Quit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Dictionary<string, string> data = UserDataService.getAllDataForUser(AuthenticationService.getAuthenticatedUser().GetId());
                            foreach (KeyValuePair<string, string> item in data)
                            {
                                Console.WriteLine(item.Key + ": " + item.Value);
                            }
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Write("Data type: ");
                            string dataKey = Console.ReadLine();
                            Console.Write("Data value: ");
                            string dataValue = Console.ReadLine();
                            UserDataService.storeUserData(AuthenticationService.getAuthenticatedUser().GetId(), dataKey, dataValue);
                            break;
                        case "3":
                            AuthenticationService.logout();
                            Console.WriteLine("Bye!");
                            break;
                        case "4":
                            finished = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (!finished);
        }
    }
}
