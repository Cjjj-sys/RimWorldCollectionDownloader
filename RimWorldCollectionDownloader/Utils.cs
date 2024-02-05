using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static RimWorldCollectionDownloader.URLs;

namespace RimWorldCollectionDownloader
{
    internal class Utils
    {
        public static async Task<Collectiondetail> GetWorkShopCollectionAsync(string id)
        {
            var args = new Dictionary<string, string>();
            args.Add("collectioncount", "1");
            args.Add("publishedfileids[0]", id);
            var res = await HttpHelper.PostAsync(GET_COLLECTION_DETAILS, args);
            if (res != null && res.IsSuccessStatusCode)
            {
                var resStr = await res.Content.ReadAsStringAsync();
                var resRoot = JsonSerializer.Deserialize<WorkShopCollectionRootobject>(resStr);
                return resRoot.response.collectiondetails[0];
            }
            else
            {
                return null;
            }
        }

        public static async Task<Publishedfiledetail[]> GetWorkShopItemsAsync(string[] ids)
        {
            var args = new Dictionary<string, string>();
            args.Add("itemcount", ids.Length.ToString());
            int i = 0;
            foreach (var id in ids)
            {
                args.Add($"publishedfileids[{i}]", id);
                i++;
            }
            var res = await HttpHelper.PostAsync(GET_PUBLISHEDFILE_DETAILS, args);
            if (res != null && res.IsSuccessStatusCode)
            {
                var resStr = await res.Content.ReadAsStringAsync();
                var resRoot = JsonSerializer.Deserialize<WorkshopItemRootobject>(resStr);
                return resRoot.response.publishedfiledetails;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Publishedfiledetail[]> GetWorkShopItemsAsync(Collectiondetail collectiondetail)
        {
            List<string> ids = new List<string>();
            ids.Clear();
            collectiondetail.children.ToList().ForEach(item => { ids.Add(item.publishedfileid); });
            return await GetWorkShopItemsAsync(ids.ToArray());
        }
    }
}
