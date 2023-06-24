namespace devicesItDepartment.Models
{
    public class PropertyValue
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual Device Device { get; set; }

        public virtual Property Property { get; set; }

    }
}
