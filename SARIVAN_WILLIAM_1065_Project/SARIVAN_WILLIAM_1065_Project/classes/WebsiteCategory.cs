using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project.classes
{
    [Serializable]
   public class WebsiteCategory
    {

        public string category { get; set; }
        public string usedBrowser { get; set; }

        public WebsiteCategory(string category,string usedBrowser)
        {
            this.category = category;
            this.usedBrowser = usedBrowser;
        }

        public WebsiteCategory()
        {

        }


    }
}
