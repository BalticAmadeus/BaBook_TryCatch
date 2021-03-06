﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBookApi.ViewModels;
using Domain.Models;

namespace BaBookApi.Mapping
{
    public static class DomainToViewModelMapping
    {
        public static AttendanceViewModel AttendanceModelToViewModel(UserEventAttendance attendance)
        {
            var attendanceViewModel = new AttendanceViewModel
            {
                EventId = attendance.Event.EventId,
                Status = attendance.Response
            };

            return attendanceViewModel;
        }
        public static EventListItemViewModel MapEventListItemViewModel(Event model, string userId)
        {
            var vm = new EventListItemViewModel
            {
                EventId = model.EventId,
                GroupName = model.OfGroup.Name,
                OwnerName = model.OwnerUser.DisplayName,
                Date = model.DateOfOccurance,
                Location = model.Location,
                Description = model.Description,
                Title = model.Title,
                IsOwner = model.OwnerUser.Id == userId
            };

            var attendance = model.Attendances.SingleOrDefault(x => x.User.Id == userId);
            if (attendance != null) vm.AttendanceStatus = attendance.Response;

            return vm;
        }

        public static ParticipantViewModel MapParticipantViewModel(UserEventAttendance model)
        {
            return new ParticipantViewModel
            {
                Name = model.User.DisplayName,
                AttendanceStatus = model.Response
            };
        }

        public static GetCommentsViewModel MapGetCommentsViewModel(Comment model)
        {
            return new GetCommentsViewModel
            {
                OwnerUser = model.OwnerUser.DisplayName,
                Text = model.CommentText
            };
        }

        public static GroupViewModel MapGroupViewModel(Group model)
        {
            return new GroupViewModel
            {
                GroupId = model.GroupId,
                GroupName = model.Name
            };
        }

        public static InvitableViewModel MapInvitableViewModel(User user)
        {
            return new InvitableViewModel
            {
                Name = user.DisplayName,
                UserId = user.Id
            };
        }

        public static UserViewModel MapUserViewModel(User user)
        {
            return new UserViewModel()
            {
                UserId = user.Id,
                Username = user.DisplayName
            };
        }
    }
}