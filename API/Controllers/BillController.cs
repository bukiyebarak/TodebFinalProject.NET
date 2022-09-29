using Business.Abstract;
using DTO.Apartment;
using DTO.Bill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;

        public BillController(IBillService billService)
        {
            _service = billService;
        }

       
        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CreateBillRequest bill)
        {
            var response = _service.Insert(bill);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put(UpdateBillRequest bill)
        {
            var response = _service.Update(bill);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteBillRequest bill)
        {
            var response = _service.Delete(bill);
            return Ok(response);
        }

        [HttpGet("GetUserBill")]
        public IActionResult GetUserBill()
        {
            var data = _service.GetUserBill();
            return Ok(data);
        }
    }
}
