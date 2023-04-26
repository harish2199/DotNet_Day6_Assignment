﻿using System.Numerics;

namespace Day6_Assignment
{
    class customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerID { get; set; }

        public customer(string firstName, string lastName, DateTime dateOfBirth, string gender, string address,string village,string district, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Village = village;
            District = district;
            PhoneNumber = phone;
            CustomerID = GenerateCustomerId(firstName, lastName);
        }

        private string GenerateCustomerId(string firstName, string lastName)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(10, 99);
            string customerId = $"{firstName[0]}{lastName[0]}{randomNumber}";
            return customerId;
        }
    }

    class Bank
    {
        List<customer> customerList = new List<customer>();
        public void AddCustomer()
        {
            Console.WriteLine("Enter customer details:");
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date of birth (dd/mm/yyyy): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Village: ");
            string village = Console.ReadLine();
            Console.Write("District: ");
            string district = Console.ReadLine();
            Console.Write("Phone number (including state code): ");
            string phone = Console.ReadLine();

            if (phone.Length != 12)
            {
                Console.WriteLine("Invalid phone number");
                return;
            }

            customer customer = new customer(firstName, lastName, dateOfBirth, gender, address,village,district, phone);
            customerList.Add(customer);

            Console.WriteLine($"Customer added successfully. Customer ID: {customer.CustomerID}");
        }

         public void SearchCustomerByLastName()
        {
            Console.Write("Enter the customer's last name: ");
            string lastName = Console.ReadLine();

            foreach (customer customer in customerList)
            {
                if (customer.LastName.Equals(lastName,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Customer Details:");
                    Console.WriteLine($"Customer ID: {customer.CustomerID}");
                    Console.WriteLine($"First name: {customer.FirstName}");
                    Console.WriteLine($"Last name: {customer.LastName}");
                    Console.WriteLine($"Date of birth (dd/mm/yyyy): {customer.DateOfBirth}");
                    Console.WriteLine($"Gender: {customer.Gender}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine($"Village: {customer.Village}");
                    Console.WriteLine($"District: {customer.District}");
                    Console.WriteLine($"Phone number (including state code): {customer.PhoneNumber}");
                }
            }

        }

        public void DisplayListOfCustomersInVillage()
        {
            Console.Write("Enter the Village or District: ");
            string val = Console.ReadLine();
            Console.WriteLine($"slno\tCustomerID\tFirstName\tLastName\tGender\tPhone Number");
            int i = 1;
            foreach (customer customer in customerList)
            {
                if (customer.Village.Equals(val,StringComparison.OrdinalIgnoreCase) || customer.District.Equals(val,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i}\t{customer.CustomerID}\t\t{customer.FirstName}\t\t{customer.LastName}" +
                        $"\t\t{customer.Gender}\t{customer.PhoneNumber}");
                    i++;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(); 
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Search Customer by Last Name");
                Console.WriteLine("3. Display List of Customers in Taluk or Village");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------------------------");

                switch (choice)
                {
                    case "1":
                        bank.AddCustomer();
                        break;
                    case "2":
                        bank.SearchCustomerByLastName();
                        break;
                    case "3":
                        bank.DisplayListOfCustomersInVillage();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
