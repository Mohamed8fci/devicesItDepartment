using devicesItDepartment.Models;
using Microsoft.EntityFrameworkCore;

namespace devicesItDepartment.repository
{
    public class DeviceRepository : IDeviceRepository
    {

        TaskContext Context;

        public DeviceRepository(TaskContext context)
        {
            Context = context;
        }
        public IEnumerable<Device> GetAll()
        {
            return Context.Devices.Include(d => d.Category).
                Include(d => d.PropertyValues).ToList();
        }

        public async Task<Device> GetById(int id)
        {
            return await Context.Devices.Include(d => d.Category)
                .Include(d => d.PropertyValues)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public void Add(Device device)
        {
            Context.Devices.Add(device);
            Context.SaveChanges();
        }

        public async Task Update(Device device)
        {
            Context.Devices.Update(device);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var device = await GetById(id);
            if (device != null)
            {
                Context.Devices.Remove(device);
                await Context.SaveChangesAsync();
            }
        }
    }
}
