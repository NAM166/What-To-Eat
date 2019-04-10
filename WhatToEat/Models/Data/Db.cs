﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WhatToEat.Models.Data
{
    public class Db : DbContext
    {
        public DbSet <PageDTO> Pages { get; set; }
        public DbSet<SidebarDTO> Sidebar { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }

        public System.Data.Entity.DbSet<WhatToEat.Models.ViewModels.Eatery.CategoryVM> CategoryVMs { get; set; }
    }
}