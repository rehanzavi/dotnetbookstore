using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepository categoryRepository;
        public CategoryController()
        {
            categoryRepository = new CategorySqlImpl();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = categoryRepository.GetCategories();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var res = categoryRepository.AddCategory(category);
            return Ok(res);
        }

        [HttpPost]
        public IHttpActionResult Edit(int catId,Category category)
        {
            var res = categoryRepository.EditCategory(catId, category);
            if (res)
                return Ok("Edit successful");
            else
                return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            bool res = categoryRepository.DeleteCategory(id);
            if (res)
                return Ok("Category deleted");
            else
                return BadRequest();
        }
    }
}
