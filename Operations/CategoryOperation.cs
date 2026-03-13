using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Operations
{
     class CategoryOperation
    {
        private static AppDbContext context = new AppDbContext();
        public static Category SearchCategory(int categoryId)
        {
           var  existingCategory=context.Categorys.FirstOrDefault(c => c.Id == categoryId);
            if (existingCategory == null)
            {
                throw new ArgumentException($"Category does not exist.");
            }
            return existingCategory;
        }
        public static void AddCategory(Category category)
        {
            context.Categorys.Add(category);
            context.SaveChanges();
        }
        public static void UpdateCategory(Category category,int categoryId)
        {
          var existingCategory=  SearchCategory(categoryId);
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;
            context.SaveChanges();
        }
         public static void DeletCategory(int categoryId)
        {
          var existingCategory=  SearchCategory(categoryId);
            context.Remove(existingCategory);
            context.SaveChanges();
        }
        public static List<Category> ReadAllCategorys()
        {
            return context.Categorys.ToList();
        }
    }
}
