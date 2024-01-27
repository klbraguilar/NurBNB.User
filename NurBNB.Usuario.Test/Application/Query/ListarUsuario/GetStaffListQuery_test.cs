using NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.Query.ListarUsuario
{
    public class GetStaffListQuery_test
    {
        [Fact]
        public void GetStaffListQuery_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var getStaffListQuery = new GetStaffListQuery
            {
                Id = id
            };

            // Assert
            Assert.NotNull(getStaffListQuery);
            Assert.IsType<GetStaffListQuery>(getStaffListQuery);
            Assert.Equal(id, getStaffListQuery.Id);
        }
    }
}
