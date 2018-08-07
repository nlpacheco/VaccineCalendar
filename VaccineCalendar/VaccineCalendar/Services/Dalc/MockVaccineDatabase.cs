using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCalendar.Services.Dalc
{
    public class MockVaccineDatabase
    {

        public static void MockVaccineDataStore()
        {
            MockVaccines();
            MockFamilyPeople();
            
        }


        private static void MockFamilyPeople()
        {
            User user = new User()
            {
                Email = "norberto.luciano.pacheco@gmail.com",
                Name = "Norberto",
                FamilyId = Guid.NewGuid()
            };

            CurrentDataStore.CurrentDALC.GetUserDBProvider.SaveUser(user);

            List<FamilyPerson> PeopleList = new List<FamilyPerson>
            {
                new FamilyPerson()
                {
                    FamilyId = user.FamilyId,
                    Name = "Joao",
                    Gender = "M",
                    PersonId = Guid.NewGuid(),
                    BirthDate = new DateTime(2018, 05, 01)
                },

                new FamilyPerson()
                {
                    FamilyId = user.FamilyId,
                    Name = "Maria",
                    Gender = "F",
                    PersonId = Guid.NewGuid(),
                    BirthDate = new DateTime(2017, 08, 12)
                },


                new FamilyPerson()
                {
                    FamilyId = user.FamilyId,
                    Name = "Fernanda",
                    Gender = "F",
                    PersonId = Guid.NewGuid(),
                    BirthDate = new DateTime(2016, 02, 27)
                }
            };

            CurrentDataStore.CurrentDALC.GetFamilyPersonDBProvider.SaveAllFamily(PeopleList);
        }



        private static void MockVaccines()
        {

            var mockVaccine = new List<Vaccine>();
            Vaccine vaccine;

            string descricao;

            descricao = VaccineCalendar.Properties.Resources.ResourceManager.GetString("BCG");

            vaccine = new Vaccine { VaccineId = Guid.NewGuid(), Name = "BGC", Description = descricao };
            vaccine.VaccineTypes = new List<VaccineType> { new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "BGC", Name = "BCG" } };
            mockVaccine.Add(vaccine);

            descricao = VaccineCalendar.Properties.Resources.ResourceManager.GetString("HEPATITE_B");
            vaccine = new Vaccine { VaccineId = Guid.NewGuid(), Name = "HEPATITE B", Description = descricao };
            vaccine.VaccineTypes = new List<VaccineType> { new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "Hepatite B dose isolada.", Name = "HB" },
                                                           new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "Hepatite B dose combinada.", Name = "HB Combinada" } };
            mockVaccine.Add(vaccine);

            descricao = VaccineCalendar.Properties.Resources.ResourceManager.GetString("Tríplice_Bacteriana");
            vaccine = new Vaccine { VaccineId = Guid.NewGuid(), Name = "Tríplice Bacteriana", Description = descricao };
            vaccine.VaccineTypes = new List<VaccineType> { new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "DTPw feita com bactérias inteiras inativadas.", Name = "DTPw" },
                                                            new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "DTPa feita com proteínas associadas a doença.", Name = "DTPa" } ,
                                                            new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "dTpa é versão para adultos.", Name = "dTpa" } };
            mockVaccine.Add(vaccine);


            descricao = VaccineCalendar.Properties.Resources.ResourceManager.GetString("Hib");
            vaccine = new Vaccine { VaccineId = Guid.NewGuid(), Name = "Hib", Description = descricao };
            vaccine.VaccineTypes = new List<VaccineType> { new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "Hib", Name = "Hib" } };
            mockVaccine.Add(vaccine);


            descricao = VaccineCalendar.Properties.Resources.ResourceManager.GetString("Poliomielite");
            vaccine = new Vaccine { VaccineId = Guid.NewGuid(), Name = "Poliomielite", Description = descricao };
            vaccine.VaccineTypes = new List<VaccineType> { new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "VIP Vacina Inativada Poliomielite com partículas dos vírus da pólio tipos 1, 2 e 3", Name = "VIP" },
                                                           new VaccineType { VaccineTypeId = Guid.NewGuid(), VaccineId = vaccine.VaccineId, Description = "VOP Vacina Oral Atenuada composta pelos vírus da pólio tipos 1 e 3, vivos, mas 'enfraquecidos'", Name = "VOP" } };
            mockVaccine.Add(vaccine);


            CurrentDataStore.CurrentDALC.GetVaccineDBProvider.SaveAllVaccines(mockVaccine);

            MockSchmas(mockVaccine);
        }



        private static void MockSchmas(List<Vaccine> vaccines)
        {
            List<SchemaVaccine> vaccineSchemaHealthDept = new List<SchemaVaccine>();
            List<SchemaVaccine> vaccineSchemaPrivateClinic = new List<SchemaVaccine>();

            Schema schemaHealthDept = new Schema()
            {
                SchemaId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                OwnerId = null,
                SchemaName = "Ministerio da Saúde",
                Timestamp = DateTime.Today,
                SchemaVaccines = vaccineSchemaHealthDept
            };

            Schema schemaPrivateClinic = new Schema()
            {
                SchemaId = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1),
                OwnerId = null,
                SchemaName = "Clinicas Privadas",
                Timestamp = DateTime.Today,
                SchemaVaccines = vaccineSchemaPrivateClinic
            };


            MockBCG(vaccines, schemaHealthDept, schemaPrivateClinic, vaccineSchemaHealthDept, vaccineSchemaPrivateClinic);
            MockHepatiteB(vaccines, schemaHealthDept, schemaPrivateClinic, vaccineSchemaHealthDept, vaccineSchemaPrivateClinic);
            MockTripliceBact(vaccines, schemaHealthDept, schemaPrivateClinic, vaccineSchemaHealthDept, vaccineSchemaPrivateClinic);
            MockHib(vaccines, schemaHealthDept, schemaPrivateClinic, vaccineSchemaHealthDept, vaccineSchemaPrivateClinic);
            MockPolio(vaccines, schemaHealthDept, schemaPrivateClinic, vaccineSchemaHealthDept, vaccineSchemaPrivateClinic);

            CurrentDataStore.CurrentDALC.GetSchemaDBProvider.SaveSchema(schemaHealthDept);
            CurrentDataStore.CurrentDALC.GetSchemaDBProvider.SaveSchema(schemaPrivateClinic);

        }


        private static void MockBCG(List<Vaccine> vaccines, Schema schemaHealthDept, Schema schemaPrivateClinic, List<SchemaVaccine> vaccineSchemaHealthDept, List<SchemaVaccine> vaccineSchemaPrivateClinic)
        {
            Vaccine vaccine = vaccines.FirstOrDefault(v => v.Name == "BCG");
            if (vaccine != null)
            {
                VaccineType vaccineType = vaccine.VaccineTypes.First(t => t.Name == "BGC");

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = vaccineType.VaccineTypeId,
                    VaccineTypeName = vaccineType.Name,
                    DoseName = "Dose Única",
                    DateName = "Recem Nascidos",
                    DaysToStartOfPeriod = 0,
                    DaysToEndOfPeriod = 2
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = vaccineType.VaccineTypeId,
                    VaccineTypeName = vaccineType.Name,
                    DoseName = "Dose Única",
                    DateName = "Recem Nascidos",
                    DaysToStartOfPeriod = 0,
                    DaysToEndOfPeriod = 2
                });
            }
        }

        private static void MockHepatiteB(List<Vaccine> vaccines, Schema schemaHealthDept, Schema schemaPrivateClinic, List<SchemaVaccine> vaccineSchemaHealthDept, List<SchemaVaccine> vaccineSchemaPrivateClinic)
        {
            Vaccine vaccine = vaccines.FirstOrDefault(v => v.Name == "HEPATITE B");
            if (vaccine != null)
            {
                VaccineType typeHB = vaccine.VaccineTypes.First(t => t.Name == "HB");
                VaccineType typeHBcombinada = vaccine.VaccineTypes.First(t => t.Name == "HB Combinada");

                #region Public Health Deptment Alternative 1
                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "1a Dose",
                    DateName = "Recem Nascidos",
                    DaysToStartOfPeriod = 0,
                    DaysToEndOfPeriod = 2
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "2a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                #endregion


                #region Public Health Deptment Alternative 2
                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "1a Dose",
                    DateName = "Recem Nascidos",
                    DaysToStartOfPeriod = 0,
                    DaysToEndOfPeriod = 2
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "2a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "Dose Opcional",
                    Optional = true,
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                #endregion


                #region Private Clinic Alternative 1
                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "1a Dose",
                    DateName = "Recem Nascidos",
                    DaysToStartOfPeriod = 0,
                    DaysToEndOfPeriod = 2
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "2a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                #endregion


                #region Private Clinic Alternative 2
                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "1a Dose",
                    DateName = "Recem Nascidos",
                    DaysToStartOfPeriod = 0,
                    DaysToEndOfPeriod = 2
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "2a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "Dose Opcional",
                    Optional = true,
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "2",
                    VaccineTypeId = typeHB.VaccineTypeId,
                    VaccineTypeName = typeHB.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                #endregion


            }
        }

        private static void MockTripliceBact(List<Vaccine> vaccines, Schema schemaHealthDept, Schema schemaPrivateClinic, List<SchemaVaccine> vaccineSchemaHealthDept, List<SchemaVaccine> vaccineSchemaPrivateClinic)
        {
            Vaccine vaccine = vaccines.FirstOrDefault(v => v.Name == "Tríplice Bacteriana");
            if (vaccine != null)
            {
                VaccineType typeDTPw = vaccine.VaccineTypes.First(t => t.Name == "DTPw");
                VaccineType typeDTPa = vaccine.VaccineTypes.First(t => t.Name == "DTPa");
                VaccineType typedTpa = vaccine.VaccineTypes.First(t => t.Name == "dTpa");

                #region Public Health Deptment Alternative 1
                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPw.VaccineTypeId,
                    VaccineTypeName = typeDTPw.Name,
                    DoseName = "1a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPw.VaccineTypeId,
                    VaccineTypeName = typeDTPw.Name,
                    DoseName = "2a Dose",
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPw.VaccineTypeId,
                    VaccineTypeName = typeDTPw.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPw.VaccineTypeId,
                    VaccineTypeName = typeDTPw.Name,
                    DoseName = "Reforço",
                    DateName = "4 a 5 anos",
                    DaysToStartOfPeriod = 1460,
                    DaysToEndOfPeriod = 2189
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typedTpa.VaccineTypeId,
                    VaccineTypeName = typedTpa.Name,
                    DoseName = "Reforço",
                    DateName = "9 a 10 anos",
                    DaysToStartOfPeriod = 3285,
                    DaysToEndOfPeriod = 4014
                });

                #endregion

                #region Public Health Deptment Alternative 1
                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPa.VaccineTypeId,
                    VaccineTypeName = typedTpa.Name,
                    DoseName = "1a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPa.VaccineTypeId,
                    VaccineTypeName = typedTpa.Name,
                    DoseName = "2a Dose",
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPa.VaccineTypeId,
                    VaccineTypeName = typedTpa.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeDTPa.VaccineTypeId,
                    VaccineTypeName = typedTpa.Name,
                    DoseName = "Reforço",
                    DateName = "4 a 5 anos",
                    DaysToStartOfPeriod = 1460,
                    DaysToEndOfPeriod = 2189
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typedTpa.VaccineTypeId,
                    VaccineTypeName = typedTpa.Name,
                    DoseName = "Reforço",
                    DateName = "9 a 10 anos",
                    DaysToStartOfPeriod = 3285,
                    DaysToEndOfPeriod = 4014
                });

                #endregion

            }
        }

        private static void MockHib(List<Vaccine> vaccines, Schema schemaHealthDept, Schema schemaPrivateClinic, List<SchemaVaccine> vaccineSchemaHealthDept, List<SchemaVaccine> vaccineSchemaPrivateClinic)
        {
            Vaccine vaccine = vaccines.FirstOrDefault(v => v.Name == "Hib");
            if (vaccine != null)
            {
                VaccineType typeHib = vaccine.VaccineTypes.First(t => t.Name == "Hib");

                #region Public Health Deptment Alternative 1
                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "1a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "2a Dose",
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });


                #endregion

                #region Public Health Deptment Alternative 1
                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "1a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "2a Dose",
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeHib.VaccineTypeId,
                    VaccineTypeName = typeHib.Name,
                    DoseName = "Reforço",
                    DateName = "15 a 18 meses",
                    DaysToStartOfPeriod = 450,
                    DaysToEndOfPeriod = 539
                });

                #endregion

            }
        }

        private static void MockPolio(List<Vaccine> vaccines, Schema schemaHealthDept, Schema schemaPrivateClinic, List<SchemaVaccine> vaccineSchemaHealthDept, List<SchemaVaccine> vaccineSchemaPrivateClinic)
        {
            Vaccine vaccine = vaccines.FirstOrDefault(v => v.Name == "Poliomielite");
            if (vaccine != null)
            {
                VaccineType typeVIP = vaccine.VaccineTypes.First(t => t.Name == "VIP");
                VaccineType typeVOP = vaccine.VaccineTypes.First(t => t.Name == "VOP");
                
                #region Public Health Deptment Alternative 1
                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "1a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "2a Dose",
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVOP.VaccineTypeId,
                    VaccineTypeName = typeVOP.Name,
                    DoseName = "Reforço",
                    DateName = "15 a 18 meses",
                    DaysToStartOfPeriod = 450,
                    DaysToEndOfPeriod = 539
                });

                vaccineSchemaHealthDept.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVOP.VaccineTypeId,
                    VaccineTypeName = typeVOP.Name,
                    DoseName = "Reforço",
                    DateName = "4 a 5 anos",
                    DaysToStartOfPeriod = 1460,
                    DaysToEndOfPeriod = 2189
                });

                #endregion

                #region Public Health Deptment Alternative 1
                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "1a Dose",
                    DateName = "2 meses",
                    DaysToStartOfPeriod = 60,
                    DaysToEndOfPeriod = 89
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "2a Dose",
                    DateName = "4 meses",
                    DaysToStartOfPeriod = 120,
                    DaysToEndOfPeriod = 149
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "3a Dose",
                    DateName = "6 meses",
                    DaysToStartOfPeriod = 180,
                    DaysToEndOfPeriod = 209
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "Reforço",
                    DateName = "15 a 18 meses",
                    DaysToStartOfPeriod = 450,
                    DaysToEndOfPeriod = 539
                });

                vaccineSchemaPrivateClinic.Add(new SchemaVaccine()
                {
                    SchemaId = schemaHealthDept.SchemaId,
                    VaccineId = vaccine.VaccineId,
                    VaccineName = vaccine.Name,
                    VaccineTypeGroup = "1",
                    VaccineTypeId = typeVIP.VaccineTypeId,
                    VaccineTypeName = typeVIP.Name,
                    DoseName = "Reforço",
                    DateName = "4 a 5 anos",
                    DaysToStartOfPeriod = 1460,
                    DaysToEndOfPeriod = 2189
                });

                #endregion

            }
        }


    }
}