﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfOccurance { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual User OwnerUser { get; set; }
        public virtual Group OfGroup { get; set; }

        public virtual List<User> AttendingUsers { get; set; }
        public virtual List<Invitation> SentInvitations { get; set; }
    }
}