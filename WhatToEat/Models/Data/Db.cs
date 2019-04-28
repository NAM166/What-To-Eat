using System;
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
        public DbSet<ProductDTO> Products { get; set; }

        public System.Data.Entity.DbSet<WhatToEat.Models.ViewModels.Eatery.ProductVM> ProductVMs { get; set; }

        public System.Data.Entity.DbSet<WhatToEat.Models.ViewModels.Pages.PageVM> PageVMs { get; set; }

        public System.Data.Entity.DbSet<WhatToEat.Models.ViewModels.Pages.SidebarVM> SidebarVMs { get; set; }
    }
}