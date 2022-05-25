using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using Vehicle.Core.ApiModels;
using Vehicle.DataContext;
using Vehicle.UnitOfWork;

namespace Vehicle.WebAPI.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IVehicleDBContext _context;

        public AuthController(IVehicleDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("{vin}")]
        public GenericAnswer Authorize(string vin)
        {
            var toReturn = new GenericAnswer();

            try
            {
                using (var context = new VehicleDBContext())
                {
                    toReturn.Result = new AuthUnitOfWork(_context).Authorize(vin);
                }
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
