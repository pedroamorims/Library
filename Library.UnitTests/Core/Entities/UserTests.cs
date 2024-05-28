using Library.Core.Entities;

namespace Library.UnitTests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public void TestIfUserActivateWorks()
        {
            var user = new User("Nome de Teste","Email de Teste","Senha de Teste","admin");

            user.Activate();

            Assert.True(user.Active);
        }

        [Fact]
        public void TestIfUserDeactivateWorks()
        {
            var user = new User("Nome de Teste", "Email de Teste", "Senha de Teste", "admin");

            user.Deactivate();

            Assert.False(user.Active);
        }
    }
}
