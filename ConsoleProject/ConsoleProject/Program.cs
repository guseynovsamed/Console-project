



using ConsoleProject.Controllers;

UserController userController = new UserController();

GroupController groupController = new GroupController();


while (true)
{
	string inte = Console.ReadLine();

	switch (inte)
	{
		case "1":
			groupController.Create();
			break;
		case "2":
			groupController.Delete(); 
			break;
		case "3":
			groupController.GetById();
			break;
		case "4":
			groupController.GetAll();
			break;
		case "5":
			groupController.Search();
			break;
		case "6":
			groupController.Sorting();
			break;


	}
}
