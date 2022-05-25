using System;
using Vehicle.Core.Constants;
using Vehicle.Core.Helpers;
using Vehicle.DataContext;
using Vehicle.Repository.Repositories;

namespace Vehicle.UnitOfWork
{
    public class AuthUnitOfWork : IDisposable
    {
        private IVehicleDBContext _context;

        public AuthUnitOfWork(IVehicleDBContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public string Authorize(string vin)
        {
            var toReturn = string.Empty;

            var vehicle = new VehicleRepo(_context).GetVehicle(vin);

            if (vehicle != null)
            {
                if (!CacheHelpers.IsCached(vehicle.Vin))
                {
                    CacheHelpers.SetTokenCache(vehicle.Vin, Guid.NewGuid().ToString());
                }

                toReturn = CacheHelpers.GetCached<string>(vehicle.Vin);
            }
            else
            {
                throw new UnauthorizedAccessException(string.Format(SystemMessageConstants.VehicleNotFound, vin));
            }

            return toReturn;
        }

        public void IsAuthorized(string vin, string token)
        {
            if (!CacheHelpers.IsCached(vin) || CacheHelpers.GetCached<string>(vin) != token)
            {
                throw new UnauthorizedAccessException(SystemMessageConstants.VehicleNotAuthorized);
            }
        }
    }
}
