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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			// Read text values into double and int variables
			
			// Inputs
			double principalBorrowed = double.Parse(PrincipalBorrowedTextBox.Text);
			int years = int.Parse(YearsTextBox.Text);
			int months = int.Parse(MonthsTextBox.Text);
			double annualInterestRate = double.Parse(AnnualInterestRateTextBox.Text);

			// Calculations   
			// output this to text box on calculation click
			double monthlyInterestRate = annualInterestRate / 12.0;
			// just for calculation
			double decimalMonthlyInterestRate = monthlyInterestRate * 0.01;
			// just for calculation
			int numberOfPayments = years * 12 + months;
			// intermediate calculation 1
			double numerator = principalBorrowed * decimalMonthlyInterestRate * Math.Pow(1 + decimalMonthlyInterestRate, numberOfPayments);
			// intermediate calculation 2
			double denominator = Math.Pow(1 + decimalMonthlyInterestRate, numberOfPayments) - 1;
			// final calculation for output
			double monthlyRepayment = numerator / denominator;

			// output results
			MonthlyInterestRateTextBox.Text = monthlyInterestRate.ToString() + "%";
			MonthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C");
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
