namespace GameZone.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion
        #region Constructors
        public DeviceService(AppDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Handel Functions
        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.Devices
                           .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                           .OrderBy(d => d.Text)
                           .AsNoTracking();
        }
        #endregion 
    }
}
