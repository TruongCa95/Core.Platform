using System;
using System.Globalization;

public class CurrencyConverter
{
    public static string ConvertToCurrency(decimal amount, string cultureCode = "vi-VN")
    {
        var cultureInfo = new CultureInfo(cultureCode);
        return amount.ToString("C", cultureInfo);
    }
}