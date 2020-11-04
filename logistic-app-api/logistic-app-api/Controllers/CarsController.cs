using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Cars;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsRepository _cars;
        private readonly IMapper _mapper;
        public CarsController(IRepository<Car> repository, IMapper mapper)
        {
            _cars = (CarsRepository)repository;
            _mapper = mapper;
        }

        //GET api/cars
        [HttpGet]
        public ActionResult<IEnumerable<CarReadDto>> GetAllCars()
        {
            var cars = _cars.GetAll();
            return Ok(_mapper.Map<IEnumerable<CarsReadDto>>(cars));
        }

        //GET api/cars/{id}
        [HttpGet("{id}")]
        public ActionResult<CarReadDto> GetCarById(int id)
        {
            var car = _cars.GetById(id);
            if (car != null)
            {
                return Ok(_mapper.Map<CarReadDto>(car));
            }
            return NotFound();
        }

        //POST api/cars
        [HttpPost]
        public ActionResult<CarReadDto> CreateCar(CarCreateDto _car)
        {
            var car = _mapper.Map<Car>(_car);
            _cars.Create(car);
            _cars.SaveChanges();

            var response = _mapper.Map<CarReadDto>(car);

            return Ok(response);
        }

        //PUT api/cars/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, CarUpdateDto carUpdateDto)
        {
            var carFromRepo = _cars.GetById(id);
            if (carFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(carUpdateDto, carFromRepo);
            _cars.Update(carFromRepo);
            _cars.SaveChanges();

            return NoContent();
        }

        //DELETE api/cars/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var carFromRepo = _cars.GetById(id);
            if (carFromRepo == null)
            {
                return NotFound();
            }
            _cars.Delete(carFromRepo);
            _cars.SaveChanges();

            return NoContent();
        }
    }
}
