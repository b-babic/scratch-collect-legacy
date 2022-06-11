namespace scratch_collect.Model
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GradientStart { get; set; }

        public string GradientStop { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}