using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;

namespace UnitedReporting.Business
{
    public interface ICategoryManager
    {
        IList<Category> GetNavigation();
    }

    public class CategoryManager : ICategoryManager
    {
        private readonly IGenericDataRepository<Category> _categoryRepository;

        public CategoryManager()
        {
            _categoryRepository = new GenericDataRepository<Category>();
        }

        public CategoryManager(IGenericDataRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IList<Category> GetNavigation()
        {
            var categories = _categoryRepository.GetAll(c => c.PageContents).OrderBy(c => c.Sequence);
            
            return categories.ToList();
        }

        public void UpdateOrder(int id, int fromPosition, int toPosition, string direction)
        {
            IList<Category> movedCategories;
            if (direction == "back")
            {
                movedCategories = _categoryRepository.GetList(c => (toPosition <= c.Sequence && c.Sequence <= fromPosition));

                foreach (var category in movedCategories)
                {
                    category.Sequence++;
                }
            }
            else
            {
                movedCategories = _categoryRepository.GetList(c => (fromPosition <= c.Sequence && c.Sequence <= toPosition));
                            
                foreach (var category in movedCategories)
                {
                    category.Sequence--;
                }
            }
            movedCategories.Single(c => c.Id == id).Sequence = toPosition;
            
            _categoryRepository.Update(movedCategories.ToArray());
        }

    }
}
