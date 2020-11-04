using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.BorderCrossings;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/bordercrossing")]
    [ApiController]
    public class BorderCrossingsController : ControllerBase
    {
        private readonly BorderCrossingsRepository _borderCrossings;
        private readonly IMapper _mapper;
        public BorderCrossingsController(IRepository<BorderCrossing> repository, IMapper mapper)
        {
            _borderCrossings = (BorderCrossingsRepository)repository;
            _mapper = mapper;
        }

        //GET api/bordercrossing
        [HttpGet]
        public ActionResult<IEnumerable<BorderCrossingReadDto>> GetAll()
        {
            var borderCrossings = _borderCrossings.GetAll();
            return Ok(_mapper.Map<IEnumerable<BorderCrossingReadDto>>(borderCrossings));
        }

        //GET api/bordercrossing/{id}
        [HttpGet("{id}")]
        public ActionResult<BorderCrossingReadDto> GetById(int id)
        {
            var borderCrossing = _borderCrossings.GetById(id);
            if (borderCrossing != null)
            {
                return Ok(_mapper.Map<BorderCrossingReadDto>(borderCrossing));
            }
            return NotFound();
        }

        //POST api/bordercrossing
        [HttpPost]
        public ActionResult<BorderCrossingReadDto> Create(BorderCrossingCreateDto _borderCrossing)
        {
            var borderCrossing = _mapper.Map<BorderCrossing>(_borderCrossing);
            _borderCrossings.Create(borderCrossing);
            _borderCrossings.SaveChanges();

            var response = _mapper.Map<BorderCrossingReadDto>(borderCrossing);

            return Ok(response);
        }

        //PUT api/bordercrossing/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, BorderCrossingUpdateDto borderCrossingUpdateDto)
        {
            var orderCrossingFromRepo = _borderCrossings.GetById(id);
            if (orderCrossingFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(borderCrossingUpdateDto, orderCrossingFromRepo);
            _borderCrossings.Update(orderCrossingFromRepo);
            _borderCrossings.SaveChanges();

            return NoContent();
        }

        //DELETE api/bordercrossing/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var carFromRepo = _borderCrossings.GetById(id);
            if (carFromRepo == null)
            {
                return NotFound();
            }
            _borderCrossings.Delete(carFromRepo);
            _borderCrossings.SaveChanges();

            return NoContent();
        }
    }
}
