namespace CarAccessories.Shared.Extensions;

public static class StringExtensions
{
    public static string FromCamelCaseToSnakeCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        var stringBuilder = new System.Text.StringBuilder();
        var previousCategory = default(System.Globalization.UnicodeCategory?);

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            var currentCategory = char.GetUnicodeCategory(c);

            if (currentCategory == System.Globalization.UnicodeCategory.UppercaseLetter)
            {
                if (i > 0 && previousCategory != System.Globalization.UnicodeCategory.SpaceSeparator &&
                    previousCategory != System.Globalization.UnicodeCategory.UppercaseLetter)
                {
                    stringBuilder.Append('_');
                }

                stringBuilder.Append(char.ToLowerInvariant(c));
            }
            else
            {
                stringBuilder.Append(c);
            }

            previousCategory = currentCategory;
        }

        return stringBuilder.ToString();
    }

    public static DateOnly GetBirthDateFromPinfl(this string pinfl)
    {
        if (string.IsNullOrWhiteSpace(pinfl) || pinfl.Length != 14 || !long.TryParse(pinfl, out _))
        {
            throw new ArgumentException("PINFL must be a 14-digit number");
        }

        // Extract day, month, and year parts from the PINFL
        int day = int.Parse(pinfl.Substring(1, 2));
        int month = int.Parse(pinfl.Substring(3, 2));
        int year = int.Parse(pinfl.Substring(5, 2));

        // Determine the full year (PINFL uses last two digits)
        // The century is determined by the 7th digit (century identifier):
        // 1-2: 1800s, 3-4: 1900s, 5-6: 2000s
        int centuryDigit = int.Parse(pinfl[..1]);

        int fullYear = centuryDigit switch
        {
            1 or 2 => 1800 + year,
            3 or 4 => 1900 + year,
            5 or 6 => 2000 + year,
            _ => throw new ArgumentException("Invalid century digit in PINFL")
        };

        try
        {
            return new DateOnly(fullYear, month, day);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            throw new ArgumentException("Invalid date in PINFL", ex);
        }
    }
    public static int GetGenderFromPinfl(this string pinfl)
    {
        if (string.IsNullOrWhiteSpace(pinfl) || pinfl.Length != 14 || !long.TryParse(pinfl, out _))
        {
            throw new ArgumentException("PINFL must be a 14-digit number");
        }
        int firstDigit = int.Parse(pinfl.Substring(0, 1));

        var gender = firstDigit % 2 == 0 ? 2 : 1;

        return gender;
    }

    public static string CapitalizeFirstLetter(this string textValue)
    {
        if (string.IsNullOrEmpty(textValue))
        {
            return string.Empty;
        }
        return char.ToUpper(textValue[0]) + textValue[1..];
    }
}