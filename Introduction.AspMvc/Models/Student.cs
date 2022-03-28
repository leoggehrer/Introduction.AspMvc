namespace Introduction.AspMvc.Models
{
    public class Student
    {
        private static int Counter = 0;
        public Student()
        {
            Id = ++Counter;
        }
        public int Id { get; set; }
        public string MatriculationNumber { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }
}
