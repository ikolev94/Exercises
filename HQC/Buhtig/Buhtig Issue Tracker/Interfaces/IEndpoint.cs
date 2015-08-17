namespace Buhtig_Issue_Tracker.Interfaces
{
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
