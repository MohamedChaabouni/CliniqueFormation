using Bogus;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CliniqueFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly DbContextOptions options;

        public CommonController([NotNull] DbContextOptions options)
        {
            this.options = options;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //List<dynamic> List = new List<dynamic>();
            /*
                    Stream 
                        Stream s = new FileStream("File.txt", FileOpenMode.Create | FileOpenMode.Open);
                        s.Open();

                        ...
        
                        s.Flush() {
                            Interlocked.Invoke(() => {});
                            GC.Collect();
                            GC.SupressFinilize();
                            GC.Collect();
                        }
                        s.Close();

                        .NET 3 
                            Stream (canal: I/O) : IDisposablable
                                ~ClassX 

                        .NET ?
                            using -> IDisposable
                            { state machine --> Open();
                                ....
                              state machine --> Flush(); Close(); 
                            }

                        .NET - Compile time (froid) -- state machine (Build new State machine) -- Hexadecimal code -- runtime 
                 */
            // Increment int thread safe : int counter = 0; Interlocked.Increment(ref counter);
            var faker = new Faker("en");
            Parallel.Invoke(
            () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {
                    for (int i = 0; i < 100_000; i++)
                    {
                        Db.Patients.Add(new Domains.Patient
                        {
                            Age = faker.Random.Number(0, 100),
                            Addresse = faker.Address.StreetAddress(true),
                            Code = faker.Commerce.Product(),
                            DateNaissance = faker.Date.Between(new DateTime(1970, 1, 1), DateTime.Now),
                            Sexe = Domains.Enums.Sexe.Male
                        });
                    }
                    Db.SaveChanges();
                    //List.AddRange(Db.Patients.ToList());
                }
            }, 
            () => {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {
                    for (int i = 0; i < 100_000; i++)
                    {
                        Db.Dossiers.Add(new Domains.Dossier
                        {
                            Nom = faker.Person.FirstName,
                            NumDossier = faker.Commerce.ProductName(),
                        });
                    }
                    Db.SaveChanges();
                    //List.AddRange(Db.Dossiers.ToList());
                }
            }, 
            //() =>
            //{
            //    using (ApplicationDbContext Db = new ApplicationDbContext(options))
            //    {
            //        for (int i = 0; i < 1_000_000; i++)
            //        {
            //            Db.RendezVous.Add(new Domains.RendezVous
            //            {
            //                Code = faker.Commerce.Locale,
            //                Date = faker.Date.Past(30)
            //            });
            //        }
            //        Db.SaveChanges();
            //    }
            //}, Dossier
            () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {
                    for (int i = 0; i < 100_000; i++)
                    {
                        Db.Medecins.Add(new Domains.Medecin
                        {
                            Nom = faker.Person.FirstName,
                            Addresse = faker.Address.Locale,
                            Code = faker.Address.Longitude(-180, 180).ToString(),
                            DateNaissance = faker.Date.Past(40),
                            NumAssMaladie = faker.Company.CompanyName(),
                            Prenom = faker.Person.LastName,
                            NumLicence = faker.Lorem.Locale,
                            Telephone = faker.Phone.PhoneNumber()
                        });
                    }
                    Db.SaveChanges();
                    //List.AddRange(Db.Medecins.ToList());
                }
            }, () =>
            {
                //using (ApplicationDbContext Db = new ApplicationDbContext(options))
                //{
                //    for (int i = 0; i < 1_000_000; i++)
                //    {
                //        Db.Notes.Add(new Domains.Note
                //        {
                //            Content = faker.Lorem.Paragraph(6)
                //        });
                //    }
                //    Db.SaveChanges();
                //}
            }, () =>
            {
                using (ApplicationDbContext Db = new ApplicationDbContext(options))
                {
                    for (int i = 0; i < 100_000; i++)
                    {
                        Db.SecretaireInfirmieres.Add(new Domains.SecretaireInfirmiere
                        {
                            Nom = faker.Person.FirstName,
                            Prenom = faker.Person.LastName,
                            Age = faker.Random.Number(0, 100),
                            Addresse = faker.Address.StreetAddress(false),
                            DateNaissance = faker.Date.Past(40),
                            Telephone = faker.Phone.PhoneNumber(),
                            Code = faker.Finance.Iban(),
                            NumAssMaladie = faker.Finance.Iban()
                        });
                    }
                    Db.SaveChanges();
                    //List.AddRange(Db.SecretaireInfirmieres.ToList());
                }
            });

            return Ok();
        }
    }
}
