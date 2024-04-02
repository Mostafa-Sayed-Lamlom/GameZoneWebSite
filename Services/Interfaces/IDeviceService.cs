namespace GameZone.Services.Interfaces
{
    public interface IDeviceService
    {
        IEnumerable<SelectListItem> GetDevices();
    }
}
