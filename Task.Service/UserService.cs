using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Data.Infrastructure;
using Task.Data.Repositories;
using Task.Model.Models;

namespace Task.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User GetUser(int id);

        void CreateUser(User user);

        void SaveUser();
    }

    public class UserService : IUserService
    {
        #region Fields

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Ctor

        public UserService(IUserRepository usesRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = usesRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region IUserService Members

        public IEnumerable<User> GetUsers()
        {
            var users = userRepository.GetAll();
            return users;
        }

        public User GetUser(int id)
        {
            var user = userRepository.GetById(id);
            return user;
        }

        public void CreateUser(User user)
        {
            userRepository.Add(user);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
