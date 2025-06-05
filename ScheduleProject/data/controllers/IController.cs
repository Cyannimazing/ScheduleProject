using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal interface IController
    {
        int Create(models.Model model);
        List<models.Model> GetAll();
    }
}
