namespace GameZone.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion
        #region Constructors
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Handel Functions
        public IEnumerable<SelectListItem> GetCategoreis()
        {
            return _context.Categories
                             .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                             .OrderBy(c => c.Text)
                             .AsNoTracking();
        }
        #endregion
    }
}
