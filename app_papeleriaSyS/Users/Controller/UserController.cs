using app_papeleriaSyS.Users.Model;
using app_papeleriaSyS.Users.Repository;
using System;

namespace app_papeleriaSyS.Users.Controller
{
    internal class UserController
    {
        #region attribute
        private RepositoryPerson repositoryPerson;
        private RepositoryUser repositoryUser;
        #endregion

        public  UserController()
        {
            this.repositoryPerson = new RepositoryPerson();
            this.repositoryUser = new RepositoryUser();
        }
        public bool createUser(string username, string pass, string typeUser, int id, string name, string surname, int phone, string email, DateTime birthdate)
        {
            User user= new User();
            user.Username=username;
            user.Password=pass; 
            user.Surname=surname;
            user.Phone=phone;
            user.Email = email;
            user.Birthdate = birthdate;
            user.Id=id;
            user.State = true;
            repositoryPerson.createPerson(user);
            repositoryUser.createUser(user);



            return true;
        }

        


    }
}
