﻿using PostalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DataBase.Repositorys.Interfase
{
    public interface IMemberRepository
    {
        public Task AddAndSave(СompanyMember сompanyMember);

        public Task<IEnumerable<СompanyMember>> GetAllMembers();

        public Task<СompanyMember> GetMember(int id);

        public Task UpdataListWriting(int id, IEnumerable<Writing> ListWriting);
    }
}
