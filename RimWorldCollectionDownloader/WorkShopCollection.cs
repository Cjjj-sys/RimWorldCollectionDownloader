using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldCollectionDownloader
{

    public class WorkShopCollectionRootobject
    {
        public WorkShopCollectionResponse response { get; set; }
    }

    public class WorkShopCollectionResponse
    {
        public int result { get; set; }
        public int resultcount { get; set; }
        public Collectiondetail[] collectiondetails { get; set; }
    }

    public class Collectiondetail
    {
        public string publishedfileid { get; set; }
        public int result { get; set; }
        public WorkShopCollectionChild[] children { get; set; }
    }

    public class WorkShopCollectionChild
    {
        public string publishedfileid { get; set; }
        public int sortorder { get; set; }
        public int filetype { get; set; }
    }

}
