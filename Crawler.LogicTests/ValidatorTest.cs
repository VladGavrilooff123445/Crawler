using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace Crawler.LogicTests
{
    public class ValidatorTest
    {
        [Test]
        public void MainValidator_ShouldResturnValidLinks()
        {
            var validator = new Validator();
            var data = new List<string>();
            data.Add("/example");
            data.Add("@host/site");
            data.Add("?rest/site");
            var expectedResult = new List<string>();
            expectedResult.Add("/example");

            var result = validator.MainValidator(data);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
