namespace SwagerAppV1._1.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdGrupe { get; set; }
        public Groups Group { get; set; }
    }
}
