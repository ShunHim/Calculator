namespace WinForm.Services {
    /// <summary>
    /// 乗算
    /// </summary>
    public class MultiplyCommand : ICommand {
        public decimal Execute(decimal a, decimal b) {
            return a * b;
        }
        public string GetCommandString() {
            return "×";
        }
        public CommandType GetCommandType() {
            return CommandType.Multiply;
        }
    }
}
