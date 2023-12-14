using NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.Query.ListarUsuario
{
    public class GetUserListQuery_test
    {
        [Fact]
        public void GetUserListQuery_PropertiesAreSetCorrectly()
        {
            // Arrange
            var searchTerm = "test";

            // Act
            var query = new GetUserListQuery
            {
                SearchTerm = searchTerm
            };

            // Assert
            Assert.Equal(searchTerm, query.SearchTerm);
        }

        [Fact]
        public void GetUserListQuery_DefaultConstructor_SetsPropertiesToDefaultValues()
        {
            // Act
            var query = new GetUserListQuery();

            // Assert
            Assert.Null(query.SearchTerm);
        }
    }
}
