namespace WinForm.Services {
    /// <summary>
    /// 減算
    /// </summary>
    public class SubtractCommand : ICommand {
        public decimal Execute(decimal a, decimal b) {
            return a - b;
        }
        public string GetCommandString() {
            return "-";
        }
        public CommandType GetCommandType() {
            return CommandType.Substract;
        }
    }
}
