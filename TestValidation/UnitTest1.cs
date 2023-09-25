using laba;

namespace TestValidation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Алёша", "password", "password", true)]
        [TestCase("Алёша", "password", "password", true)]
        public void TestCorrectLogin(string _login, string _password, string _verifyPassword, bool _contains)
        {
            //Настройка, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //Действие, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Login not correct");

            //Проверка, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("Вася", "password", "password", true)]
        public void TestMinimalLoginLength(string _login, string _password, string _verifyPassword, bool _contains)
        {
            //Настройка, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //Действие, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Minimal login length is 5\n");

            //Проверка, assert
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