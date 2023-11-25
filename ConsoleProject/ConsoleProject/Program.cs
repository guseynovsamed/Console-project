



using ConsoleProject.Controllers;
using Domain.Models;

UserController userController = new UserController();
GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

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
		case "7":
			groupController.Edit();
			break;

	}
}





//while (true)
//{
//	string inte = Console.ReadLine();

//	switch (inte)
//	{
//		case "1":
//			studentController.Create();
//			break;
//		case "2":
//			studentController.Delete();
//			break;
//		case "3":
//			break;
//		case "4":
//            studentController.GetById();
//            break;
//		case "5":
//			studentController.GetAll();
//			break;
//		case "6":
//			studentController.Search();
//			break;
//		case "7":
//			studentController.Filter();
//			break;

//	}
//}

//using System.Text.RegularExpressions;

//Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

//bool result  = regex.IsMatch("hello@gmail.com");
//Console.WriteLine(  result);


//using System.Text.RegularExpressions;

//Regex regex = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

//bool result = regex.IsMatch("0559782212");
//Console.WriteLine(result);


//while (true)
//{
//    userController.Register();
//}