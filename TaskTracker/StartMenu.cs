using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackingApp
{
    public class StartMenu
    {
        public void MainMenu()
            {
            Console.WriteLine("1.) View Task List");
            Console.WriteLine("2.) Add Task List");
            Console.WriteLine("3.) Close Application");
            Console.WriteLine("Enter the number for the option you want to go to:   ");

            Tasks task = new Tasks();
            task.CreateFolderLocation();

            int opt;
            while (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Enter the number for the option you want to go to:  ");
            }

            switch (opt)
            {
                case 1:
                    task.ViewTaskList();
                    break;
                case 2:
                    Console.Clear();
                    task.Add();
                    break;
                case 3:
                    Console.Clear();
                    Exit();
                    return;
                default:
                    Console.WriteLine("Incorrect Selection. Try Again.");
                    MainMenu();
                    return;
            }         
            
        }          
        public void Greeting()
        {
            if (DateTime.Now.Hour < 12)
                Console.WriteLine("Good Morning User");
            else if (DateTime.Now.Hour < 17)
                Console.WriteLine("Good Afternoon User");            
            else            
                Console.WriteLine("Good Evening User");
        }
        public void Exit()
        {
            Console.WriteLine("Exiting program...");
            Console.WriteLine("Thanks for stopping by!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    } 
}
