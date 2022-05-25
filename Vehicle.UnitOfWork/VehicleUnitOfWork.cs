using System;
using System.Collections.Generic;
using Vehicle.Core.ApiModels;
using Vehicle.Core.Constants;
using Vehicle.Core.MvvMs;
using Vehicle.DataContext;
using Vehicle.Repository.Repositories;

namespace Vehicle.UnitOfWork
{
    public class VehicleUnitOfWork : IDisposable
    {
        private IVehicleDBContext _context;

        public VehicleUnitOfWork(IVehicleDBContext context)
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

        public string SetVehicleData(string vin, VehicleRequest request)
        {
            var toReturn = string.Empty;

            var vehicle = new VehicleRepo(_context).GetVehicle(vin);

            if (vehicle != null)
            {
                new RecordRepo(_context).Insert(
                    new Record()
                    {
                        VehicleId = vehicle.Id,
                        Latitude = request.Latitude,
                        Longitude = request.Longitude,
                        Speed = request.Speed,
                        Timestamp = DateTime.Now
                    });

                Save();
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(SystemMessageConstants.VehicleNotFound, vin));
            }

            return toReturn;
        }

        public List<VehicleRecordMvvM> GetVehicleRecords(string vin, VehicleRequest request)
        {
            var toReturn = new List<VehicleRecordMvvM>();

            var vehicle = new VehicleRepo(_context).GetVehicle(vin);

            if (vehicle != null)
            {
                var records = new RecordRepo(_context).GetVehicleRecords(vehicle.Id);

                records.ForEach(r =>
                    toReturn.Add(
                        new VehicleRecordMvvM()
                        {
                            Latitude = r.Latitude,
                            Longitude = r.Longitude,
                            Speed = r.Speed,
                            Timestamp = r.Timestamp
                        }));
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(SystemMessageConstants.VehicleNotFound, vin));
            }

            return toReturn;
        }
    }
}
