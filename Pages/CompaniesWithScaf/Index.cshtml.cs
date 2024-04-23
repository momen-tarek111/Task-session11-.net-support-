﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project3.Database;
using Project3.Models;

namespace Project3.Pages.CompaniesWithScaf
{
    public class IndexModel : PageModel
    {
        private readonly Project3.Database.ApplicationDbContext _context;

        public IndexModel(Project3.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Companies.ToListAsync();
        }
    }
}
