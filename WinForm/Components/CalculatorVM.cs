using log4net;
using WinForm.Services;

namespace WinForm.Components {
    /// <summary>
    /// ViewModel
    /// </summary>
    public class CalculatorVM(CalcInvoker _calc, ILog _logger) {
        /// <summary>
        /// テーマモデル
        /// </summary>
        public Theme Theme { get; set; } = new(ThemeType.Dark);
        /// <summary>
        /// 数式表示
        /// </summary>
        public string TxFomula = "0";
        /// <summary>
        /// 入力・結果表示
        /// </summary>
        public string TxInput = "0";
        /// <summary>
        /// 格納数値
        /// </summary>
        public decimal NumInput = 0;
        /// <summary>
        /// 入力数値
        /// </summary>
        public decimal NumTemp = 0;
        /// <summary>
        /// 入力受付
        /// </summary>
        private ReceptType _receptType = ReceptType.New;
        /// <summary>
        /// 格納計算タイプ
        /// </summary>
        private CommandType _commandType = CommandType.None;
        /// <summary>
        /// エンター連続押下時に再計算
        /// </summary>
        private ClickType _lastKeyType = ClickType.None;
        /// <summary>
        /// 結果表示後の数値入力で数式リセット
        /// </summary>
        private bool EnterFlg = false;

        /// <summary>
        /// アクションハンドリング
        /// </summary>
        /// <param name="type"></param>
        public void ResultAllocateAction(ClickType type) {
            switch (type) {
                case ClickType.None:
                    break;
                case ClickType.Delete:
                    AllClear();
                    break;
                case ClickType.Backspace:
                    BackspaceInput();
                    break;
                case ClickType.Enter:
                    ExecuteCommand(CommandType.None);
                    break;
                case ClickType.Key0:
                    AddInput("0");
                    break;
                case ClickType.Key1:
                    AddInput("1");
                    break;
                case ClickType.Key2:
                    AddInput("2");
                    break;
                case ClickType.Key3:
                    AddInput("3");
                    break;
                case ClickType.Key4:
                    AddInput("4");
                    break;
                case ClickType.Key5:
                    AddInput("5");
                    break;
                case ClickType.Key6:
                    AddInput("6");
                    break;
                case ClickType.Key7:
                    AddInput("7");
                    break;
                case ClickType.Key8:
                    AddInput("8");
                    break;
                case ClickType.Key9:
                    AddInput("9");
                    break;
                case ClickType.KeyDot:
                    AddInput(".");
                    break;
                case ClickType.KeyPM:
                    AddInput("-");
                    break;
                case ClickType.KeyAdd:
                    ExecuteCommand(CommandType.Add);
                    break;
                case ClickType.KeySubstract:
                    ExecuteCommand(CommandType.Substract);
                    break;
                case ClickType.KeyMultiply:
                    ExecuteCommand(CommandType.Multiply);
                    break;
                case ClickType.KeyDivide:
                    ExecuteCommand(CommandType.Divide);
                    break;
                default:
                    break;
            }
            _lastKeyType = type;
        }
        /// <summary>
        /// 数値入力
        /// </summary>
        /// <param name="text"></param>
        private void AddInput(string text) {
            if (EnterFlg) {
                AllClear();
                EnterFlg = false;
            }
            if (_receptType == ReceptType.New) {
                TxInput = string.Empty;
                _receptType = ReceptType.Continue;
            }
            if (text == "-") {
                ReverseMinus();
                return;
            }
            if (text == ".") {
                AddDot();
                return;
            }
            AddNum();
            void ReverseMinus() {
                if (TxInput == "0" || string.IsNullOrEmpty(TxInput)) {
                    TxInput = "0";
                    _receptType = ReceptType.New;
                    return;
                }
                if (TxInput.StartsWith('-')) {
                    TxInput = TxInput[1..];
                } else {
                    TxInput = $"-{TxInput}";
                }
            }
            void AddDot() {
                if (TxInput.Contains('.')) {
                    return;
                }
                if (string.IsNullOrEmpty(TxInput)) {
                    TxInput += "0.";
                    return;
                }
                TxInput += '.';
            }
            void AddNum() {
                if (!TxInput.Contains('.')) {
                    TxInput += text;
                } else {
                    string[] dAfter = TxInput.Split('.');
                    if (dAfter[1].Length >= 5) {
                        return;
                    }
                    TxInput += text;
                }
            }
        }
        /// <summary>
        /// 1文字削除
        /// </summary>
        private void BackspaceInput() {
            if (_receptType == ReceptType.New) {
                TxInput = "0";
                return;
            }
            if (!string.IsNullOrEmpty(TxInput)) {
                TxInput = TxInput.Substring(0, TxInput.Length - 1);
                if (string.IsNullOrEmpty(TxInput) || TxInput == "-") {
                    TxInput = "0";
                    _receptType = ReceptType.New;
                    return;
                }
            }
        }
        /// <summary>
        /// クリア
        /// </summary>
        private void AllClear() {
            TxFomula = "0";
            NumInput = 0;
            NumTemp = 0;
            TxInput = "0";
            _receptType = ReceptType.New;
            _commandType = CommandType.None;
        }

        #region 計算実行
        private decimal GetResult(CommandType type, decimal a, decimal b) {
            return type switch {
                CommandType.Add => Math.Round(_calc.ExecuteCommand<AddCommand>(a, b), 5),
                CommandType.Substract => Math.Round(_calc.ExecuteCommand<SubtractCommand>(a, b), 5),
                CommandType.Multiply => Math.Round(_calc.ExecuteCommand<MultiplyCommand>(a, b), 5),
                CommandType.Divide => Math.Round(_calc.ExecuteCommand<DivideCommand>(a, b), 5),
                _ => 0,
            };
        }
        private string GetCommandText(CommandType type) {
            return type switch {
                CommandType.Add => _calc.GetCommandString<AddCommand>(),
                CommandType.Substract => _calc.GetCommandString<SubtractCommand>(),
                CommandType.Multiply => _calc.GetCommandString<MultiplyCommand>(),
                CommandType.Divide => _calc.GetCommandString<DivideCommand>(),
                _ => "",
            };
        }
        private decimal GetProcessingNum() {
            if (TxInput.EndsWith('.')) {
                BackspaceInput();
            }
            if (decimal.TryParse(TxInput, out decimal num)) {
                return num;
            } else {
                TxInput = "0";
                return 0;
            }
        }
        private void ExecuteCommand(CommandType type) {
            try {
                decimal num = GetProcessingNum();
                switch (type) {
                    case CommandType.Add:
                    case CommandType.Substract:
                    case CommandType.Multiply:
                    case CommandType.Divide:
                        if (_receptType == ReceptType.New || _commandType == CommandType.None) {
                            TxFomula = $"{num} {GetCommandText(type)}";
                            NumTemp = num;
                        } else {
                            if (_commandType != type) {
                                decimal result = GetResult(_commandType, NumTemp, num);
                                TxFomula = $"{result} {GetCommandText(type)}";
                                NumTemp = result;
                                TxInput = result.ToString();
                            } else {
                                decimal result = GetResult(type, NumTemp, num);
                                TxFomula = $"{result} {GetCommandText(type)}";
                                NumTemp = result;
                                TxInput = result.ToString();
                            }
                        }
                        _commandType = type;
                        EnterFlg = false;
                        break;
                    case CommandType.None:
                        if (_commandType == CommandType.None) {
                            NumTemp = num;
                            TxFomula = $"{num} =";
                        } else {
                            if (_lastKeyType == ClickType.Enter) {
                                decimal result = GetResult(_commandType, num, NumTemp);
                                TxFomula = $"{num} {GetCommandText(_commandType)} {NumTemp} =";
                                TxInput = result.ToString();
                            } else {
                                decimal result = GetResult(_commandType, NumTemp, num);
                                TxFomula = $"{NumTemp} {GetCommandText(_commandType)} {num} =";
                                NumTemp = num;
                                TxInput = result.ToString();
                            }
                        }
                        EnterFlg = true;
                        break;
                    default:
                        break;
                }
                _receptType = ReceptType.New;
            } catch (DivideByZeroException ex) {
                _logger.Debug(ex);
                AllClear();
                TxInput = ex.Message;
            } catch (OverflowException ex) {
                _logger.Debug(ex);
                AllClear();
                TxInput = "Max Error";
            }
        }
        #endregion
    }
}
