namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Microsoft.Extensions.Internal;

    public static class Utils
    {
        private static readonly Random Random = new Random();
        private static int _validationNumber = 1000000;
        private static int _assetNumber = 1000000;
        private static int _logicBoardSerialNumber = 1000000;

        public static uint NextAssetNumber() => (uint)Interlocked.Increment(ref _assetNumber);

        public static uint NextLogicBoardSerialNumber() => (uint)Interlocked.Increment(ref _logicBoardSerialNumber);

        public static uint NextValidationNumber() => (uint)Interlocked.Increment(ref _validationNumber);

        public static int GetNextNaturalNumber() => NaturalNumberSequence.NextValue();

        public static int GetRandomTicketAmount() => Random.Next(1000, 100000);

        internal static int GetRandomSlotCabinetTypeId()
        {
            var values = Enum.GetValues(typeof(SlotCabinetTypeEnum));
            return (int)values.GetValue(Random.Next(values.Length));
        }
        internal static int GetRandomSlotCabinetStyleId()
        {
            var values = Enum.GetValues(typeof(SlotCabinetStyleEnum));
            return (int)values.GetValue(Random.Next(values.Length));
        }
        internal static int GetRandomSlotCabinetManufacturerId()
        {
            var values = Enum.GetValues(typeof(SlotCabinetManufacturerTypeEnum));
            return (int) values.GetValue(Random.Next(values.Length));
        }
        public static string SampleString(int maxLength = 0, [CallerMemberName] string caller = null)
        {
            var sampleString = Guid.NewGuid() + "-" + caller?.Replace("Sample", "");
            return sampleString.LimitLength(maxLength);
        }

        public static string SampleMacAddress()
        {
            return
                $"{Random.Next(10, 100)}:{Random.Next(10, 100)}:{Random.Next(10, 100)}:{Random.Next(10, 100)}:{Random.Next(10, 100)}:{Random.Next(10, 100)}";
        }

        public static DateTimeOffset SampleDateTime() => new RandomDateTimeOffset(Random).NextDateTime();

        private static string LimitLength(this string source, int maxLength)
        {
            if (maxLength <= 0 || source.Length <= maxLength) return source;

            return source.Substring(0, maxLength);
        }

        private static class NaturalNumberSequence
        {
            private static int _currentValue = 1;

            public static int NextValue()
            {
                return Interlocked.Increment(ref _currentValue);
            }
        }

        private static string SamplePhoneNumber()
        {
            return $"({Random.Next(100, 1000)}) {Random.Next(100, 1000)}-{Random.Next(1000, 10000)}";
        }

        private static DateTimeOffset SampleDate()
        {
            return new RandomDateTimeOffset(Random).NextDate();
        }

        private class RandomDateTimeOffset
        {
            private readonly Random _random;
            private readonly DateTimeOffset _now;

            public RandomDateTimeOffset(Random random)
            {
                _random = random;
                _now = DateTimeOffset.UtcNow;
            }

            public RandomDateTimeOffset(Random random, ISystemClock clock)
            {
                _random = random;
                _now = clock.UtcNow;
            }

            public DateTimeOffset NextDate()
            {
                return TruncateTime(NextDateTime());
            }

            public DateTimeOffset NextDateTime()
            {
                return new DateTimeOffset((long) (_random.NextDouble() * DateTimeOffset.MaxValue.Ticks), TimeSpan.Zero);
            }

            public DateTimeOffset NextPastDate()
            {
                return TruncateTime(NextPastDateTime());
            }

            public DateTimeOffset NextPastDateTime()
            {
                return new DateTimeOffset((long) (_random.NextDouble() * (_now.Ticks - 1)), TimeSpan.Zero);
            }

            public DateTimeOffset NextFutureDate()
            {
                return TruncateTime(NextFutureDateTime());
            }

            public DateTimeOffset NextFutureDateTime()
            {
                return new DateTimeOffset(
                    _now.Ticks + (long) (_random.NextDouble() * (DateTimeOffset.MaxValue.Ticks - _now.Ticks - 1)) + 1,
                    TimeSpan.Zero);
            }

            private static DateTimeOffset TruncateTime(DateTimeOffset dateTimeOffset)
            {
                return new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0,
                    TimeSpan.Zero);
            }
        }

        internal enum SlotCabinetTypeEnum
        {
            CabType1 = 1,
            CabType2 = 2
        }

        internal enum SlotCabinetStyleEnum
        {
            Style1 = 1,
            Style2 = 2
        }

        internal enum SlotCabinetManufacturerTypeEnum
        {
            IGT = 1,
            MTD = 2,
            Spielo = 3,
            GVG =4
        }
    }
}