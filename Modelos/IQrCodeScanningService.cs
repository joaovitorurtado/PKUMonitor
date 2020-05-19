using System.Threading.Tasks;

namespace ScanCodeForms.Services
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}