using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
  /// <summary>
  /// Tests for English
  /// </summary>
  public class TestFormatsEn : Support.BaseTestFormats
  {
    protected override string GetLocale()
    {
      return "en-US";
    }

    [Fact]
    public void TestEveryMinute()
    {
      Assert.Equal("Every minute", GetDescription("* * * * *"));
    }

    [Fact]
    public void TestEvery1Minute()
    {
      Assert.Equal("Every minute", GetDescription("*/1 * * * *"));
      Assert.Equal("Every minute", GetDescription("0 0/1 * * * ?"));
    }

    [Fact]
    public void TestEveryHour()
    {
      Assert.Equal("Every hour", GetDescription("0 0 * * * ?"));
      Assert.Equal("Every hour", GetDescription("0 0 0/1 * * ?"));
    }

    [Fact]
    public void TestTimeOfDayCertainDaysOfWeek()
    {
      Assert.Equal("Weekdays at 11 PM", GetDescription("0 23 ? * MON-FRI"));
    }

    [Fact]
    public void TestEverySecond()
    {
      Assert.Equal("Every second", GetDescription("* * * * * *"));
    }

    [Fact]
    public void TestEvery45Seconds()
    {
      Assert.Equal("Every 45 seconds", GetDescription("*/45 * * * * *"));
    }

    [Fact]
    public void TestEvery5Minutes()
    {
      Assert.Equal("Every 5 minutes", GetDescription("*/5 * * * *"));
      Assert.Equal("Every 10 minutes", GetDescription("0 0/10 * * * ?"));
    }

    [Fact]
    public void TestEvery5MinutesOnTheSecond()
    {
      Assert.Equal("Every 5 minutes", GetDescription("0 */5 * * * *"));
    }

    [Fact]
    public void TestWeekdaysAtTime()
    {
      Assert.Equal("Weekdays at 11:30 AM", GetDescription("30 11 * * 1-5"));
    }

    [Fact]
    public void TestDailyAtTime()
    {
      Assert.Equal("At 11:30 AM", GetDescription("30 11 * * *"));
    }

    [Fact]
    public void TestMinuteSpan()
    {
      Assert.Equal("Every minute between 11 AM and 11:10 AM", GetDescription("0-10 11 * * *"));
    }

    [Fact]
    public void TestOneMonthOnly()
    {
      Assert.Equal("Every minute, only in March", GetDescription("* * * 3 *"));
    }

    [Fact]
    public void TestTwoMonthsOnly()
    {
      Assert.Equal("Every minute, only in March and June", GetDescription("* * * 3,6 *"));
    }

    [Fact]
    public void TestTwoTimesEachAfternoon()
    {
      Assert.Equal("At 2:30 PM and 4:30 PM", GetDescription("30 14,16 * * *"));
    }

    [Fact]
    public void TestThreeTimesDaily()
    {
      Assert.Equal("At 6:30 AM, 2:30 PM and 4:30 PM", GetDescription("30 6,14,16 * * *"));
    }

    [Fact]
    public void TestOnceAWeek()
    {
      Assert.Equal("Mondays at 9:46 AM", GetDescription("46 9 * * 1"));
    }

    [Fact]
    public void TestDayOfMonth()
    {
      Assert.Equal("On day 15 of the month at 12:23 PM", GetDescription("23 12 15 * *"));
    }

    [Fact]
    public void TestMonthName()
    {
      Assert.Equal("Only in January at 12:23 PM", GetDescription("23 12 * JAN *"));
    }

    [Fact]
    public void TestLowerCaseMonthName()
    {
      Assert.Equal("Only in January at 12:23 PM", GetDescription("23 12 * jan *"));
    }

    [Fact]
    public void TestDayOfMonthWithQuestionMark()
    {
      Assert.Equal("Only in January at 12:23 PM", GetDescription("23 12 ? JAN *"));
    }

    [Fact]
    public void TestMonthNameRange2()
    {
      Assert.Equal("January through February at 12:23 PM", GetDescription("23 12 * JAN-FEB *"));
    }

    [Fact]
    public void TestMonthNameRange3()
    {
      Assert.Equal("January through March at 12:23 PM", GetDescription("23 12 * JAN-MAR *"));
    }

    [Fact]
    public void TestDayOfWeekName()
    {
      Assert.Equal("Sundays at 12:23 PM", GetDescription("23 12 * * SUN"));
    }

    [Fact]
    public void TestDayOfWeekRange()
    {
      Assert.Equal("Weekdays every 5 minutes, after 3 PM", GetDescription("*/5 15 * * MON-FRI"));
    }

    [Fact]
    public void TestDayOfWeekRangeWithDOWLowerCased()
    {
      Assert.Equal("Weekdays every 5 minutes, after 3 PM", GetDescription("*/5 15 * * MoN-fri"));
    }

    [Fact]
    public void TestDayOfWeekOnceInMonth()
    {
      Assert.Equal("Every minute, on the third Monday of the month", GetDescription("* * * * MON#3"));
    }

    [Fact]
    public void TestLastDayOfTheWeekOfTheMonth()
    {
      Assert.Equal("Every minute, on the last Thursday of the month", GetDescription("* * * * 4L"));
    }

    [Fact]
    public void TestLastDayOfTheMonth()
    {
      Assert.Equal("On the last day of the month, only in January every 5 minutes", GetDescription("*/5 * L JAN *"));
    }

    [Fact]
    public void TestLastDayOffset()
    {
      Assert.Equal("5 days before the last day of the month at 12 AM", GetDescription("0 0 0 L-5 * ?"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the last weekday of the month", GetDescription("* * LW * *"));
    }

    [Fact]
    public void TestLastWeekdayOfTheMonth2()
    {
      Assert.Equal("Every minute, on the last weekday of the month", GetDescription("* * WL * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the first weekday of the month", GetDescription("* * 1W * *"));
    }

    [Fact]
    public void TestThirteenthWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the weekday nearest day 13 of the month", GetDescription("* * 13W * *"));
    }

    [Fact]
    public void TestFirstWeekdayOfTheMonth2()
    {
      Assert.Equal("Every minute, on the first weekday of the month", GetDescription("* * W1 * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth()
    {
      Assert.Equal("Every minute, on the weekday nearest day 5 of the month", GetDescription("* * 5W * *"));
    }

    [Fact]
    public void TestParticularWeekdayOfTheMonth2()
    {
      Assert.Equal("Every minute, on the weekday nearest day 5 of the month", GetDescription("* * W5 * *"));
    }

    [Fact]
    public void TestTimeOfDayWithSeconds()
    {
      Assert.Equal("At 2:02:30 PM", GetDescription("30 02 14 * * *"));
    }

    [Fact]
    public void TestSecondInternvals()
    {
      Assert.Equal("Seconds 5 through 10 past the minute", GetDescription("5-10 * * * * *"));
    }

    [Fact]
    public void TestMultiPartSecond()
    {
      Assert.Equal("At 15 and 45 seconds past the minute", GetDescription("15,45 * * * * *"));
    }

    [Fact]
    public void TestSecondMinutesHoursIntervals()
    {
      Assert.Equal("Seconds 5 through 10 past the minute, minutes 30 through 35 past the hour, between 10 AM and 12 PM", GetDescription("5-10 30-35 10-12 * * *"));
    }

    [Fact]
    public void TestEvery5MinutesAt30Seconds()
    {
      Assert.Equal("At 30 seconds past the minute, every 5 minutes", GetDescription("30 */5 * * * *"));
    }

    [Fact]
    public void TestMinutesPastTheHourRange()
    {
      Assert.Equal("Wednesday and Fridays at 30 minutes past the hour, between 10 AM and 1 PM", GetDescription("0 30 10-13 ? * WED,FRI"));
    }

    [Fact]
    public void TestSecondsPastTheMinuteInterval()
    {
      Assert.Equal("At 10 seconds past the minute, every 5 minutes", GetDescription("10 0/5 * * * ?"));
    }

    [Fact]
    public void TestRecurringFirstOfMonth()
    {
      Assert.Equal("At 6 AM", GetDescription("0 0 6 1/1 * ?"));
    }

    [Fact]
    public void TestMinutesPastTheHour()
    {
      Assert.Equal("At 5 minutes past the hour", GetDescription("0 5 0/1 * * ?"));
    }

    [Fact]
    public void TestOneYearOnlyWithSeconds()
    {
      Assert.Equal("Every second, only in 2013", GetDescription("* * * * * * 2013"));
    }

    [Fact]
    public void TestOneYearOnlyWithoutSeconds()
    {
      Assert.Equal("Every minute, only in 2013", GetDescription("* * * * * 2013"));
    }

    [Fact]
    public void TestTwoYearsOnly()
    {
      Assert.Equal("Every minute, only in 2013 and 2014", GetDescription("* * * * * 2013,2014"));
    }

    [Fact]
    public void TestYearRange2()
    {
      Assert.Equal("January through February, 2013 through 2014 at 12:23 PM", GetDescription("23 12 * JAN-FEB * 2013-2014"));
    }

    [Fact]
    public void TestYearRange3()
    {
      Assert.Equal("January through March, 2013 through 2015 at 12:23 PM", GetDescription("23 12 * JAN-MAR * 2013-2015"));
    }

    [Fact]
    public void TestDayOfWeekModifier()
    {
      Assert.Equal("On the second Sunday of the month at 12:23 PM", GetDescription("23 12 * * SUN#2"));
    }

    [Fact]
    public void TestDayOfWeekModifierWithSundayStartOne()
    {
        Options options = new Options
        {
            DayOfWeekStartIndexZero = false
        };

        Assert.Equal("On the second Sunday of the month at 12:23 PM", GetDescription("23 12 * * 1#2", options));
    }

    [Fact]
    public void TestHourRangeWithEveryPortion()
    {
      Assert.Equal("At 25 minutes past the hour, every 8 hours, between 7 AM and 7 PM", GetDescription("0 25 7-19/8 ? * *"));
    }

    [Fact]
    public void TestHourRangeWithTrailingZeroWithEveryPortion()
    {
      Assert.Equal("At 25 minutes past the hour, every 13 hours, between 7 AM and 8 PM", GetDescription("0 25 7-20/13 ? * *"));
    }

    [Fact]
    public void TestEvery3Day()
    {
      Assert.Equal("Every 3 days at 8 AM", GetDescription("0 0 8 1/3 * ? *"));
    }

    [Fact]
    public void TestsEvery3DayOfTheWeek()
    {
      Assert.Equal("Every 3 days of the week at 10:15 AM", GetDescription("0 15 10 ? * */3"));
    }

    [Fact]
    public void TestEvery2DayOfTheWeekInRange()
    {
      // GitHub Issue #58: https://github.com/bradymholt/cron-expression-descriptor/issues/58
      Assert.Equal("Every second, every 2 days of the week, weekdays", GetDescription("* * * ? * 1-5/2"));
    }

    [Fact]
    public void TestEvery2DayOfTheWeekInRangeWithSundayStartOne()
    {
      // GitHub Issue #59: https://github.com/bradymholt/cron-expression-descriptor/issues/59

      var options = new Options { DayOfWeekStartIndexZero = false };

      Assert.Equal("Every second, every 2 days of the week, weekdays",
          GetDescription("* * * ? * 2-6/2", options));
    }

    [Fact]
    public void TestMultiWithDayOfWeekStartIndexZeroFalse()
    {
      // Coverage for GitHub Issue #126: https://github.com/bradymholt/cron-expression-descriptor/issues/126
      var options = new Options { DayOfWeekStartIndexZero = false };

      Assert.Equal("Every second Sunday, Monday, and Tuesdays",
          GetDescription("* * * ? * 1,2,3", options));
    }

    [Fact]
    public void TestEvery3Month()
    {
      Assert.Equal("On day 2 of the month, every 3 months at 7:05 AM", GetDescription("0 5 7 2 1/3 ? *"));
    }

    [Fact]
    public void TestEvery2Years()
    {
      Assert.Equal("On day 1 of the month, only in January, every 2 years at 6:15 AM", GetDescription("0 15 6 1 1 ? 1/2"));
    }

    [Fact]
    public void TestMutiPartRangeMinutes()
    {
      Assert.Equal("At 2 and 4 through 5 minutes past the hour, at 1 AM", GetDescription("2,4-5 1 * * *"));
    }

    [Fact]
    public void TestMutiPartRangeMinutes2()
    {
      Assert.Equal("At 2 and 26 through 28 minutes past the hour, at 6 PM", GetDescription("2,26-28 18 * * *"));
    }

    [Fact]
    public void TrailingSpaceDoesNotCauseAWrongDescription()
    {
      // GitHub Issue #51: https://github.com/bradymholt/cron-expression-descriptor/issues/51
      Assert.Equal("At 7 AM", GetDescription("0 7 * * * "));
    }

    [Fact]
    public void TestMultiPartDayOfTheWeek()
    {
      // GitHub Issue #44: https://github.com/bradymholt/cron-expression-descriptor/issues/44
      Assert.Equal("Monday through Thursday and Sundays at 10 AM", GetDescription("0 00 10 ? * MON-THU,SUN *"));
    }

    [Fact]
    public void TestDayOfWeekWithDayOfMonth()
    {
      // GitHub Issue #46: https://github.com/bradymholt/cron-expression-descriptor/issues/46
      Assert.Equal("On day 1, 2, and 3 of the month Wednesday and Fridays at 12 AM", GetDescription("0 0 0 1,2,3 * WED,FRI"));
    }

    [Fact]
    public void TestSecondsInternalWithStepValue()
    {
      // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
      Assert.Equal("Every 30 seconds, starting at 5 seconds past the minute", GetDescription("5/30 * * * * ?"));
    }

    [Fact]
    public void TestMinutesInternalWithStepValue()
    {
      Assert.Equal("Every 30 minutes, starting at 5 minutes past the hour", GetDescription("0 5/30 * * * ?"));
    }

    [Fact]
    public void TestHoursInternalWithStepValue()
    {
      Assert.Equal("Every second, every 8 hours, starting at 5 AM", GetDescription("* * 5/8 * * ?"));
    }

    [Fact]
    public void TestDayOfMonthInternalWithStepValue()
    {
      Assert.Equal("Every 3 days, starting on day 2 of the month at 7:05 AM", GetDescription("0 5 7 2/3 * ? *"));
    }

    [Fact]
    public void TestMonthInternalWithStepValue()
    {
      Assert.Equal("Every 2 months, March through December at 7:05 AM", GetDescription("0 5 7 ? 3/2 ? *"));
    }

    [Fact]
    public void TestDayOfWeekInternalWithStepValue()
    {
      Assert.Equal("Every 3 days of the week, Tuesday through Saturday at 7:05 AM", GetDescription("0 5 7 ? * 2/3 *"));
    }

    [Fact]
    public void TestYearInternalWithStepValue()
    {
      Assert.Equal("Every 4 years, 2016 through 9999 at 7:05 AM", GetDescription("0 5 7 ? * ? 2016/4"));
    }

    [Fact]
    public void TestMinutesCombinedWithMultipleHourRanges()
    {
      Assert.Equal("At 1 minutes past the hour, at 1 AM and 3 AM through 4 AM", GetDescription("1 1,3-4 * * *"));
    }

    [Fact]
    public void TestSecondsExpressionCombinedWithHoursListAndSingleMinute()
    {
      Assert.Equal("On day 5 of the month at 5 seconds past the minute, at 30 minutes past the hour, at 6 AM, 2 PM, and 4 PM", GetDescription("5 30 6,14,16 5 * *"));
    }

    [Fact]
    public void TestMinuteRangeWithInterval()
    {
      Assert.Equal("Every 3 minutes, minutes 0 through 20 past the hour, after 9 AM", GetDescription("0-20/3 9 * * *"));
    }

    [Fact]
    public void MinutesZero1()
    {
      Assert.Equal("Every second, at 0 minutes past the hour, every 4 hours", GetDescription("* 0 */4 * * *"));
    }

    [Fact]
    public void MinutesZero2()
    {
      Assert.Equal("Every 10 seconds, at 0 minutes past the hour", GetDescription("*/10 0 * * * *"));
    }

    [Fact]
    public void MinutesZero3()
    {
      Assert.Equal("Every second, at 0 minutes past the hour, after 12 AM", GetDescription("* 0 0 * * *"));
    }

    [Fact]
    public void MinutesZero4()
    {
      Assert.Equal("Every minute, after 12 AM", GetDescription("* 0 * * *"));
    }

    [Fact]
    public void MinutesZero5()
    {
      Assert.Equal("Every second, at 0 minutes past the hour", GetDescription("* 0 * * * *"));
    }

    [Fact]
    public void Sunday7()
    {
      Assert.Equal("Sundays at 9 AM", GetDescription("0 0 9 ? * 7"));
    }
  }
}
