using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCalendar.Models;
using VaccineCalendar.Services.Dalc;

namespace VaccineCalendar.ViewModels
{
    public class SchemaDetailViewModel : BaseViewModel
    {

        public class VaccineGroupByVaccineType
        {

            public string VaccineName;
            public IEnumerable<IGrouping<string, SchemaVaccine>> VaccineTypeGroups;
        }

        public class VaccineGroupByDateVaccineType
        {

            public string DateName;
            public IEnumerable<VaccineGroupByVaccineType> VaccineNames;
        }

        
        public IEnumerable<VaccineGroupByVaccineType> GroupByVaccineNameType { get; private set; }

        public IEnumerable<VaccineGroupByDateVaccineType> GroupByDateVaccineNameType { get; private set; }

        
        //private List<SchemaGroup> _groupByVaccine;
        //private List<SchemaGroup> _groupByDate;
        //public List<SchemaGroup> GroupByVaccine
        //{
        //    get
        //    {
        //        return _groupByVaccine;
        //    }
        //}
        //public List<SchemaGroup> GroupByDate
        //{
        //    get
        //    {
        //        return _groupByDate;
        //    }
        //}


        public string SchemaName
        {
            get { return _schema.SchemaName; }
        }

        Schema _schema;

        public SchemaDetailViewModel(Schema schema)
        {

            _schema = schema;
            //_groupByDate = new List<SchemaGroup>();
            //_groupByVaccine = new List<SchemaGroup>();
        }

        public async Task BuildGroups()
        {
            try
            {
                //BuildGroupByVaccine();
                //BuildGroupByDate();
                await Task.Factory.StartNew(() => 
                    BuildGroupsByVaccineName()
                )
                ;
                await Task.Factory.StartNew(() => 
                    BuildGroupsByVaccineDates()
                 )
                 ;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }


        private void BuildGroupsByVaccineName()
        {

            IEnumerable<IGrouping<string, SchemaVaccine>> t;
            //IEnumerable<IGrouping<string, IEnumerable<IGrouping<string, SchemaVaccine>>>> a;
            GroupByVaccineNameType = _schema.SchemaVaccines.GroupBy(x => x.VaccineName)
                                                            .Select(x => new VaccineGroupByVaccineType
                                                            {       VaccineName = x.Key,
                                                                    VaccineTypeGroups = x.ToList().GroupBy(y => y.VaccineTypeGroup)
                                                            });
           
                                }



        private void BuildGroupsByVaccineDates()
        {
            GroupByDateVaccineNameType = _schema.SchemaVaccines.GroupBy(w => w.DateName)
                                                                .Select(w=> new VaccineGroupByDateVaccineType
                                                                {
                                                                    DateName = w.Key,
                                                                    VaccineNames = w.ToList().GroupBy( o => o.VaccineName)
                                                                                                .Select(x => new VaccineGroupByVaccineType
                                                                                                {
                                                                                                    VaccineName = x.Key,
                                                                                                    VaccineTypeGroups = x.ToList().GroupBy(y => y.VaccineTypeGroup)
                                                                                                })

                                                                });

        }


        //private void BuildGroupByVaccine()
        //{
        //    try
        //    {
        //        foreach (var schemaVaccine in _schema.SchemaVaccines)
        //        {
        //            var vaccineList = GroupByVaccine.FirstOrDefault(s => s.Heading == schemaVaccine.VaccineName);
        //            if (vaccineList == null)
        //            {
        //                vaccineList = new SchemaGroup()
        //                {
        //                    Heading = schemaVaccine.VaccineName
        //                };
        //                GroupByVaccine.Add(vaccineList);
        //            }
        //            vaccineList.vaccines.Add(schemaVaccine);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        throw;
        //    }
             
        //}


        //private void BuildGroupByDate()
        //{
        //    try
        //    {
        //        foreach (var schemaVaccine in _schema.SchemaVaccines)
        //        {
        //            var vaccineList = GroupByDate.FirstOrDefault(s => s.Heading == schemaVaccine.DateName);
        //            if (vaccineList == null)
        //            {
        //                vaccineList = new SchemaGroup()
        //                {
        //                    Heading = schemaVaccine.DateName
        //                };
        //                GroupByDate.Add(vaccineList);
        //            }
        //            vaccineList.vaccines.Add(schemaVaccine);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        throw;
        //    }

        //}

    }



    //public class SchemaGroup: List<SchemaVaccine>
    //{
    //    public string Heading { get; set; }
    //    public List<SchemaVaccine> vaccines => this;

    //}
}
