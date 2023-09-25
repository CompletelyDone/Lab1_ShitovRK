using laba;

namespace TestValidation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("����", "password", "password")]
        public void TestCorrectLogin(string _login, string _password, string _verifyPassword)
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
        [TestCase("����", "password", "password")]
        public void TestMinimalLoginLength(string _login, string _password, string _verifyPassword)
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
        [TestCase("pepe@pepe.pepe@", "password", "password")]
        public void TestLoginAsEmail(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Email isn't correct\n");

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