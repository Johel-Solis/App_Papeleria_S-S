using app_papeleriaSyS.Users.Model;
using app_papeleriaSyS.Users.Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace app_papeleriaSyS.Users.Controller
{
    public class UserController
    {
        #region attribute
        private RepositoryPerson repositoryPerson;
        private RepositoryUser repositoryUser;
        #endregion

        public UserController()
        {
            //this.repositoryPerson = new RepositoryPerson();
            //this.repositoryUser = new RepositoryUser();
        }
        public bool createUser(User user)
        {
            this.repositoryPerson = new RepositoryPerson();
            this.repositoryUser = new RepositoryUser();
            /*User user = new User();
            user.Name = name;
            user.Username = username;
            user.Password = pass;
            user.Surname = surname;
            user.Phone = phone;
            user.Email = email;
            user.Birthdate = birthdate;
            user.Id = id;
            user.State = true;*/
            if ((repositoryPerson.createPerson(user)) && (repositoryUser.createUser(user)))
            {
                return true;
            }

            return false;
        }
        //(string username, string pass, string typeUser, int id, string name, string surname, int phone, string email, DateTime birthdate)
        public bool updateUser(User user)
        {
            /*User user = new User();
            user.Name = name;
            user.Username = username;
            user.Password = pass;
            user.Surname = surname;
            user.Phone = phone;
            user.Email = email;
            user.Birthdate = birthdate;
            user.Id = id;
            user.State = true;*/
            if ((repositoryPerson.updatePerson(user)) && (repositoryUser.updateUser(user)))
            {
                return true;
            }

            return false;

            }
        public bool deleteUser(string username)
        {
            User user = repositoryUser.viewUser(username);
            
            if( (repositoryUser.deleteUser(username) ) && (repositoryPerson.deletePerson(user.Id)))
            { return true; }
            return false;
        }
        
        public List<User> listUser() {
            List<User> users= repositoryUser.listUsers();
            return users;
        }

        public List<User> listStateUser(int state )
        {
            List<User> users = repositoryUser.listStateUsers(state);
            return users;
        }

        public User viewUser( string username )
        {
            User user = repositoryUser.viewUser(username) ;
            return user;
        }
    }
}
