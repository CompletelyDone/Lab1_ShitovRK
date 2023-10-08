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
        [TestCase("First", "password", "password")]
        public void TestLoginIsBusy(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Login is busy");

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
        [TestCase("+7-999--52-5565", "password", "password")]
        public void TestLoginAsPhoneNumber(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Phone number isn't correct\n");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "password", "password")]
        public void TestEngLettersInPassword(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("No eng in password");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "password", "password")]
        public void TestNumbersInPassword(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("No numbers in password");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "password", "password")]
        public void TestUpperCaseInPassword(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("No uppercase in password");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "PASSWORD", "PASSWORD")]
        public void TestLowerCaseInPassword(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("No lowercase in password");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "PASSWORD", "PASSWORD")]
        public void TestSpecSymbolInPassword(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("No special symbols in password");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "PASSWORD", "PASSWORD1")]
        public void TestPasswordMatched(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("Passwords not matched");

            //��������, assert
            Console.WriteLine(isValidated.Item2);
            Assert.Multiple(
                () =>
                {
                    Assert.IsFalse(isValidated.Item1);
                    Assert.IsTrue(contains);
                });
        }
        [TestCase("�������", "PASSWORD", "PASSWORD1")]
        public void TestDatabaseConnect(string _login, string _password, string _verifyPassword)
        {
            //���������, arrange
            var login = _login;
            var password = _password;
            var verifyPassword = _verifyPassword;
            //��������, act
            var isValidated = Validation.Validate(login, password, verifyPassword);
            var contains = isValidated.Item2.Contains("������ ����������� � ��:");

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