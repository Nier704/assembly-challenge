class UserService {

   public List<User> users;

   public UserService(){
      users = [];
   }

   public Response GetAllUsers(){
      return new Response(200, "success", users);
   }

   public Response GetUserById(int id){
      if (id < 1) return new Response(400, "The id can't be lower then 1");
      foreach (User user in users) if (user.Id == id) return new Response(200, "User found", user);
      return new Response(404, $"User with id {id} not found");
   }

   public Response AddUser(UserDTO userDTO){
      if (userDTO.Name == "") return new Response(400, "User name can't be empty");
      if (userDTO.Email == "") return new Response(400, "User email can't be empty");
      if (userDTO.Password == "") return new Response(400, "User password can't be empty");
      var newUser = new User(userDTO, users);
      users.Add(newUser);
      return new Response(201, "User added");
   }

   public Response UpdateUser(int id, UserDTO userDTO){
      if (String.IsNullOrEmpty(userDTO.Name)) return new Response(400, "New name is required");
      if (String.IsNullOrEmpty(userDTO.Email)) return new Response(400, "New email is required");
      if (String.IsNullOrEmpty(userDTO.Password)) return new Response(400, "New password is required");

      var res = GetUserById(id);
      var oldUser = res.Entity;
      if (res.StatusCode == 200){
         users.ForEach(user => {
            if (user.Name == oldUser!.Name){
               user.Name = userDTO.Name;
               user.Email = userDTO.Email;
               user.Password = userDTO.Password;
            }
         });
         return new Response(200, $"The user {oldUser!.Name} has been updated");
      }
      return new Response(409, "The user can't be updated");
   }

   public Response DeleteUser(int id){
      var res = GetUserById(id);
      if (res.StatusCode == 200) {
         users.Remove(res.Entity!);
         return new Response(200, $"User {res.Entity!.Name} has been deleted");
      }
      return res;
   }

}