using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARIVAN_WILLIAM_1065_Project.classes
{[Serializable]
    public class Visit:WebsiteCategory
    {

        public string visitedWebsite { get; set; }

        public Visit(string visitedWebsite,string usedBrowser, string category):base(category,usedBrowser)
        {
            this.visitedWebsite = visitedWebsite;
        }
        public Visit()
        {

        }
    }
}
