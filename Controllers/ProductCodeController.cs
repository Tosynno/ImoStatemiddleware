using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ImoStatemiddleware.BussinessLogic;
using ImoStatemiddleware.BussinessLogic.Interfaces;
using ImoStatemiddleware.Data.ProductModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace ImoStatemiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCodeController : ControllerBase
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IProductRepo<ProductCode> dataRepo;

        public ProductCodeController(IProductRepo<ProductCode> dataRepository)
        {
            dataRepo = dataRepository;
        }

        // GET: api/ProductCode
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addr = ipEntry.AddressList;
                string[] auth = Encoding.UTF8.GetString(Convert.FromBase64String(this.Request.Headers["Authorization"].ToString().Substring(6))).Split(':');

                AccessAuthentication accessAuthentication = new AccessAuthentication();
                if(accessAuthentication.AuthenticateAccess(auth, addr[addr.Length - 1].ToString()))
                {
                    IEnumerable<ProductCode> productCodes = dataRepo.GetAll();

                    return Ok(productCodes);
                }
                else
                {
                    return NotFound("Invalid Username or Password supplied.");
                }
            }
            catch (Exception c)
            {
                logger.Error("GetException" + c.InnerException);
                return NotFound("Unable to process request at the moment.");
            }


        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            try
            {
                ProductCode productCodes = dataRepo.Get(id);
                var ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addr = ipEntry.AddressList;
                string[] auth = Encoding.UTF8.GetString(Convert.FromBase64String(this.Request.Headers["Authorization"].ToString().Substring(6))).Split(':');

                AccessAuthentication accessAuthentication = new AccessAuthentication();
                if (accessAuthentication.AuthenticateAccess(auth, addr[addr.Length - 1].ToString()))
                {
                    if (productCodes == null)
                    {
                        return NotFound("The Product record couldn't be found.");
                    }
                    return Ok(productCodes);
                }
                else
                {
                    return NotFound("Invalid Username or Password supplied.");
                }
            }
            catch (Exception c)
            {
                logger.Error("GetException" + c.InnerException);
                return NotFound("Unable to process request at the moment.");
            }
        }

    }
}