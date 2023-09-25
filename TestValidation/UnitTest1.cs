using laba;

namespace TestValidation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Алёша", "password", "password")]
        [TestCase("Petushara228", "password", "password")]
        [TestCase("Vasyaloh", "password", "password")]
        public void Test(string _login, string _password, string _verifyPassword)
        {
            //Настройка, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //Действие, act
            var isValidated = Validation.Validate(login, password, verifyPassword);

            //Проверка, assert
            Console.WriteLine(isValidated.Item2);
            Assert.IsFalse(isValidated.Item1);
        }
    }
}