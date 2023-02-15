using app_papeleriaSyS;
using app_papeleriaSyS.Users.Model;
using app_papeleriaSyS.Utillity;

namespace UserTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestCreateUser ()
        {
            var userController = new app_papeleriaSyS.Users.Controller.UserController();
            string pass = Encryption.encryptKey("admin123");
            User user = new User();
            user.Username = "andresp";
            user.Password = pass;
            user.TypeUser = "Admin";
            user.Id = 3;
            user.Surname = "Perez";
            user.Name = "andres";
            user.Email = "andres@gmail.com";
            user.Phone = 01233;
            user.Birthdate = DateTime.Now;
            bool result = userController.createUser(user);
            Assert.IsTrue(result);

        }
    }
}