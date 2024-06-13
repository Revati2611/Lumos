using Lumos.Models;

namespace Lumos.Services
{
    public interface IPhoneNumberDetector
    {
       string DetectPhoneNumbers(string input);
    }
}
