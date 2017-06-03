﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FindIt.Models;
using FindIt.Repositories;
using FindIt.Repositories.Interfaces;
using FindIt.ViewModels.AddViewModels;

namespace FindIt.Controllers
{

    [RoutePrefix("api/achievements")]
    public class ValuesController : ApiController
    {
        private readonly IAchievementRepository _achievementRepository = new AchievementRepository();

        [HttpGet]
        public async Task<IEnumerable<Achievements>> Get()
        {
            return await _achievementRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet]
        public Achievements Get(string id)
        {
            return _achievementRepository.GetById(Guid.Parse(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] AddAchievementViewModel model)
        {
            _achievementRepository.Insert(model);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] Achievements achievement)
        {
            _achievementRepository.Update(achievement);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(string id)
        {
            _achievementRepository.Delete(Guid.Parse(id));
        }
    }
}
