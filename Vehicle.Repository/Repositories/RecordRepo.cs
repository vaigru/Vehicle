using System.Collections.Generic;
using System.Linq;
using Vehicle.DataContext;
using Vehicle.Repository.Base;

namespace Vehicle.Repository.Repositories
{
    public class RecordRepo : BaseRepository<Record>
    {
        public RecordRepo(IVehicleDBContext context) : base(context) { }

        public List<Record> GetVehicleRecords(int vehicleId)
        {
            return context.Records.Where(r => r.VehicleId == vehicleId).ToList();
        }
    }
}