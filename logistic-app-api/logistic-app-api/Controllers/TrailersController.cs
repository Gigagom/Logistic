using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Trailers;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/trailers")]
    [ApiController]
    public class TrailersController : ControllerBase
    {
        private readonly TrailersRepository _trailers;
        private readonly IMapper _mapper;
        public TrailersController(IRepository<Trailer> repository, IMapper mapper)
        {
            _trailers = (TrailersRepository)repository;
            _mapper = mapper;
        }

        //GET api/trailers
        [HttpGet]
        public ActionResult<IEnumerable<TrailersReadDto>> GetAllCars()
        {
            var cars = _trailers.GetAll();
            return Ok(_mapper.Map<IEnumerable<TrailersReadDto>>(cars));
        }

        //GET api/trailers/{id}
        [HttpGet("{id}")]
        public ActionResult<TrailerReadDto> GetCarById(int id)
        {
            var car = _trailers.GetById(id);
            if (car != null)
            {
                return Ok(_mapper.Map<TrailerReadDto>(car));
            }
            return NotFound();
        }

        //POST api/trailers
        [HttpPost]
        public ActionResult<TrailerReadDto> CreateCar(TrailerCreateDto _trailer)
        {
            var trailer = _mapper.Map<Trailer>(_trailer);
            _trailers.Create(trailer);
            _trailers.SaveChanges();

            var response = _mapper.Map<TrailerReadDto>(trailer);

            return Ok(response);
        }

        //PUT api/trailers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, TrailerUpdateDto trailerUpdateDto)
        {
            var trailerFromRepo = _trailers.GetById(id);
            if (trailerFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(trailerUpdateDto, trailerFromRepo);
            _trailers.Update(trailerFromRepo);
            _trailers.SaveChanges();

            return NoContent();
        }

        //DELETE api/trailers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var trailerFromRepo = _trailers.GetById(id);
            if (trailerFromRepo == null)
            {
                return NotFound();
            }
            _trailers.Delete(trailerFromRepo);
            _trailers.SaveChanges();

            return NoContent();
        }
    }
}
