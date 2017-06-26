using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialServiceConsultants.Data;
using FinancialServiceConsultants.Models;
using FinancialServiceConsultants.WebAPI.MessageTypes;
using AutoMapper;


namespace FinancialServiceConsultants.WebAPI
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        #region Constructor
        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region HttpGet
        // GET: api/customer
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IActionResult result = null;

            var customer = await _context.Customers.ToArrayAsync();

            if (customer != null)
            {
                result = Json(customer);
            }

            return result ?? BadRequest();
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IActionResult result = null;

            var customer = await _context.Customers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer != null)
            {
                result = Json(customer);
            }

            return result ?? BadRequest();
        }
        #endregion

        #region HttpPost
        // POST api/customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomerV1 message)
        {
            IActionResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    Customer model = _mapper.Map<Customer>(message);
                    _context.Customers.Add(model);
                    await _context.SaveChangesAsync();
                    result = Json(model);//Json(CreatedAtRoute("Get", new { id = model.Id }, model));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return result ?? BadRequest(ModelState);
        }
        #endregion

        #region HttpPut
        // PUT api/customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CustomerV1 message)
        {
            IActionResult result = null;

            if (message == null)
            {
                return BadRequest();
            }
            try
            {
                Customer model = _mapper.Map<Customer>(message);

                var customer = _context.Customers.FirstOrDefault(t => t.Id == id);
                if (customer == null && ModelState.IsValid)
                {
                    return NotFound();
                }

                customer.CompanyName = message.CompanyName;
                customer.ContactEmail = message.ContactEmail;
                customer.ContactNumber = message.ContactNumber;
                customer.ContactPerson = message.ContactPerson;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                result = Json(customer);//Json(CreatedAtRoute("Get", new { id = customer.Id }, customer));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return result ?? BadRequest(ModelState);

        }
        #endregion

        #region HttpDelete
        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var customer = _context.Customers.First(t => t.Id == id);
                if (customer == null && ModelState.IsValid)
                {
                    return NotFound();
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return Json(new NoContentResult());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
