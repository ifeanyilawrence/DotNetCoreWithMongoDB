using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;
using DotNetCoreMongoDB.Logic;
using DotNetCoreMongoDB.Classes;

namespace DotNetCoreMongoDB.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Asset Asset { get; set; }
        private AssetLogic assetLogic;
        public EditModel()
        {
            assetLogic = new AssetLogic();
        }
        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Expression<Func<Asset, bool>> selector = a => a.AssetId == id;
            Asset = await assetLogic.FindAsync(selector);

            if (Asset == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Asset.Symbol))
            {
                return Page();
            }
            
            Expression<Func<Asset, bool>> selector = a => a.AssetId == Asset.AssetId;
            Asset assetToModify = await assetLogic.FindAsync(selector);

            if (assetToModify == null)
            {
                return Page();
            }

            assetToModify.Symbol = Asset.Symbol;
            
            await assetLogic.UpdateAsync(assetToModify);
            
            return RedirectToPage("./Index");
        }
    }
}