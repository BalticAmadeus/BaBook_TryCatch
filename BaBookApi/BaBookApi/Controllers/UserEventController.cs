﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookApi.Mapping;
using BaBookApi.ViewModels;
using Domain.Models;
using DataAccess.Repositories;
using Domain.Utility;
using Microsoft.AspNet.Identity;

namespace BaBookApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserEventController : ApiController
    {
        private readonly UserEventRepository _repository;

        public UserEventController()
        {
                _repository = new UserEventRepository();
        }


        [Route("api/userevent/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEventParticipants(int eventId)
        {
            var eventUsersVM = new List<ParticipantViewModel>();

            try
            {
                var eventUsers = _repository.GetEventParticipants(eventId);

                eventUsers.ForEach(x => eventUsersVM.Add(DomainToViewModelMapping.MapParticipantViewModel(x)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(eventUsersVM);
        }


        [HttpPost]
        [Route("api/userevent")]
        public IHttpActionResult ChangeResponse(AttendanceViewModel model)
        {
            try
            {
                var attendance = ViewModelToDomainMapping.AttendanceViewModelToModel(model);
                _repository.ChangeResponse(attendance, model.EventId, HttpContext.Current.User.Identity.GetUserId());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        

    }
}
