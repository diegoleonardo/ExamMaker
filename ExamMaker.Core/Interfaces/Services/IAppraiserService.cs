using ExamMaker.Core.Models;
using System;
using System.Collections.Generic;

namespace ExamMaker.Core.Interfaces.Services {
    public interface IAppraiserService : IDisposable {
        void Create(Appraiser appraiser);
        Appraiser GetById(Guid id);
        Appraiser GetByCpf(string cpf);
        IEnumerable<Appraiser> GetAll(int limit, int offset);
        void Delete(Appraiser appraiser);
        void Update(Appraiser appraiser);
    }
}
