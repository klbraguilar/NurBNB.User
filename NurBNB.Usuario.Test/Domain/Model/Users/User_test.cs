using NurBNB.Usuario.Domain.Model.Users;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace NurBNB.Usuario.Test.Domain.Model.Users
{
    public class User_test
    {
        [Fact]
        public void User_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var username = "JohnDoe";
            var email = new Email("johndoe@example.com");
            var password = "123456";

            // Act
            var user = new User(username, email, password);

            // Assert
            Assert.Equal(username, user.Username);
            Assert.Equal(email, user.Email);
            Assert.Equal(password, user.Password);
        }

        [Fact]
        public void User_Creation_SetsIdToNotEmptyGuid()
        {
            // Arrange
            var username = "JohnDoe";
            var email = new Email("johndoe@example.com");
            var password = "123456";

            // Act
            var user = new User(username, email, password);

            // Assert
            Assert.NotEqual(Guid.Empty, user.Id);
        }

        [Fact]
        public void User_Edit_SetsUsernameCorrectly()
        {
            // Arrange
            var username = "JohnDoe";
            var email = new Email("johndoe@example.com");
            var password = "123456";
            var user = new User(username, email, password);

            // Act
            var newUsername = "JaneDoe";
            user.Edit(newUsername);

            // Assert
            Assert.Equal(newUsername, user.Username);
        }
    }
}
