
using Lumos.Services;
using NUnit.Framework;
using Xunit;

namespace Lumos.test
{
    public class PhoneNumberDetectorTests
    {

        private readonly IPhoneNumberDetector _detector;

        public PhoneNumberDetectorTests()
        {
            _detector = new PhoneNumberDetector();
        }

        [Fact]
        public void DetectPhoneNumbers_ShouldDetect10DigitNumber()
        {
            var input = "123-456-7890";
            var result = _detector.DetectPhoneNumbers(input);
            Assert.Equals("1234567890", result[0]);
        }

        [Fact]
        public void DetectPhoneNumbers_ShouldHandleMixedFormats()
        {
            var input = " ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE ZERO";
            var result = _detector.DetectPhoneNumbers(input);
            Assert.Equals("ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE ZERO", result);
        }

        [Fact]
        public void DetectPhoneNumbers_ShouldDetectHindiNumbers()
        {
            var input = "एक दो तीन चार पांच छह सात आठ नौ शून्य";
            var result = _detector.DetectPhoneNumbers(input);
            Assert.Equals("एक दो तीन चार पांच छह सात आठ नौ शून्य", result);
        }
    }
}
