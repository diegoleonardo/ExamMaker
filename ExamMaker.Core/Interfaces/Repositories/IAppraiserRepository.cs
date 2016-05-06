using ExamMaker.Core.Models;
using System;

namespace ExamMaker.Core.Interfaces.Repositories {
    public interface IAppraiserRepository : IDisposable{
        void Create(Appraiser appraiser);
        Appraiser Get(Guid Id);
        Appraiser Get(string cpf);
        void Delete(Appraiser appraiser);
        void Update(Appraiser appraiser);
    }
}
