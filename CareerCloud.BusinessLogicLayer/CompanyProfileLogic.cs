using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic:BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repo):base(repo)
        {

        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        //protected override void Verify(CompanyProfilePoco[] pocos)
        //{
        //    List<ValidationException> exceptions = new List<ValidationException>();

        //    foreach (CompanyProfilePoco poco in pocos)
        //    {
        //        if (!string.IsNullOrEmpty(poco.CompanyWebsite))
        //        {
        //            if (!poco.CompanyWebsite.EndsWith(".ca") || !poco.CompanyWebsite.EndsWith(".com") || !poco.CompanyWebsite.EndsWith(".biz"))
        //            {
        //                exceptions.Add(new ValidationException(600, "Valid websites must end with the specified extensions"));
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(poco.ContactPhone))
        //        {
        //            string[] phoneComponents = poco.ContactPhone.Split('-');

        //            if (phoneComponents.Length != 3)
        //            {
        //                exceptions.Add(new ValidationException(601, "PhoneNumber is invalid"));
        //            }
        //            else
        //            {
        //                if (phoneComponents[0].Length != 3)
        //                {
        //                    exceptions.Add(new ValidationException(601, "PhoneNumber is invalid"));
        //                }
        //                else if (phoneComponents[1].Length != 3)
        //                {
        //                    exceptions.Add(new ValidationException(601, "PhoneNumber is invalid"));
        //                }
        //                else if (phoneComponents[2].Length != 4)
        //                {
        //                    exceptions.Add(new ValidationException(601, "PhoneNumber is invalid"));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            exceptions.Add(new ValidationException(601, "PhoneNumber is invalid"));
        //        }
        //    }
        //    if (exceptions.Count > 0)
        //    {
        //        throw new AggregateException(exceptions);
        //    }
        //}

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.ContactPhone) || item.ContactPhone.Length != 12)
                {
                    exceptions.Add(new ValidationException(601, $"{item.Id} cannot be empty"));
                }

                bool exist = false;
                if (!string.IsNullOrEmpty(item.CompanyWebsite) && (item.CompanyWebsite.Contains(".ca") || item.CompanyWebsite.Contains(".com")
                    || item.CompanyWebsite.Contains(".biz"))) exist = true;

                if (string.IsNullOrEmpty(item.CompanyWebsite) || !exist)
                {
                    exceptions.Add(new ValidationException(600, $"{item.Id} cannot be empty"));
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }


    }
}
