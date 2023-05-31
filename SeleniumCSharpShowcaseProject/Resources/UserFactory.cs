using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpShowcaseProject.Resources
{
    public class UserFactory
    {
        public static User CreateUser(bool subscription)
        {
            User user = new Faker<User>()
                .RuleFor(u => u.FirstName, bogus => bogus.Name.FirstName())
                .RuleFor(u => u.LastName, bogus => bogus.Name.LastName())
                .RuleFor(u => u.Email, bogus => bogus.Internet.ExampleEmail())
                .RuleFor(u => u.Password, bogus => bogus.Internet.Password());
            user.ConfirmPassword = user.Password;
            user.Subscription = subscription;

            return user;
        }
    }
}
