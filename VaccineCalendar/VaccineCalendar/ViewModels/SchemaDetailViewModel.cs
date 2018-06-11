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
    public class SchemaDetailViewModel: BaseViewModel
    {
        private List<SchemaGroup> _groupByVaccine;
        private List<SchemaGroup> _groupByDate;



        public List<SchemaGroup> GroupByVaccine
        {
            get
            {
                return _groupByVaccine;
            }

        }

        public List<SchemaGroup> GroupByDate
        {
            get
            {
                return _groupByDate;
            }
        }


        Schema _schema;

        public SchemaDetailViewModel(Schema schema )
        {

            _schema = schema;
            _groupByDate = new List<SchemaGroup>();
            _groupByVaccine = new List<SchemaGroup>();
        }

        public async Task BuildGroups()
        {
            //await Task.Factory.StartNew(() => BuildGroupByVaccine());
            //await Task.Factory.StartNew(() => BuildGroupByDate());
            //return await task1.;
            try
            {
                BuildGroupByVaccine();
                BuildGroupByDate();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private void BuildGroupByVaccine()
        {
            try
            {
                foreach (var schemaVaccine in _schema.SchemaVaccines)
                {
                    var vaccineList = GroupByVaccine.FirstOrDefault(s => s.Heading == schemaVaccine.VaccineName);
                    if (vaccineList == null)
                    {
                        vaccineList = new SchemaGroup()
                        {
                            Heading = schemaVaccine.VaccineName
                        };
                        GroupByVaccine.Add(vaccineList);
                    }
                    vaccineList.vaccines.Add(schemaVaccine);

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
             
        }


        private void BuildGroupByDate()
        {
            try
            {
                foreach (var schemaVaccine in _schema.SchemaVaccines)
                {
                    var vaccineList = GroupByDate.FirstOrDefault(s => s.Heading == schemaVaccine.DateName);
                    if (vaccineList == null)
                    {
                        vaccineList = new SchemaGroup()
                        {
                            Heading = schemaVaccine.DateName
                        };
                        GroupByDate.Add(vaccineList);
                    }
                    vaccineList.vaccines.Add(schemaVaccine);

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

        }

    }



    public class SchemaGroup: List<SchemaVaccine>
    {
        public string Heading { get; set; }
        public List<SchemaVaccine> vaccines => this;

    }
}
