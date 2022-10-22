using Strawhenge.Common.Ranges;

public interface IData
{
    int Id { get; }

    string Name { get; }

    bool IsValid { get; }

    FloatRange Range { get; }
}