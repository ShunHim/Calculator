namespace WinForm.Services {
    public interface ICommand {
        /// <summary>
        /// 四則演算の実行
        /// </summary>
        /// <param name="a">保管地</param>
        /// <param name="b">入力値</param>
        /// <returns></returns>
        decimal Execute(decimal a, decimal b);
        /// <summary>
        /// コマンド文字を取得
        /// </summary>
        /// <returns></returns>
        string GetCommandString();
        /// <summary>
        /// コマンドタイプを取得
        /// </summary>
        /// <returns></returns>
        CommandType GetCommandType();
    }
}
