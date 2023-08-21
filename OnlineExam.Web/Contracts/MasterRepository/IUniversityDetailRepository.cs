﻿using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.MasterRepository
{
    public interface IUniversityDetailRepository : IGenericRepository<UniversityDetail>
    {
        Task Update(UniversityDetail entity);
    }
}
