using DataModel;
using System;

namespace ORM
{
    /// <summary>
    /// Class desribes the database context.
    /// </summary>
    public class DBContext : AbstractDBContext, IDisposable
    {
        private DbSet<Exam> _exams;
        private DbSet<Group> _groups;
        private DbSet<Result> _results;
        private DbSet<Session> _sessions;
        private DbSet<Student> _students;
        private DbSet<Subject> _subjects;

        /// <summary>
        /// Set of exam entities.
        /// </summary>
        public DbSet<Exam> Exams
        {
            get
            {
                return _exams ?? (_exams = new DbSet<Exam>(connectionString));
            }
            set
            {
                _exams = value;
            }
        }

        /// <summary>
        /// Set of group entities.
        /// </summary>
        public DbSet<Group> Groups
        {
            get
            {
                return _groups ?? (_groups = new DbSet<Group>(connectionString));
            }
            set
            {
                _groups = value;
            }
        }

        /// <summary>
        /// Set of result entities.
        /// </summary>
        public DbSet<Result> Results
        {
            get
            {
                return _results ?? (_results = new DbSet<Result>(connectionString));
            }
            set
            {
                _results = value;
            }
        }

        /// <summary>
        /// Set of session entities.
        /// </summary>
        public DbSet<Session> Sessions
        {
            get
            {
                return _sessions ?? (_sessions = new DbSet<Session>(connectionString));
            }
            set
            {
                _sessions = value;
            }
        }

        /// <summary>
        /// Set of student entities.
        /// </summary>
        public DbSet<Student> Students
        {
            get
            {
                return _students ?? (_students = new DbSet<Student>(connectionString));
            }
            set
            {
                _students = value;
            }
        }

        /// <summary>
        /// Set of subject entities.
        /// </summary>
        public DbSet<Subject> Subjects
        {
            get
            {
                return _subjects ?? (_subjects = new DbSet<Subject>(connectionString));
            }
            set
            {
                _subjects = value;
            }
        }



        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        /// <summary>
        /// Method for disposing the database context object.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DBContext()
        // {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.

        /// <summary>
        /// Method for disposing the database context object.
        /// </summary>
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
