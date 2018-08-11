using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using DotNetCoreMongoDB.Logic;
using DotNetCoreMongoDB.Classes;

namespace DotNetCoreMongoDB.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Asset> AssetList;
        private AssetLogic assetLogic;

        public IndexModel()
        {
            assetLogic = new AssetLogic();
        }
        public async Task OnGet()
        {
            Expression<Func<Asset, bool>> selector = a => a.Id != null;
            AssetList = await assetLogic.GetAsync(selector);
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Expression<Func<Asset, bool>> selector = a => a.AssetId == id;
            Asset asset = await assetLogic.FindAsync(selector);

            if (asset != null) await assetLogic.DeleteAsync(asset);

            return RedirectToAction("./Index");
        }
    }
}
