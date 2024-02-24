class User {
   public int Id { get; set; }
   public String? Name { get; set; }
   public String? Email { get; set; }
   public String? Password { get; set; }
   public User(UserDTO userDTO, List<User> users){
      Id = users.Count > 0 ? users[^1].Id + 1 : 1;
      Name = userDTO.Name;
      Email = userDTO.Email;
      Password = userDTO.Password;
   }
    public override String ToString()
    {
        return $"\nId: {Id}\nName: {Name}\nEmail: {Email}\nPassword: {Password}\n";
    }
}