﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Enums.Enums;

namespace DataAccess.Entities
{
    public class UsersPermission
    {
        [Key]
        public long Id { get; set; }
        public bool CanEdit { get; set; }
        public bool CanView { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public Page Page { get; set; }
    }
}