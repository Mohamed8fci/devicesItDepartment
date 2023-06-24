namespace devicesItDepartment.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AcuisitionDate { get; set; }
        public string Memo { get; set; }

        public virtual DeviceCategory Category { get; set; }

        public virtual ICollection<PropertyValue>? PropertyValues { get; set; }

    }
}
