using Newtonsoft.Json;
using NUnit.Framework;
using System;
using UnixTimeMilliseconds.JsonConversion;

namespace UnixTimeMillseconds.JsonConversion.Tests.Unit
{
    public class TestUnixTimeMillisecondsToDateTimeOffsetJsonConverter
    {
        [Test]
        public void TestDeserialize()
        {
            var input = "1519318716745";
            var correct = new DateTimeOffset(DateTime.SpecifyKind(new DateTime(2018, 2, 22, 16, 58, 36, 745), DateTimeKind.Utc));

            var rslt = JsonConvert.DeserializeObject<DateTimeOffset>(input, new UnixTimeMillisecondsToDateTimeOffsetJsonConverter());

            Assert.That(rslt, Is.EqualTo(correct));
        }

        [Test]
        public void TestSerialize()
        {
            var input = new DateTimeOffset(DateTime.SpecifyKind(new DateTime(2018, 2, 22, 16, 58, 36, 745), DateTimeKind.Utc));
            var correct = "1519318716745";

            var rslt = JsonConvert.SerializeObject(input, new UnixTimeMillisecondsToDateTimeOffsetJsonConverter());

            Assert.That(rslt, Is.EqualTo(correct));
        }
    }
}