using System;
using System.Collections.Generic;
using Jokes.Core.Entities;
using Jokes.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jokes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IRepository _repository;
        public JokesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/jokes
        [HttpGet]
        public ActionResult<IEnumerable<Joke>> Get() =>
            _repository.List<Joke>();

        // GET api/jokes/#
        [HttpGet("{id}")]
        public ActionResult<Joke> Get(int id) =>
            _repository.GetById<Joke>(id);
            

        // GET api/jokes/page/#,#
        [HttpGet("page/{pg}.{mpp?}")]
        public ActionResult<Page<Joke>> Page(int pg, int mpp = 2)
        {
            var step = mpp;
            var start = (pg - 1) * step;

            return new Page<Joke>()
            {
                Content = _repository.List<Joke>(start, step),
                Count = _repository.Count<Joke>(),
                PageNumber = pg,
                MaxPerPage = mpp
            };
        }

        // GET api/jokes/random
        [HttpGet("random")]
        public ActionResult<Joke> Random()
        {
            var random = new Random();
            return _repository.GetById<Joke>(random.Next(1, _repository.Count<Joke>() + 1));
        }

        // POST api/jokes
        [HttpPost]
        public ActionResult<string> Post([FromBody] Joke joke)
        { 
            if (!ModelState.IsValid)
            { return "Model is not valid."; }
            else
            { 
                _repository.Create(joke); 
                return "Joke added.";
            }
        }

        // PUT api/jokes/#
        //[HttpPut]
        //public ActionResult<string> Put([FromBody] Joke joke)
        //{ 
        //    if (!ModelState.IsValid)
        //    { return "Model is not valid."; }
        //    else if (_repository.GetById<Joke>(joke.Id) == default(Joke))
        //    { return "Joke does not exist."; }
        //    else
        //    {
        //        _repository.Update(joke);
        //        return "Joke updated.";
        //    }
        //}

        // DELETE api/jokes/#
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteById(int id)
        {
            if (_repository.GetById<Joke>(id) == default(Joke))
            { return "Joke does not exist."; }
            else
            {
                _repository.DeleteById<Joke>(id);
                return "Joke deleted.";
            }
        }
    }
}
