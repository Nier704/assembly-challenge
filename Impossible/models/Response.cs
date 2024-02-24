class Response {
   public int StatusCode { get; set; }
   public String? Description { get; set; }
   public User? Entity { get; set; }
   public List<User>? EntityList { get; set; }
   public Response(int statusCode, String description){
      StatusCode = statusCode;
      Description = description;
   }
   public Response(int statusCode, String description, User entity){
      StatusCode = statusCode;
      Description = description;
      Entity = entity;
   }
   public Response(int statusCode, String description, List<User> entityList){
      StatusCode = statusCode;
      Description = description;
      EntityList = entityList;
   }
}