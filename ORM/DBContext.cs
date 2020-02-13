using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace ORM
{
    public class DBContext : AbstractDBContext, IDisposable
    {
        private DbSet<Exam> _exams;
        private DbSet<Group> _groups;
        private DbSet<Result> _results;
        private DbSet<Session> _sessions;
        private DbSet<Student> _students;
        private DbSet<Subject> _subjects;

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


        public DBContext()
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

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
