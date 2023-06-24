namespace devicesItDepartment.Models
{
    public class Property
    {
        public int Id { get; set;}
        public string Description { get; set;}

        public virtual DeviceCategory Category { get; set;}

        public virtual ICollection<PropertyValue> PropertyValues { get; set;}
    }
}
