using ExamMaker.Core.Interfaces.Repositories;
using ExamMaker.Core.Interfaces.Services;
using ExamMaker.Core.Models;
using ExamMaker.DependencyInjection;
using Microsoft.Practices.Unity;
using System;

namespace ExamMaker.ConsoleApp {
    class Program {
        static void Main(string[] args) {

            UnityContainer container = new UnityContainer();
            DependencyResolver.Resolve(container);

            using (var service = container.Resolve<IAppraiserService>())
            {
                try
                {
                    Appraiser appraiser = new Appraiser("John Doe", "00448775618");
                    
                    service.Create(appraiser);

                    Appraiser appr = service.GetByCpf(appraiser.Cpf);
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
