using Api.Controllers.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly IBaseService<Customer> iCustomerService;

        public AccountController(IBaseService<Customer> pCustomerService)
        {
            iCustomerService = pCustomerService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateUserIfNotExists(UserDto pUser)
        //{
        //    // TODO: Refactorizar a tabla User, con los roles de admin y de customer
        //    Customer? mCustomer = await iCustomerService.GetAsync(x => x.CustomerId == pUser.Uid);

        //    if (mCustomer == null)
        //    {
        //        mCustomer = new Customer
        //        {
        //            Birthdate = DateTime.MinValue,
        //            CustomerId = pUser.Uid,
        //            Dni = string.Empty,
        //            Email = pUser.Email,
        //            LastName = pUser.DisplayName != null ? pUser.DisplayName.Split(" ").Last() : string.Empty,
        //            Name = pUser.DisplayName != null ? pUser.DisplayName.Split(" ").First() : string.Empty,
        //            PhoneNumber = string.Empty
        //        };

        //        await iCustomerService.AddAsync(mCustomer);

        //        return Ok(new { Code = 1000, Message = "Usuario creado, sin registración completa" });
        //    }
        //    else
        //    {
        //        // TODO: Luego de actualizar la bbdd, preguntar por CompletedRegistration == true
        //        if (mCustomer.Birthdate == DateTime.MinValue)
        //        {
        //            return Ok(new { Code = 1000, Message = "Usuario creado, sin registración completa" });
        //        }
        //        else
        //        {
        //            return Ok(new { Code = 1001, Message = "Usuario existe, con registración completa" });
        //        }
        //    }
        //}
    }
}
