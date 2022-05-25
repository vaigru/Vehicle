using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using Vehicle.Core.ApiModels;
using Vehicle.DataContext;
using Vehicle.UnitOfWork;

namespace Vehicle.WebAPI.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/v1/vehicle/{vin}/{token}")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleDBContext _context;
        private VehicleUnitOfWork _vehicleUnitOfWork;

        public VehicleController(IVehicleDBContext context)
        {
            _context = context;
            _vehicleUnitOfWork = new VehicleUnitOfWork(_context);
        }

        [HttpPost]
        [Route("SetVehicleData")]
        public GenericAnswer SetVehicleData(string vin, string token, VehicleRequest request)
        {
            return GetGenericAnswer(vin, token, request, _vehicleUnitOfWork.SetVehicleData);
        }

        [HttpGet]
        [Route("GetVehicleRecords")]
        public GenericAnswer GetVehicleRecords(string vin, string token)
        {
            return GetGenericAnswer(vin, token, null, _vehicleUnitOfWork.GetVehicleRecords);
        }

        private GenericAnswer GetGenericAnswer(string vin, string token, VehicleRequest request, Func<string, VehicleRequest, object> getter)
        {
            var toReturn = new GenericAnswer();

            try
            {
                new AuthUnitOfWork(_context).IsAuthorized(vin, token);
                toReturn.Result = getter(vin, request);
            }
            catch (Exception ex)
            {
                toReturn.Message = new AnswerMessage() { IsSuccess = false };
                toReturn.Message.ErrorMessages.Add(ex.Message);
            }

            return toReturn;
        }
    }
}
