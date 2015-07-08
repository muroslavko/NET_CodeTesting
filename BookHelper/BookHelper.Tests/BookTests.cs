using NUnit.Framework;

namespace BookHelper.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void HowManyPagesLeft_When_given_few_read_ranges_Then_returns_correct_count_of_unread_pages()
        {
            // Arrange
            var book = new Book(10);
            book.AddRange(3, 4);
            book.AddRange(6, 8);

            // Act
            var leftPages = book.HowManyPagesLeft();

            // Assert
            Assert.That(leftPages, Is.EqualTo(5));
        }

        // TODO 2: Write test that checks that HowManyPagesLeft() correctly counts pages when overlapped ranges are added. Fix the code if test fails.
        [Test]
        public void
            HowManyPagesLeft_When_given_few_read_ranges_that_overlapped_Then_returns_correct_count_of_unread_pages
            ()
        {
            // Arrange
            var book = new Book(10);
            book.AddRange(1,5);
            book.AddRange(2,8);

            // Act
            var leftPages = book.HowManyPagesLeft();

            //Assert
            Assert.That(leftPages,Is.EqualTo(2));
        }
        [Test]
        public void
            HowManyPagesLeft_When_had_not_give_few_read_ranges_Then_returns_correct_count_of_unread_pages
            ()
        {
            // Arrange
            var book = new Book(10);

            // Act
            var leftPages = book.HowManyPagesLeft();

            //Assert
            Assert.That(leftPages, Is.EqualTo(0));
        }
    }
}
