﻿namespace Company.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; }

        public string PersonalId { get; private set; }

        public string CompanyName { get; set; }

        private Employee()
        {

        }

        public Employee Update(string companyName)
        {
            CompanyName = companyName;

            return this;
        }

        public static Employee Create(string name, string personalId)
        {
            Employee employee = new Employee()
            {
                Name = name,
                PersonalId = personalId
            };

            return employee;
        }
    }
}
