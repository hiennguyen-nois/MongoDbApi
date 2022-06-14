namespace API.Entities.Test
{
    public enum QuestionType
    {
        SingleChoice,
        MultipleChoice,
        TrueFalse,
        Short,
        Descriptive
    }

    public enum Status
    {
        Active,
        SetupInProgress,
        Ended,
        AutoStart,
        AccessClosed
    }

    public enum DurationUnit
    {
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year
    }
}
