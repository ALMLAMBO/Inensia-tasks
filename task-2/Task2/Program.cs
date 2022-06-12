class Program {

	const double MAX_SALARY_WITHOUT_TAXES = 1000;
	const double TAX_PERCENT = 0.1;
	const double SOCIAL_CONTRIBUTORS_TAX_PERCENT = 0.15;
	const double MAX_SOCIAL_CONTRIBUTORS_VALUE_FOR_TAX = 2000;

	static void Main(string[] args) {
		double grossSalary = double.Parse(Console.ReadLine());

		CalculateNetSalary(grossSalary);
	}

	/// <summary>
	/// Checks if salary is required to subtract taxes
	/// </summary>
	/// <param name="grossSalary">Salary before taxes</param>
	static void CalculateNetSalary(double grossSalary) {
		if (grossSalary <= MAX_SALARY_WITHOUT_TAXES) {
			Console.WriteLine(grossSalary);
			return;
		}

		double valueForTax = CalculateValueForTax(grossSalary);
		double incomeTax = CalculateIncomeTax(valueForTax);
		double socialContributorsTax = CalculateSocialContributorsTax(valueForTax);

		grossSalary -= (incomeTax + socialContributorsTax);

		Console.WriteLine(grossSalary);
	}

	/// <summary>
	/// Gets amount of money over MAX_SALARY_WITHOUT_TAXES
	/// </summary>
	/// <param name="grossSalary">salary before taxes</param>
	/// <returns>amount over MAX_SALARY_WITHOUT_TAXES</returns>
	static double CalculateValueForTax(double grossSalary) {
		return grossSalary - MAX_SALARY_WITHOUT_TAXES;
	}

	/// <summary>
	/// Gets income TAX which is calculated by multiplying valueForTax and TAX_PERCENT
	/// </summary>
	/// <param name="valueForTax">amount over MAX_SALARY_WITHOUT_TAXES</param>
	/// <returns>income tax</returns>
	static double CalculateIncomeTax(double valueForTax) {
		return valueForTax * TAX_PERCENT;
	}

	/// <summary>
	/// Gets tax for social contributors which is calculated by 
	/// multiplying valueForTax and SOCIAL_CONTRIBUTORS_TAX_PERCENT
	/// Also, social contributors can get maximum 
	/// MAX_SOCIAL_CONTRIBUTORS_VALUE_FOR_TAX multiplied by SOCIAL_CONTRIBUTORS_TAX_PERCENT
	/// </summary>
	/// <param name="valueForTax">amount over MAX_SALARY_WITHOUT_TAXES</param>
	/// <returns>social contributors tax</returns>
	static double CalculateSocialContributorsTax(double valueForTax) {
		if(valueForTax > MAX_SOCIAL_CONTRIBUTORS_VALUE_FOR_TAX) {
			valueForTax = MAX_SOCIAL_CONTRIBUTORS_VALUE_FOR_TAX;
		}

		return valueForTax * SOCIAL_CONTRIBUTORS_TAX_PERCENT;
	}
}