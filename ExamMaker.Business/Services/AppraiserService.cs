using ExamMaker.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using ExamMaker.Core.Models;
using ExamMaker.Core.Interfaces.Repositories;
using ExamMaker.Utils.Resources;

namespace ExamMaker.Business.Services {
    public class AppraiserService : IAppraiserService {

        private IAppraiserRepository repository;

        public AppraiserService(IAppraiserRepository repository) {
            this.repository = repository;
        }

        public void Create(Appraiser appraiser) {
            appraiser.Validate();
            if (repository.Get(appraiser.Cpf) != null)
                throw new InvalidOperationException(Errors.DuplicateCpf);
            
            repository.Create(appraiser);
        }

        public void Delete(Appraiser appraiser) {
            appraiser.Validate();
            repository.Delete(appraiser);
        }

        public IEnumerable<Appraiser> GetAll(int limit, int offset) {
            return repository.GetAll(limit, offset);
        }

        public Appraiser GetByCpf(string cpf) {
            var appraiser = repository.Get(cpf);
            if (appraiser == null){
                throw new Exception(Errors.AppraiserNotFound);
            }

            return appraiser;
        }

        public Appraiser GetById(Guid id) {
            var appraiser = repository.Get(id);

            if (appraiser == null)
                throw new Exception(Errors.AppraiserNotFound);           

            return appraiser;
        }

        public void Update(Appraiser appraiser) {
            appraiser.Validate();
            repository.Update(appraiser);
        }

        public void Dispose() {
            repository.Dispose();
        }
    }
}
