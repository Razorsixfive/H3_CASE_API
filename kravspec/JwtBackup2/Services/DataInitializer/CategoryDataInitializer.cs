using Data.Repositories;
using Entities;
using System.Linq;

namespace Services.DataInitializer
{
    public class CategoryDataInitializer : IDataInitializer
    {
        private readonly IRepository<Category> repository;

        public CategoryDataInitializer(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public void InitializeData()
        {
            if (!repository.TableNoTracking.Any(p => p.Name == "Initial Category 1"))
            {
                repository.Add(new Category
                {
                    Name = "Initial Category 1"
                });
            }
            if (!repository.TableNoTracking.Any(p => p.Name == "Initial Category 2"))
            {
                repository.Add(new Category
                {
                    Name = "Initial Category 2"
                });
            }
            if (!repository.TableNoTracking.Any(p => p.Name == "Initial Category 3"))
            {
                repository.Add(new Category
                {
                    Name = "Initial Category 3"
                });
            }
        }
    }
}
