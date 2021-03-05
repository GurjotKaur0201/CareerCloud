using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic : BaseLogic<SystemCountryCodePoco>
    {
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repo) : base(repo)
        {

        }
       public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
        //public void Get(SystemCountryCodePoco[] pocos)
        //{
        //    Verify(pocos);
        //    base.Get(pocos);
        //}
        //public void GetAll(SystemCountryCodePoco[] pocos)
        //{
        //    Verify(pocos);
        //    base.GetAll(pocos);
        //}

        public SystemCountryCodePoco Get(string id)
        {            
            return _repository.GetSingle(c=>c.Code==id);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, "Code cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, "Name cannot be empty"));
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }

        public List<SystemCountryCodePoco> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
