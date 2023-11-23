



using ConsoleProject.Controllers;

UserController userController = new UserController();

while (true)
{
    string operation = Console.ReadLine();

	switch (operation)
	{
		case "1":
			userController.Register();
			break;
		case "2":
			userController.Login();
			break;
	}
}
