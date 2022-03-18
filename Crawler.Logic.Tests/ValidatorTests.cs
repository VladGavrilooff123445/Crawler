using Crawler.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace Crawler.LogicTests
{
    public class ValidatorTests
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

        [Test]
        public void MainValidator_ShouldReturnEmptyListIfAllNotValid()
        {
            var validator = new Validator();
            var data = new List<string>();
            data.Add("#example");
            data.Add("@host/site");
            data.Add("?rest/site");
            

            var result = validator.MainValidator(data);

            Assert.IsEmpty(result);
        }
    }
}
