
namespace DataToObject
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"{Id}  {Name}  {Marks}";
        }
    }
}