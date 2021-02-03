using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskTrackingApp
{
    public class Tasks
    {
        public void Add()
        {
            string folderpath = CreateFolderLocation();
            Prints();            
            string taskname = GetTaskName();
            string taskdesc = AddDescription();
            string fileName = taskname + ".txt";
            string filePath = folderpath + "\\" + fileName;

            if (File.Exists(filePath))
            {
                Console.WriteLine("Task already exists");
                Add();
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(filePath))
                    outputFile.WriteLine(taskdesc);
                Console.WriteLine("File Created with File Name:" + fileName+ "\n");
            }
            Console.Clear();
            StartMenu start = new StartMenu();
            start.MainMenu();
        }
        public static void Prints()
        {
            Console.WriteLine("Creating A New Task\n");
            Console.WriteLine("Enter the name of the task you would like add:");
        }
        public static string GetTaskName()
        {
            string task = Console.ReadLine();
            Console.WriteLine("");
            return task;
        }
        public static string AddDescription()
        {
            Console.WriteLine("Enter a description:");
            string description = Console.ReadLine();
            return description;
        }
        public string CreateFolderLocation()
        {
            //Create directory. User must be running as admin
            string root = @"C:\Temp";
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
            return root;       
        }
        public void ViewTaskList()
        {
            Console.Clear();

            string root = @"C:\Temp";
            string[] fileEntries = Directory.GetFiles(root);
            string[] taskNames = new string[fileEntries.Count()];

            if (fileEntries.Count() == 0)
            {
                Console.WriteLine("There are no tasks to display.");
                StartMenu start = new StartMenu();
                start.MainMenu();
            }

            for (int i = 1; i < fileEntries.Count() + 1; i++)
            {
                string taskName = fileEntries[i - 1].Substring(root.Length + 1);
                taskName = taskName.Substring(0, taskName.IndexOf('.'));
                taskNames[i - 1] = taskName;
                Console.WriteLine($"{i}.  {taskName}");
            }
            DisplayTask(fileEntries, taskNames);            
        }
        public void DisplayTask(string[] fileEntries, string[] taskNames)
        {
            string root = @"C:\Temp\";
            Console.WriteLine("Enter the name of the task you wish to see or 'Return' to go back to the main menu: ");
            string input = Console.ReadLine();   
            
            for (int i = 0; i < taskNames.Length; i++)
            {
                if (input.ToLower() == taskNames[i].ToLower())
                {
                    Console.WriteLine($"This task entails...\n {fileEntries[i]}");
                    using (StreamReader sr = new StreamReader(root + taskNames[i] + ".txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }                   
                    DeleteTask(taskNames, root, i);
                }
            }
            if (input == "Return" || input == "return" || input == "RETURN")
            {
                StartMenu start = new StartMenu();
                Console.Clear();
                start.MainMenu();
            }
            else
                DisplayTask(fileEntries, taskNames);           
        }
        private void DeleteTask(string[] taskNames, string root, int i)
        {
            Console.WriteLine("Do you want to remove this task?");
            string remove = Console.ReadLine().ToLower();
            if (remove == "y" || remove == "yes")
            {
                string fileName = root + taskNames[i] + ".txt";
                if (File.Exists(fileName))
                    File.Delete(fileName);
                ViewTaskList();
            }
            else if (remove == "n" || remove == "no")
                ViewTaskList();
            else            
                DeleteTask(taskNames, root, i);
        }
    }
}
