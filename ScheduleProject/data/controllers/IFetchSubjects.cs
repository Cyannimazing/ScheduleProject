using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controllers
{
    internal interface IFetchSubjects
    {
        models.Model GetSubjectsById(int id);
    }
}
