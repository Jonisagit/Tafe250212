using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator : Page
	{
		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}

		private void calcButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Get the entered amount
				double amount = double.Parse(amountBox.Text);

				// Extract the selected currencies (take only the prefix code, e.g., "USD")
				string fromCurrency = fromComboBox.SelectedItem.ToString().Split('-')[0].Trim();
				string toCurrency = toComboBox.SelectedItem.ToString().Split('-')[0].Trim();

				// Lookup table of conversion rates from the given table
				var conversionRates = new Dictionary<(string, string), double>
{
    // USD conversions
    { ("USD", "EUR"), 0.85189982 },
	{ ("USD", "GBP"), 0.72872436 },
	{ ("USD", "INR"), 74.257327 },

    // Euro conversions
    { ("EUR", "USD"), 1.1739732 },
	{ ("EUR", "GBP"), 0.8556672 },
	{ ("EUR", "INR"), 87.00755 },

    // British Pound conversions
    { ("GBP", "USD"), 1.371907 },
	{ ("GBP", "EUR"), 1.168692 },
	{ ("GBP", "INR"), 101.68635 },

    // Indian Rupee conversions
    { ("INR", "USD"), 0.011492628 },
	{ ("INR", "EUR"), 0.013492774 },
	{ ("INR", "GBP"), 0.0098339397 }
};

				double result;

				if (fromCurrency == toCurrency)
				{
					// No conversion needed
					result = amount;
				}
				else if (conversionRates.ContainsKey((fromCurrency, toCurrency)))
				{
					// Perform conversion
					result = amount * conversionRates[(fromCurrency, toCurrency)];
				}
				else
				{
					// If no conversion rate found (shouldn't happen with the full table)
					throw new Exception($"No conversion rate found for {fromCurrency} → {toCurrency}");
				}

				// Display result
				Result.Text = "Here is the conversion result: " + $"{amount} {fromCurrency} = {result:F2} {toCurrency}";
			}
			catch (Exception ex)
			{
				Result.Text = "Error: " + ex.Message;
			}

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame?.Navigate(typeof(MainMenu));
		}
	}
}
