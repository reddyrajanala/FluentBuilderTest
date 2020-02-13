namespace GEI.GoldenEdge.SMIBv3.DataContracts
{
    public enum SlotEventType
    {
        Unknown = 0,
        RegisterCabinet = 1,
        CabinetOnline = 2,
        RegisterSlotGame = 3,

        SlotDoorOpened = 4,
        SlotDoorClosed = 5,
        DropDoorOpened = 6,
        DropDoorClosed = 7,
        CardCageOpened = 8,
        CardCageClosed = 9,
        ACPowerApplied = 10,
        ACPowerLost = 11,

        CashboxDoorOpened = 12,
        CashboxDoorClosed = 13,
        CashboxWasRemoved = 14,
        CashboxWasInstalled = 15,
        CashboxNearFullDetected = 16,
        CashboxFullDetected = 17,

        BellyDoorOpened = 18,
        BellyDoorClosed = 19,

        AttendantLampOn = 20,
        AttendantLampOff = 21,

        GameSelected = 22,
        GamePlayed = 23,

        AttendantMenuEntered = 24,
        AttendantMenuExited = 25,

        OperatorMenuEntered = 26,
        OperatorMenuExited = 27,
        OperatorChangedOptions = 28,

        BillAccepted = 29,
        BillRejected = 30,
        BillJam = 31,
        BillAcceptorHardwareFailure = 32,

        TicketInserted = 33,
        TicketAccepted = 34,
        TicketRejected = 35,
        TicketPrinted = 36,

        CashoutButtonPressed = 37,
        CashoutTicketPrinted = 38,

        PrinterCarriageJammed = 39,
        PrinterPaperLow = 40,
        PrinterPaperOut = 41,
        PrinterPaperJammed = 42,
        PrinterCommunicationsError = 43,
        PrinterPowerOff = 44,
        PrinterPowerOn = 45,
        ReplacePrinterRibbon = 46,

        GeneralTilt = 47,
        CoinInTilt = 48,
        CoinOutTilt = 49,

        GamingMachineOutOfService = 50,

        ValidationIdConfigured = 51,
    }
}