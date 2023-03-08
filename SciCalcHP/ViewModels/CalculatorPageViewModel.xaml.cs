
namespace SciCalcHP.ViewModels
{
	[INotifyPropertyChanged]
	internal partial class CalculatorPageViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[ObservableProperty]
		private string inputText = string.Empty;

		[ObservableProperty]
		private string calculatedResult = "0";

		private bool isSciOpWaiting = false;
		public CalculatorPageViewModel() {

		}
		[RelayCommand]
		private void Reset()
		{
			calculatedResult = "0";
			inputText = string.Empty;
			isSciOpWaiting = false;

        }

		[RelayCommand]
		private void Calculate()
		{
			if (inputText.Length == 00)
			{
				return;
			}
			if (isSciOpWaiting)
			{
				inputText += ")";
				isSciOpWaiting= false;
			}

			try
			{
				var inputString = NomralizeInputString();
			}
			catch(Exception ) {
				throw;
			}
		}

		private string NormalizeInputString()
		{
			Dictionary<string, string> _opMapper = new()
			{
				{"x", "*"},
				{"÷", "/" },
				{"SIN", "Sin"},
				{"COS", "Cos"},
				{"Tan", "Cos"},
				{"ASIN", "Asin"},
				{"ACOS", "Acos" },
				{"ATAN", "Atam" },
				{"LOG", "Log" },
				{"EXP", "Exp"},
				{"LOG10", "Log10"},
				{"POW", "Pow"},
				{"SQRT","Sqrt"},
				{"ABS", "Abs" }
			};
			var retString = InputText;

			foreach (var key in _opMapper) {
				retString = retString.Replace(key, _opMapper[key]);
			}

			return retString;
		}

		[RelayCommand]
		private void Backspace()
		{
			if (InputText.Length > 0) {
				inputText = InputText.Substring(0, InputText.Length - 1);


			}
		}

		[RelayCommand]
		private void NumberInput(string key)
		{
			InputText += key;
		}

		[RelayCommand]
		private void MathOperator(string op)
		{
			if (isSciOpWaiting)
			{
				InputText += ")";
				isSciOpWaiting = false;
			}
			InputText += $" {op}";
		}
		[RelayCommand]
		private void RegionOperaor(string op)
		{
			if (op == ")")
			{
				isSciOpWaiting = false;

			}
			InputText += op;
		}
		[RelayCommand]
		private void ScientificOperator(string op)
		{
			InputText += $"{op}(";
			isSciOpWaiting = true;
		}

	}
}