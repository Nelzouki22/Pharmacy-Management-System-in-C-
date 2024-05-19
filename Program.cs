using System;
using System.Collections.Generic;

namespace PharmacyManagementSystem
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Pharmacy
    {
        private List<Drug> inventory;
        private int nextId;

        public Pharmacy()
        {
            inventory = new List<Drug>();
            nextId = 1;
        }

        public void AddDrug()
        {
            var drug = new Drug();
            drug.Id = nextId++;
            Console.Write("Enter drug name: ");
            drug.Name = Console.ReadLine();
            Console.Write("Enter drug price: ");
            drug.Price = double.Parse(Console.ReadLine());
            Console.Write("Enter drug quantity: ");
            drug.Quantity = int.Parse(Console.ReadLine());
            inventory.Add(drug);
            Console.WriteLine("Drug added successfully.");
        }

        public void UpdateDrug()
        {
            Console.Write("Enter drug ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var drug = inventory.Find(d => d.Id == id);
            if (drug != null)
            {
                Console.Write("Enter new drug name: ");
                drug.Name = Console.ReadLine();
                Console.Write("Enter new drug price: ");
                drug.Price = double.Parse(Console.ReadLine());
                Console.Write("Enter new drug quantity: ");
                drug.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Drug updated successfully.");
            }
            else
            {
                Console.WriteLine("Drug not found.");
            }
        }

        public void DeleteDrug()
        {
            Console.Write("Enter drug ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            var drug = inventory.Find(d => d.Id == id);
            if (drug != null)
            {
                inventory.Remove(drug);
                Console.WriteLine("Drug deleted successfully.");
            }
            else
            {
                Console.WriteLine("Drug not found.");
            }
        }

        public void SearchDrug()
        {
            Console.Write("Enter drug name to search: ");
            string name = Console.ReadLine();
            var drug = inventory.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (drug != null)
            {
                Console.WriteLine($"ID: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Quantity: {drug.Quantity}");
            }
            else
            {
                Console.WriteLine("Drug not found.");
            }
        }

        public void ListDrugs()
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", "ID", "Name", "Price", "Quantity");
            foreach (var drug in inventory)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", drug.Id, drug.Name, drug.Price, drug.Quantity);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pharmacy = new Pharmacy();
            int choice;

            do
            {
                Console.WriteLine("\nPharmacy Management System");
                Console.WriteLine("1. Add Drug");
                Console.WriteLine("2. Update Drug");
                Console.WriteLine("3. Delete Drug");
                Console.WriteLine("4. Search Drug");
                Console.WriteLine("5. List All Drugs");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        pharmacy.AddDrug();
                        break;
                    case 2:
                        pharmacy.UpdateDrug();
                        break;
                    case 3:
                        pharmacy.DeleteDrug();
                        break;
                    case 4:
                        pharmacy.SearchDrug();
                        break;
                    case 5:
                        pharmacy.ListDrugs();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 0);
        }
    }
}

