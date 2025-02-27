﻿using Common.Dto;
using FluentAssertions;
using NUnit.Framework;
using System.Text.Json;

namespace UnitTests.Common.Dto
{
	public class MetricTests
	{
		[Test]
		public void Json_Can_Deserialzize_To_Metric()
		{
			var sampleMetricPayload = "{ \"display_name\": \"Pace\", \"display_unit\": \"min/mi\",\"max_value\": 14.63,\"average_value\": 18.02,\"Values\": [null, -1, 10, 12]}";

			var metric = JsonSerializer.Deserialize<Metric>(sampleMetricPayload, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
			metric.Values.Should().NotBeNullOrEmpty();
			metric.Values.Length.Should().Be(4);
			metric.Values.GetValue(0).Should().BeNull();
			metric.GetValue(0).Should().Be(0);
			metric.GetValue(1).Should().Be(-1);
			metric.GetValue(2).Should().Be(10);
			metric.GetValue(3).Should().Be(12);
		}
	}
}
