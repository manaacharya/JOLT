using Bunit;
using NUnit.Framework;

/// <summary>
/// Test context for unit testing 
/// </summary>
namespace UnitTests
{
    /// <summary>
    /// Test Context used by bUnit
    /// </summary>
    public abstract class BunitTestContext : TestContextWrapper
    {
        /// <summary>
        /// The Setup sets the context
        /// </summary>
        [SetUp]
        public void Setup() => TestContext = new Bunit.TestContext();

        /// <summary>
        /// When done displose removes it, to free up system resources
        /// </summary>
        [TearDown]
        public void TearDown() => TestContext.Dispose();
    }
}