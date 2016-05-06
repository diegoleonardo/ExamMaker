using ExamMaker.Core.Interfaces.Repositories;
using ExamMaker.Core.Models;
using ExamMaker.DependencyInjection;
using Microsoft.Practices.Unity;
using System;

namespace ExamMaker.ConsoleApp {
    class Program {
        static void Main(string[] args) {

            UnityContainer container = new UnityContainer();
            DependencyResolver.Resolve(container);

            using (var repository = container.Resolve<IAppraiserRepository>())
            {
                try
                {
                    Appraiser appraiser = new Appraiser("John Doe", "00448775608");

                    appraiser.Validate();
                    repository.Create(appraiser);

                    Appraiser appr = repository.Get(appraiser.Cpf);
                    if (appr.Validate())
                    {
                        Console.WriteLine("Appraiser Name: " + appr.Name);
                        Console.WriteLine("Appraiser CPF: " + appr.Cpf);
                        Console.WriteLine("Appraiser Id: " + appr.AppraiserId);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
            }
        }
    }
}
