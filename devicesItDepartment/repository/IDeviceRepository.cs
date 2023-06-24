using devicesItDepartment.Models;

namespace devicesItDepartment.repository
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetAll();
        public  Task<Device> GetById(int id);
        public void Add(Device device);

        public  Task Update(Device device);
        public  Task Delete(int id);

    }
}
