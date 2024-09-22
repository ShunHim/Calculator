namespace WinForm.Components {
    /// <summary>
    /// ViewModel
    /// </summary>
    public class CalculatorVM {
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
    }
}
