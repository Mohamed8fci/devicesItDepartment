namespace devicesItDepartment.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //relation one to many between  DeviceCategory and Property
        public virtual ICollection<Property> Properties { get; set; }
    }
}
