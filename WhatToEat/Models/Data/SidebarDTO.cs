using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatToEat.Models.Data
{
    [Table("tblSidebar")]
    public class SidebarDTO
    {
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }

    }
}