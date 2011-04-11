using LibSudoku;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibSudokuTestProjec
{
    
    
    /// <summary>
    ///This is a test class for GameTest and is intended
    ///to contain all GameTest Unit Tests
    ///</summary>
    [TestClass]
    public class GameTest
    {
        private string data = "379000014060010070080009005435007000090040020000800436900700080040080050850000249";
            //"111222333111222333111222333444555666444555666444555666777888999777888999777888999";
        //"123123123456456456789789789123123123456456456789789789123123123456456456789789789";
        private TestContext testContextInstance;
        private static Game_Accessor _target;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _target = new Game_Accessor(false);
        }

        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for exportCurrentState
        ///</summary>
        [TestMethod]
        public void exportCurrentStateTest()
        {
            string actual = _target.exportCurrentState();
            Assert.AreEqual(data, actual);
        }

        /// <summary>
        ///A test for exportOriginal
        ///</summary>
        [TestMethod]
        public void exportOriginalTest()
        {
            string actual = _target.exportOriginal();
            Assert.AreEqual(data, actual);
        }

        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        public void GameConstructorTest1()
        {
            Game_Accessor target2 = new Game_Accessor(data);
            Assert.AreEqual(target2.exportCurrentState(), _target.exportCurrentState());
        }

        /// <summary>
        ///A test for Solve
        ///</summary>
        [TestMethod()]
        public void SolveTest()
        {
            
            _target.Solve();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for importData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LibSudoku.dll")]
        public void importDataTest()
        {
            _target.importData(data);
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for setupRegions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LibSudoku.dll")]
        public void setupRegionsTest()
        {
            _target.setupRegions();
        }

        /// <summary>
        ///A test for updatenotes
        ///</summary>
        [TestMethod()]
        public void updatenotesTest()
        {
            _target.updatenotes();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
