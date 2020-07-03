using NUnit.Framework;

namespace ClickityClick_Test_Project
{
    public class Tests
    {
        Page page = new Page();

        [SetUp]
        public void Setup()
        {
            page.start_Browser();
        }

        // tests if page is accessible
        [Test]
        public void test_PageIsAccessible()
        {
            page.test_Browserops();
        }

        // tests if dialog box shows up after clicking all of the logos within the initial grid
        [Test]
        public void test_DialogShowsUp()
        {
            page.click_InitialElements();
            page.assert_DialogIsVisible();
        }

        // tests if puzzle grid changes its pattern correctly after choosing input value 3
        [Test]
        public void test_GridSize3()
        {
            page.click_InitialElements();
            page.assert_PuzzleSizeChangesTo3x3();
        }

        // tests if puzzle grid changes its pattern correctly after choosing input value 9
        [Test]
        public void test_GridSize9()
        {
            page.click_InitialElements();
            page.assert_PuzzleSizeChangesTo9x9();
        }

        // tests if dialog input does not accept value lower than Min
        [Test]
        public void test_InputLowerMin()
        {
            page.click_InitialElements();
            page.assert_InputBelowMinIsNotAccepted();
        }

        // tests if dialog input does not accept value greater than Max
        [Test]
        public void test_InputAboveMax()
        {
            page.click_InitialElements();
            page.assert_InputAboveMaxIsNotAccepted();
        }

        // tests if dialog box doesn't show up if one inner logo is activated
        [Test]
        public void test_WrongPatternIsNotAllowed()
        {
            page.click_WrongElement();
            page.click_InitialElements();
            page.assert_DialogIsNotPresented();
        }

        [TearDown]
        public void close_Browser()
        {
            page.close_Browser();
        }
    }
}