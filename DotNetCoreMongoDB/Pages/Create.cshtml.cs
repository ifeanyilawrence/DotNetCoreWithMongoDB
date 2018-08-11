using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using DotNetCoreMongoDB.Logic;
using DotNetCoreMongoDB.Classes;

namespace DotNetCoreMongoDB.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Asset Asset { get; set; }
        private AssetLogic assetLogic;
        public CreateModel()
        {
            assetLogic = new AssetLogic();
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await assetLogic.InsertAsync(Asset);

            return RedirectToPage("./index");
        }
    }
}