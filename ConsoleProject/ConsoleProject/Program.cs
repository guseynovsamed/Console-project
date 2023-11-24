



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
			userController.Register();
			break;
		case "2":
			userController.Login();
			break;
		//case "3":
		//	groupController.GetById();
		//	break;
		//case "4":
		//	groupController.GetAll();
		//	break;
		//case "5":
		//	groupController.Search();
		//	break;
  //      case "6":
  //          groupController.Sorting();
  //          break;
  //      case "7":
  //          groupController.Edit();
  //          break;

    }
}
///




//while (true)
//{
//	string inte = Console.ReadLine();

//	switch (inte)
//	{
//		case "1":
//			Student student = studentController.Create();
//			groupController.AddStudentToGroup(student);
//			break;
//		case "2":
//			studentController.Delete();
//			break;
//		case "3":
//			studentController.GetAll();
//			break;
//		case "4":
//			studentController.Search();
//			break;
//		case "5":
//			break;
//		case "6":
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