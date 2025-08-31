namespace CleanStackTrace.Utils;

/// <summary>
/// Provides namespace filtering for stack trace cleaning.
/// Contains predefined and customizable namespace exclusion lists.
/// </summary>
public static class BannedNamespaces
{
    internal static readonly string[] BannedNamespacesList =
        [
            "at Microsoft.",
            "at System.",
            "at Swashbuckle.",
            "at Autofac.",
            "at xunit.",
            "at Moq."
        ];

    internal static readonly List<string> CustomBannedNamespacesList = [];

    /// <summary>
    /// Adds a new prefix/namespace to the dynamic filter of clean stack trace util.
    /// </summary>
    public static void AddCustomPrefix(string prefix)
    {
        if (!string.IsNullOrWhiteSpace(prefix) && !BannedNamespacesList.Contains(prefix) && !CustomBannedNamespacesList.Contains(prefix))
            CustomBannedNamespacesList.Add(prefix);
    }
}
