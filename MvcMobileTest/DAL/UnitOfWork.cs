using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practico.MvcMobile.Models;

namespace Practico.MvcMobile.DAL
{
    public class UnitOfWork : IDisposable
    {
        private Context context = new Context();
        private Repository<User> userRepository;
        private Repository<Test> testRepository;
        private Repository<Question> questionRepository;
        private Repository<Answer> answerRepository;
        //private Repository<Course> courseRepository;

        //Singleton para el Repository de User
        public Repository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new Repository<User>(context);
                }
                return userRepository;
            }
        }

        public Repository<Test> TestRepository
        {
            get
            {
                if (this.testRepository == null)
                {
                    this.testRepository = new Repository<Test>(context);
                }
                return testRepository;
            }
        }

        public Repository<Question> QuestionRepository
        {
            get
            {
                if (this.questionRepository == null)
                {
                    this.questionRepository = new Repository<Question>(context);
                }
                return questionRepository;
            }
        }

        public Repository<Answer> AnswerRepository
        {
            get
            {
                if (this.answerRepository == null)
                {
                    this.answerRepository = new Repository<Answer>(context);
                }
                return answerRepository;
            }
        }

        //public Repository<Course> CourseRepository
        //{
        //    get
        //    {

        //        if (this.courseRepository == null)
        //        {
        //            this.courseRepository = new GenericRepository<Course>(context);
        //        }
        //        return courseRepository;
        //    }
        //}

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}