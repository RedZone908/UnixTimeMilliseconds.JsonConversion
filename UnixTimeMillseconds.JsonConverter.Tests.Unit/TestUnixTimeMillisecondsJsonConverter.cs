using Newtonsoft.Json;
using NUnit.Framework;
using System;
using UnixTimeMilliseconds.JsonConversion;

namespace UnixTimeMillseconds.JsonConversion.Tests.Unit
{
    public class TestUnixTimeMillisecondsJsonConverter
    {
        [Test]
        public void TestDeserialize()
        {
            var input = "1519318716745";
            var correct = DateTime.SpecifyKind(new DateTime(2018, 2, 22, 16, 58, 36, 745), DateTimeKind.Utc);

            var rslt = JsonConvert.DeserializeObject<DateTime>(input, new UnixTimeMillisecondsConverter());

            Assert.That(rslt.ToUniversalTime(), Is.EqualTo(correct));
        }

        [Test]
        public void TestSerialize()
        {
            var input = DateTime.SpecifyKind(new DateTime(2018, 2, 22, 16, 58, 36, 745), DateTimeKind.Utc);
            var correct = "1519318716745";

            var rslt = JsonConvert.SerializeObject(input, new UnixTimeMillisecondsConverter());

            Assert.That(rslt, Is.EqualTo(correct));
        }
    }
}