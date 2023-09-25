using laba;

namespace TestValidation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("����", "password", "password", true)]
        [TestCase("����", "password", "password", true)]
        public void TestCorrectLogin(string _login, string _password, string _verifyPassword, bool _contains)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Login not correct");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("����", "password", "password", true)]
        public void TestMinimalLoginLength(string _login, string _password, string _verifyPassword, bool _contains)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Minimal login length is 5\n");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
    }
}