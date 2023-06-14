using HotelFinder.Business.Concrete;
using HotelFinder.Business.Interface;
using HotelFinder.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// --> Get all hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHotels()
        {
            var hotel = _hotelService.GetAllHotels();
            return Ok(hotel); //200 + data
        }

        /// <summary>
        /// --> Get hotels by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelsById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound(); //404
        }

        /// <summary>
        /// --> Get hotels by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelsByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound(); //404
        }

        /// <summary>
        /// --> Create new hotels
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createdHotel = _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); //201 + data
            }
            return BadRequest(); //400 + validation errors
        }

        /// <summary>
        /// --> Update hotels by id
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            var updatedHotel = _hotelService.UpdateHotel(hotel);
            if (_hotelService.GetHotelById != null)
            {
                return Ok(updatedHotel); //200+data
            }
            return NotFound(); //404
        }

        /// <summary>
        /// --> Delete hotels by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.GetHotelById != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200+data
            }
            return NotFound(); //404
        }
    }
}
