using NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.Query.ListarUsuario
{
    public class GetGuestListQuery_test
    {
        [Fact]
        public void GetGuestListQuery_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var searchTerm = "John Doe";

            // Act
            var getGuestListQuery = new GetGuestListQuery
            {
                SearchTerm = searchTerm
            };

            // Assert
            Assert.NotNull(getGuestListQuery);
            Assert.IsType<GetGuestListQuery>(getGuestListQuery);
            Assert.Equal(searchTerm, getGuestListQuery.SearchTerm);
        }
    }
}
