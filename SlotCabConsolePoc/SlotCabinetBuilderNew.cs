namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.SlotAccounting.Models;

    public class SlotCabinetBuilderNew
    {
        public static SlotCabinet Build(Action<SlotCabinet> customize = null)
        {
            var nextNumber = Utils.GetNextNaturalNumber();

            var slotCabinet = new SlotCabinet
            {
                SlotCabinetId = Guid.NewGuid(),
                HouseNumber = (ushort?) nextNumber,
                AssetNumber = Utils.NextAssetNumber(),
                LogicBoardSerialNumber = Utils.NextLogicBoardSerialNumber().ToString(),
                SlotCabinetManufactureId = Utils.GetRandomSlotCabinetManufacturerId(),
                Description = $"Description{nextNumber}",
                SlotCabinetStyleId = Utils.GetRandomSlotCabinetStyleId(), 
                SlotCabinetTypeId = Utils.GetRandomSlotCabinetTypeId(),
                IsActive = nextNumber % 2 == 0, //TODO:RR: default to true?
                SiteCode = 0
            };

            customize?.Invoke(slotCabinet);

            return slotCabinet;
        }

        public static IEnumerable<SlotCabinet> BuildMany(int slotCabinetsCount = 5,
            Action<SlotCabinet> customize = null)
        {
            var slotCabinets = Enumerable.Range(1, slotCabinetsCount)
                .Select(x => Build(customize))
                .ToList();

            return slotCabinets;
        }
    }
}