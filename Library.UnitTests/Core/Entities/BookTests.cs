using Library.Core.Entities;

namespace Library.UnitTests.Core.Entities
{
    public class BookTests
    {
        [Fact]
        public void TestIfBookActivateWorks()
        {
            var book = new Book("Nome de Teste","Author de Teste","ISBN de Teste",1234);

            book.Activate();

            Assert.True(book.Active);
        }

        [Fact]
        public void TestIfBookDeactivateWorks()
        {
            var book = new Book("Nome de Teste", "Author de Teste", "ISBN de Teste", 1234);

            book.Deactivate();

            Assert.False(book.Active);
        }
    }
}
