﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;
using BeerDev.Entities;
using BeerDev.Models;
using BeerDev.Repository.Interfaces;
using BeerDev.Repository.Repositories;
using BeerDev.Util;

namespace BeerDev.ControllersApi
{
    public class RankingController : ApiController
    {
        private readonly IBeerRepository _repository;

        public RankingController()
        {
            _repository = new BeerRepository();
        }
        public IHttpActionResult Get()
        {
            IEnumerable<Beer> beers = _repository.GetAll();

            if (beers == null) return NotFound();

            IEnumerable<RankingVm> result = beers.Select(r => new RankingVm
            {
                BeerId = r.Code,
                Name =  r.Name
            }).ToList();
           
            return Ok(result);
        }
    }
}
