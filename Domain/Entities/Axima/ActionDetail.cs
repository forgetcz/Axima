using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Axima
{
    /// <summary>
    /// Specific definition for action detail table items
    /// </summary>
    public class ActionDetail : BaseEntity<string>
    {
        public string ActionName { get; set; }
        public string ActionPlace { get; set; }
        public DateTime ActionDate { get; set; }

        public ActionDetail(string id, string actionName, string actionPlace, DateTime actionDate) : base(id)
        {
            ActionName = actionName;
            ActionPlace = actionPlace;
            ActionDate = actionDate;
        }
    }
}
