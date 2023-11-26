
using ConsoleProject.Controllers;
using Domain.Models;
using Service.Enums;
using Service.Helpers.Extensions;
using System.Numerics;
using System;

UserController userController = new UserController();
GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

while (true)
{
    ConsoleColor.DarkYellow.WriteConsole("Choose one option : \n1-Register  \n2-Login ");
    string operationStr = Console.ReadLine();
    bool isFormatOperation = int.TryParse(operationStr, out int oparation);

    switch (oparation)
    {
        case (int)UserOperationType.Register:
            userController.Register();
            break;
        case (int)UserOperationType.Login:
            bool isLogin = userController.Login();
            if (isLogin)
            {
                goto Next;
            }
            break;
        default:
            ConsoleColor.Red.WriteConsole("Invalid operation , enter again operation");
            break;
    }
}

Next: ConsoleColor.DarkBlue.WriteConsole("Welcome our application");

while (true)
{
    Menu();
    Console.WriteLine("Enter one option");
    Operation: string opStr = Console.ReadLine();
    bool IsCorrectFormatOperation = int .TryParse(opStr, out int oparation);
    switch (oparation)
    {
        case (int)OperationTypes.GroupCreate:
            groupController.Create(); break;
        case (int)OperationTypes.GroupDelete:
            groupController.Delete(); break;
        case (int)OperationTypes.GroupEdit:
            groupController.Edit(); break;
        case (int)OperationTypes.GroupGetById:
            groupController.GetById(); break;
        case (int)OperationTypes.GroupGetAll:
            groupController.GetAll(); break;
        case (int)OperationTypes.GroupSearch:
            groupController.Search(); break;
        case (int)OperationTypes.GroupSorting:
            groupController.Sorting(); break;
        case (int)OperationTypes.StudentCreate:
            studentController.Create(); break;
        case (int)OperationTypes.StudentDelete:
            studentController.Delete(); break;
        case (int)OperationTypes.StudentEdit:
            studentController.Edit(); break;
        case (int)OperationTypes.StudentGetById:
            studentController.GetById();break;
        case (int)OperationTypes.StudentGetAll:
            studentController.GetAll(); break;
        case (int)OperationTypes.StudentFilter:
            studentController.Filter(); break;
        case (int)OperationTypes.StudentSearch:
            studentController.Search(); break;
        default:
            ConsoleColor.Red.WriteConsole("Invalid operation , please enter again");
            goto Operation;


    }
}
static void Menu()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option: Group operations: 1 - Create, 2 - Delete, 3 - Edit, 4 - GetById, 5 - GetAll, 6 - Search, 7 - Sorting");
    ConsoleColor.Cyan.WriteConsole(" Student operations: 8 - Create, 9 - Delete, 10 - Edit, 11 - GetById, 12 - GetAll,13 - Filter, 14 - Search");
}