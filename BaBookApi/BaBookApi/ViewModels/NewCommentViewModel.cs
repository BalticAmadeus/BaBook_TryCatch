﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BaBookApi.ViewModels
{
    public class NewCommentViewModel
    {
        [JsonProperty("comment")]
        public string CommentText { get; set; }
    }
}