using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Web_Sharp_T_2.DTO;
using Web_Sharp_T_2.Interfaces;
using Web_Sharp_T_2.DB;

namespace Web_Sharp_T_2.Repositories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        public CategoryManager(IMapper mapper, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _mapper = mapper;
            _cache = memoryCache;
            _configuration = configuration;
        }
        public int AddCategory(CategoryDTO categoryDTO)
        {
            using (var db = new ContextDB(_configuration.GetValue<string>("PathToDB")))
            {
                var cat = db.Categories.ToList();
                var res = cat.FirstOrDefault(x => x.Name.ToLower() == categoryDTO.Name.ToLower());
                if (res is null)
                {
                    _cache.Remove("categories");
                    res = new Category() { Name = categoryDTO.Name, Description = categoryDTO.Description };
                    db.Categories.Add(res);
                    db.SaveChanges();
                }
                return res.Id;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var db = new ContextDB(_configuration.GetValue<string>("PathToDB")))
            {
                List<Category> cat = db.Categories.ToList();
                var obj = cat.FirstOrDefault(x => x.Id == id);
                if (obj is null)
                    return false;

                db.Categories.Remove(obj);
                db.SaveChanges();
                _cache.Remove("categories");
                return true;
            }
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            if (_cache.TryGetValue("categories", out List<CategoryDTO> categoriesCache))
                return categoriesCache;

            List<Category> cats = new List<Category>();
            using (var db = new ContextDB(_configuration.GetValue<string>("PathToDB")))
            {
                cats = db.Categories.ToList();
            }
            var res = cats.Select(x => _mapper.Map<CategoryDTO>(x)).ToList();

            _cache.Set("categories", res, TimeSpan.FromMinutes(30));

            return res;
        }
    }
}
