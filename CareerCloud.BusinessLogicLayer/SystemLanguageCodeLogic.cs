using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic: BaseLogic<SystemLanguageCodePoco>
    {
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repo): base(repo)
        {

        }
        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
        //public void Get(SystemLanguageCodePoco[] pocos)
        //{
        //    Verify(pocos);
        //    Get(pocos);
        //}
        //public void GetAll(SystemLanguageCodePoco[] pocos)
        //{
        //    Verify(pocos);
        //    GetAll(pocos);
        //}

        public SystemLanguageCodePoco Get(string id)
        {
            return _repository.GetSingle(c => c.LanguageID == id);
        }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, "String cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, "Name cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, "Native Name cannot be empty"));
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }

        public List<SystemLanguageCodePoco> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
