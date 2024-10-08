using OrchardCore.Localization;

namespace Microsoft.Extensions.Localization;

/// <summary>
/// Provides extension methods for <see cref="IStringLocalizer"/>.
/// </summary>
public static class StringLocalizerExtensions
{
    /// <summary>
    /// Gets the pluralization form.
    /// </summary>
    /// <param name="localizer">The <see cref="IStringLocalizer"/>.</param>
    /// <param name="count">The number to be used for selecting the pluralization form.</param>
    /// <param name="singular">The singular form key.</param>
    /// <param name="plural">The plural form key.</param>
    /// <param name="arguments">The parameters used in the key.</param>
    public static LocalizedString Plural(this IStringLocalizer localizer, int count, string singular, string plural, params object[] arguments)
    {
        if (plural == null)
        {
            throw new ArgumentNullException(nameof(plural), "Plural text can't be null. If you don't want to specify the plural text, use IStringLocalizer without Plural extension.");
        }

        return localizer[singular, new PluralizationArgument { Count = count, Forms = [singular, plural], Arguments = arguments }];
    }

    /// <summary>
    /// Gets the pluralization form.
    /// </summary>
    /// <param name="localizer">The <see cref="IStringLocalizer"/>.</param>
    /// <param name="count">The number to be used for selecting the pluralization form.</param>
    /// <param name="pluralForms">A list of pluralization forms.</param>
    /// <param name="arguments">The parameters used in the key.</param>
    public static LocalizedString Plural(this IStringLocalizer localizer, int count, string[] pluralForms, params object[] arguments)
    {
        if (pluralForms == null)
        {
            throw new ArgumentNullException(nameof(pluralForms), "PluralForms array can't be null. If you don't want to specify the plural text, use IStringLocalizer without Plural extension.");
        }

        if (pluralForms.Length == 0)
        {
            throw new ArgumentException("PluralForms array can't be empty, it must contain at least one element. If you don't want to specify the plural text, use IStringLocalizer without Plural extension.", nameof(pluralForms));
        }

        return localizer[pluralForms[0], new PluralizationArgument { Count = count, Forms = pluralForms, Arguments = arguments }];
    }
}
