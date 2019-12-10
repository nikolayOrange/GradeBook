using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests

    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            string upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string paramater)
        {
            return paramater.ToUpper();
        }

        [Fact]
        public void test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z){
            z = 42;
        }

        [Fact]
        public int GetInt()
        {
            return 3;
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CannotAddNegativeGrade()
        {
            InMemoryBook book1 = GetBook("Book 1");
            book1.AddGrade(-1);
            var x = book1.GetStatistics();

            Assert.NotEqual(x.High, 105);
        }

        [Fact]
        public void CannotAddGreaterGrade()
        {
            InMemoryBook book1 = GetBook("Book 1");
            book1.AddGrade(105);
            var x = book1.GetStatistics();

            Assert.NotEqual(x.High, 105);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            InMemoryBook book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }

        private void SetName(InMemoryBook book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = book1;
            
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
