using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> listOfTasks { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAddTasks();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemoveTasks();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTasksList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // get the answer for the option that the user selected
            string opcionSeleccionada = Console.ReadLine();
            return Convert.ToInt32(opcionSeleccionada);
        }

        public static void ShowMenuRemoveTasks()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuTasksList();

                string selectedTask = Console.ReadLine();
                // Remove one position
                int taskID = Convert.ToInt32(selectedTask) - 1;

                if (taskID > (listOfTasks.Count - 1) || taskID < 0)
                    Console.WriteLine("Numero de tarea no valido");
                else
                {
                    if (taskID > -1 && listOfTasks.Count > 0)
                    {
                        string task = listOfTasks[taskID];
                        listOfTasks.RemoveAt(taskID);
                        Console.WriteLine($"Tarea  {task}  eliminada");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAddTasks()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                if (task == "")
                    Console.WriteLine("La tarea no puede estar vacia");
                else
                {
                    listOfTasks.Add(task);
                    Console.WriteLine("Tarea registrada");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("A ocurrido un error al generar la tarea");
            }
        }

        public static void ShowMenuTasksList()
        {
            if (listOfTasks?.Count > 0)
            {
                Console.WriteLine("----------------------------------------");
                int numerationTask = 1;
                listOfTasks.ForEach(task => Console.WriteLine($"{numerationTask++} . {task}"));
                Console.WriteLine("----------------------------------------");

            }
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
