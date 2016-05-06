using System;
using ExamMaker.Core.Interfaces.Repositories;
using ExamMaker.Core.Models;
using ExamMaker.Data.Context;
using System.Linq;
using System.Collections.Generic;

namespace ExamMaker.Data.Repository {
    public class AppraiserRepository : IAppraiserRepository {

        AppDataContext context;

        public AppraiserRepository(AppDataContext context) {
            this.context = context;
        }

        public void Create(Appraiser appraiser) {
            context.Appraisers.Add(appraiser);
            context.SaveChanges();
        }

        public void Delete(Appraiser appraiser) {
            context.Appraisers.Remove(appraiser);
            context.SaveChanges();
        }

        public Appraiser Get(string cpf) {
            return context.Appraisers.Where(appr => appr.Cpf == cpf).FirstOrDefault();
        }

        public Appraiser Get(Guid Id) {
            return context.Appraisers.Where(appr => appr.AppraiserId == Id).FirstOrDefault();
        }

        public void Update(Appraiser appraiser) {
            context.Entry(appraiser).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }

        public IEnumerable<Appraiser> GetAll(int limit, int offset) {
            return context.Appraisers.OrderBy(a => a.Name).Skip(offset).Take(limit).ToList();
        }
    }
}
