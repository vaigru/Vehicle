using System.Linq;
using Vehicle.DataContext;
using Vehicle.Repository.Base;

namespace Vehicle.Repository.Repositories
{
    public class VehicleRepo : BaseRepository<DataContext.Vehicle>
    {
        public VehicleRepo(IVehicleDBContext context) : base(context) { }

        public DataContext.Vehicle GetVehicle(string vinNumber)
        {
            return context.Vehicles.FirstOrDefault(v => v.Vin == vinNumber);
        }
    }
}