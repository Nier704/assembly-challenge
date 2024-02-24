using System.ComponentModel.Design;
using System.Text;

class UserManagerApp {

   private static UserService _service = new();

   public void Run(){
        ShowMenu();
   }

   private static void ShowMenu(){
      while (true){
         StringMap("== User Manager App ==\n\n[1] View all users\n[2] Search user by id\n[3] Add user\n[4] Update user\n[5] Delete User\n[6] Generate notepad file\n[7] Exit\n\n: ");
         String input = Console.ReadLine()!;
         switch (input){
            case "1":
               GetAllUsers();
               break;
            case "2":
               SearchUser();
               break;
            case "3":
               AddUser();
               break;
            case "4":
               UpdateUser();
               break;
            case "5":
               DeleteUser();
               break;
            case "6":
               GenerateFile();
               break;
            case "7":
               StringMap("closing...");
               Thread.Sleep(2000);
               Environment.Exit(0);
               break;
            default:
               Console.Clear();
               StringMap("Invalid key...");
               PressAnyKey();
               break;
         }
      }
   }

   private static void GenerateFile()
   {
      String filePath = @"code-response.txt";

      if (_service.GetAllUsers().EntityList!.Count == 0){
         StringMap("User list is empty\n");
         PressAnyKey();
         return;
      }
      
      try {
         if (File.Exists(filePath)) File.Delete(filePath);

         using (StreamWriter sw = File.CreateText(filePath)){
            StringBuilder sb = new();

            foreach (User user in _service.GetAllUsers().EntityList!){
               sb.AppendLine(user.ToString());
            }

            sw.Write(sb.ToString());
            StringMap($"Notepad created at {filePath}");
            PressAnyKey();
         }
      } catch (Exception e){
         StringMap("ERROR: \n\n" + e.Message);
      }
   }

   private static void GetAllUsers(){
      if (_service.GetAllUsers().EntityList!.Count == 0){
         StringMap("User list is empty\n");
         PressAnyKey();
         return;
      }

      foreach(User user in _service.GetAllUsers().EntityList!){
         Console.WriteLine(user);
      }

      PressAnyKey();

   }

   private static void DeleteUser()
   {
      StringMap("== Delete User ==\n\n");
      if (_service.GetAllUsers().EntityList!.Count > 0){
         Console.Write("[TO DELETE] User id: ");
         int inputId = int.Parse(Console.ReadLine()!);
         var res = _service.DeleteUser(inputId);
         StringMap($"Status Code: {res.StatusCode}\nDescription: {res.Description}");
      } else Console.WriteLine("User list empty.");
      PressAnyKey();
   }
   private static void UpdateUser()
   {
      StringMap("== Update User ==\n\n");
      if (_service.GetAllUsers().EntityList!.Count > 0){
         Console.Write("User id: ");
         int inputId = int.Parse(Console.ReadLine()!);
         var res = _service.GetUserById(inputId);
         if (res.StatusCode == 200){
            Console.WriteLine(res.Entity);
            Console.Write("Properties to update:\n");
            Console.Write($"\nOld Name: {res.Entity!.Name}\nNew name: ");
                  String newName = Console.ReadLine()!;
                  Console.Write($"\nOld Email: {res.Entity.Email}\nNew Email: ");
                  String newEmail = Console.ReadLine()!;
                  Console.Write($"\nOld Password: {res.Entity.Password}\nNew Password: ");
                  String newPassword = Console.ReadLine()!;

                  var newUserDTO = new UserDTO(newName, newEmail, newPassword);
                  var res2 = _service.UpdateUser(inputId, newUserDTO);

                  StringMap($"Status Code: {res2.StatusCode}\nDescription: {res2.Description}");
         }
         else StringMap(res.Description!);
      }
      else Console.WriteLine("\nUser list empty...\n");
      PressAnyKey();
   }

   private static void AddUser()
   {
      StringMap("== Add User ==\n\n");
      Console.Write("Name: ");
      String name = Console.ReadLine()!;
      Console.Write("Email: ");
      String email = Console.ReadLine()!;
      Console.Write("Password: ");
      String password = Console.ReadLine()!;

      UserDTO userDTO = new(name, email, password);
      var res = _service.AddUser(userDTO);
      StringMap($"StatusCode: {res.StatusCode}\n{res.Description}\n");
      PressAnyKey();
   }

   private static void SearchUser(){
      StringMap("== Search User ==\n\n");
      if (_service.GetAllUsers().EntityList!.Count <= 0){
         Console.WriteLine("Empty");
      }
      else {
         Console.Write("User id: ");
         int targetId = int.Parse(Console.ReadLine()!);

         var res = _service.GetUserById(targetId);
         if (res.StatusCode == 200){
            Console.WriteLine($"status: {res.Description}");
            Console.WriteLine(res.Entity);
         } else {
            Console.WriteLine($"{res.Description}");
         }
      }
      PressAnyKey();
   }

   private static void PressAnyKey(){
      Console.Write("\nPress any key to leave... ");
      Console.ReadLine();
   }

   private static void StringMap(String str){
      Console.Clear();
      List<char> chars = [];
      foreach (char str_char in str){
         chars.Add(str_char);
         Console.Clear();
         foreach (char c in chars) Console.Write(c);
         Thread.Sleep(20);
      }
   }

}