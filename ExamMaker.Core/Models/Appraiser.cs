using ExamMaker.Utils.Resources;
using ExamMaker.Utils.Validations;
using System;

namespace ExamMaker.Core.Models {
    public class Appraiser {
        public Guid AppraiserId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        //Entity
        protected Appraiser() {}

        public Appraiser(string name, string cpf) {            
            Name = name;
            Cpf = cpf;
        }

        public bool Validate() {
            AssertionConcern.AssertArgumentNotEmpty(Name, Errors.RequiredName);
            AssertionConcern.AssertArgumentNotEmpty(Cpf, Errors.RequiredCpf);
            AssertionConcern.AssertArgumentLength(Cpf, 11, 11, Errors.InvalidCpfLength);

            return true;
        }
    }
}
