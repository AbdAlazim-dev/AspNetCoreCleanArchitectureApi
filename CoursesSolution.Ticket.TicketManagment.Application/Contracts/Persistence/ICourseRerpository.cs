﻿using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;

internal interface ICourseRerpository : IAsyncRerository<Course>
{
}
