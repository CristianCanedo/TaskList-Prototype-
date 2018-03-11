using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TaskList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myList = new TaskList(); // Create new TaskList
            
            // Hard coding tasks for the sake of having a quick list
            string fixGitTitle = "Learn Sockets";
            string fixGitDesc = @"https://docs.oracle.com/javase/tutorial/networking/sockets/definition.html";
            myList.Add(fixGitTitle, fixGitDesc);
            
            string musicTitle = "Learn TCP/IP";
            string musicDesc = "http://www.hardwaresecrets.com/how-tcp-ip-protocol-works-part-1/";
            myList.Add(musicTitle, musicDesc);
            
            string projectTitle = "To Do App";
            string projectDesc = "Transfer code to GUI app, push to Git.";
            myList.Add(projectTitle, projectDesc);
            
            string programTitle = "Socket Programming";
            string programDesc = "http://csharp.net-informations.com/communications/csharp-socket-programming.htm";
            myList.Add(programTitle, programDesc);
            
            myList.DisplayList();
        }
    }
    
    public class Task
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        
        public Task() {}
    
        public Task(string title, string desc)
        {
            Title = title;
            Description = desc;
            IsCompleted = false;
        }
        public Task(int number, string title, string desc)
        {
            Number = number;
            Title = title;
            Description = desc;
            IsCompleted = false;
        }
    }
                                
    public class TaskList : List<Task>
    {
        public TaskList() {}
        
        public void Add(string title, string desc)
        {
            // Set number of TaskItem as size of list + 1
            int numberOfTasks = this.Count();
            int number = numberOfTasks++;
            
            this.Add(new Task(number, title, desc));
        }
        
        public void DisplayList()
        {
            //Console.Clear();
            //Console.WriteLine("\t Task List");
            Console.WriteLine();
            Console.WriteLine("Num |\tTitle\t\t| Description");
            Console.WriteLine("-----------------------------------");
            
            // Check if list is empty
            if (!this.Any()) {
                Console.WriteLine("    All tasks completed!");
            }
            
            foreach(var t in this)
            {
                Console.WriteLine(" {0}\t{1}\t  {2}", t.Number.ToString(),
                                                     t.Title,
                                                     t.Description);
                
            }
        }
        
        ///<summary>
        /// *Prompt user for input of new task title and description
        /// *Add to list
        ///</summary>
        public void CreateNewTask()
        {
            string title = String.Empty;
            string desc = String.Empty;
            
            Console.Write("Enter new task Title: ");
            title = Console.ReadLine().Trim();
            Console.WriteLine("{0}\n", title);
            
            Console.Write("Enter new task Description: ");
            desc = Console.ReadLine();
            Console.WriteLine("\"{0}\"", desc);
            
            this.Add(title, desc);
        }
        
        ///<summary>
        /// *Iterate through list to find completed tasks
        /// *Remove tasks
        /// *Iterate through list once more to reset number properties
        ///</summary>
        public void CheckForCompletedTasks()
        {
            
            for (int i = 0; i < this.Count(); i++)
            {
                if (this[i].IsCompleted == true)
                {
                    this.RemoveAt(i); // Remove TaskItem
                }
            }
            
            
            for (int i = 0; i < this.Count(); i++)
            {
                this[i].Number = i; // Reset numbers
            }
        }
        
        ///<summary>
        /// *Mark indexed item as complete
        /// *Call CheckForCompletedTasks()
        ///</summary>
        public void MarkTaskComplete(int index)
        {
            this[index].IsCompleted = true;
            CheckForCompletedTasks();
        }
        
        public void MarkTaskComplete(params int[] index)
        {
            throw new NotImplementedException();
        }
    }
}
