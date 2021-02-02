using EMarket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Data
{
    public class SeedDb
    {
        private readonly DataContext.DataContext _context;

        public SeedDb(DataContext.DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Honduras",
                    Departments = new List<Department>
                    {
                        new Department
                        {
                            Name = "Francisco Morazan",
                            Cities = new List<City>
                            {
                                new City {Name = "Tegucigalpa"},
                                new City {Name = "Valle de Angeles" },
                                new City {Name = "Santa Lucía" },
                            }
                        },
                        new Department
                        {
                            Name = "Cortés",
                            Cities = new List<City>
                            {
                                new City {Name = "San Pedro Sula"},
                                new City {Name = "Puerto Cortés" },
                                new City {Name = "Villanueva" },
                            }
                        },
                        new Department
                        {
                            Name = "Yoro",
                            Cities = new List<City>
                            {
                                new City {Name = "El Progreso"},
                                new City {Name = "Olanchito" },
                                new City {Name = "Yoro" },
                            }
                        },
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
