using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoApp
{
    public class TodoApp
    {
        List<TodoItem> Items = new List<TodoItem>();

        int count = 1;

        public string AddTodoItem(string todo)
        {
            string message = string.Empty;
            int previousItemCount = Items.Count;

           if(todo == string.Empty)
            {
                message = "No item was recorded";

            }
           else
            {
                var task = new TodoItem(count, todo);
                Items.Add(task);
                int updatedItemCount = Items.Count;
                count++;

                if (updatedItemCount > previousItemCount)
                {
                    message = "Item added succesfully!";
                }
            }
           

           return message;
            
        }

        public string RemoveItem(int itemId)
        {
            string message = string.Empty;
            int previousItemCount = Items.Count;

            var foundItem = Items.Find(i => i.ItemId == itemId);
            if (foundItem != null)
            {
                Items.Remove(foundItem);
                int updatedItemCount = Items.Count;
                if (updatedItemCount < previousItemCount)
                {
                    message = "Record removed succesfully!";
                }
            }
            else
            {
                message = "Record not found!";
            }

            return message;
            
        }

        public string DoItem(int itemId)
        {
            var message = string.Empty;
            var foundItem = Items.Find(i => i.ItemId == itemId);
            
            if (foundItem != null)
            {
                foundItem.Status = true;
                message = "Item was marked as Done!";
            }
            else
            {
                Console.WriteLine("please insert a valid item number");
            }

            return message;
      
        }

        public void Print()
        {
            var table = new ConsoleTable("No", "Item", "Status");
            foreach (var item in Items)
            {
                table.AddRow(item.ItemId, item.Item, item.Status ? "Done" : "Not Done");
            }

            table.Write();
            Console.WriteLine();
            IEnumerable<string> columNames = new List<string> { "Number", "Item","status" };
            var rows = Enumerable.Repeat(new TodoApp(), count);

            //ConsoleTable
            //    .From(rows)
                
            //    .Configure(o => o.NumberAlignment = Alignment.Right)
            //    .Write(Format.Alternative);

            Console.ReadKey();
        }

        public void RunApp()
        {
            var myTask = new TodoApp();

            Console.WriteLine("Welcome to your TodoApp...\n\nPress 1 to start ");
            Console.Write(">>>");
            int checkPoint = int.Parse(Console.ReadLine());

            while (checkPoint == 1)
            {
                Console.Clear();
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Do Item");
                Console.WriteLine("4. Display Items");
                Console.WriteLine("5. Close App");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write(">>>");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {

                    var keepAdding = true;
                    while (keepAdding)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter item you want to add");
                        var task = Console.ReadLine();
                        string response = myTask.AddTodoItem(task);
                        Console.Clear();
                        Console.WriteLine(response);
                        Console.WriteLine("Do you want to add another item? (y/n)");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() != "y")
                        {
                            keepAdding = false;
                        }

                    }
                    
                    
                }

                else if (choice == 2)
                {
                    Console.WriteLine("Enter the item number you want to remove: ");
                    int itemNumber = int.Parse(Console.ReadLine());
                    myTask.RemoveItem(itemNumber);
                }

                else if (choice == 3)
                {
                    Console.WriteLine("Enter the item number you want to Do: ");
                    var itemNumber = int.Parse(Console.ReadLine());
                    var response = myTask.DoItem(itemNumber);
                    Console.WriteLine(response);
                }

                else if (choice == 4)
                {
                    Console.Clear();
                    myTask.Print();
                }

                else if (choice == 5)
                {
                    break;
                }
            }
        
        }
        

    }
}
