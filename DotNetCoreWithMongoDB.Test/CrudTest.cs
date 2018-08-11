using System;
using System.Collections.Generic;
using Xunit;
using DotNetCoreMongoDB.Classes;
using DotNetCoreMongoDB.Logic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DotNetCoreWithMongoDB.Test
{
    public class CrudTest
    {
        private readonly AssetLogic _assetLogic;
        public CrudTest()
        {
            _assetLogic = new AssetLogic();
        }

        [Fact]
        public void GetAssetListTest()
        {
            Expression<Func<Asset, bool>> selector = a => a.Id != null;
            Task.Run(async () => {
                Assert.IsType<List<Asset>>(await _assetLogic.GetAsync(selector));
            }).Wait();
        }
        [Fact]
        public void CreateGetDeleteAssetTest()
        {
            Asset asset = new Asset { Symbol = "SYMBOL" };
            Task.Run(async () => {
                await _assetLogic.InsertAsync(asset);
            }).Wait();
            
            Expression<Func<Asset, bool>> filter = a => a.Symbol == "SYMBOL";
            Task.Run(async () => {
                asset = await _assetLogic.FindAsync(filter);
                Assert.NotNull(asset);
                Assert.IsType<Asset>(await _assetLogic.FindAsync(filter));
            }).Wait();

            Task.Run(async () => {
                await _assetLogic.DeleteAsync(asset);
                Assert.Null(await _assetLogic.FindAsync(filter));
            }).Wait();

        }
    }
}
