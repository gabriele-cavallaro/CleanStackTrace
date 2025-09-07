namespace CleanStackTrace.Utils;

/// <summary>
/// Provides namespace filtering for stack trace cleaning.
/// Contains predefined and customizable namespace exclusion lists.
/// </summary>
public static class BannedNamespaces
{
    internal static readonly string[] BannedNamespacesList =
        [
            "Microsoft",
            "Swashbuckle",
            "Autofac",
            "Xunit",
            "Moq"
        ];

    internal static readonly List<string> CustomBannedNamespacesList = [];

    /// <summary>
    /// Adds a new prefix/namespace to the dynamic filter of clean stack trace util.
    /// </summary>
    public static void AddCustomPrefix(string prefix)
    {
        if (string.IsNullOrWhiteSpace(prefix))
            return;
        else if (BannedNamespacesList.Contains(prefix) || CustomBannedNamespacesList.Contains(prefix))
            return;
        else
            CustomBannedNamespacesList.Add(prefix);
    }

    /// <summary>
    /// Removes a prefix/namespace from the dynamic filter of clean stack trace util.
    /// </summary>
    public static void RemoveCustomPrefix(string prefix)
    {
        if (!string.IsNullOrWhiteSpace(prefix) && CustomBannedNamespacesList.Contains(prefix))
            CustomBannedNamespacesList.Remove(prefix);
    }
}
