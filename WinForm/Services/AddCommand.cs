namespace WinForm.Services {
    /// <summary>
    /// 加算
    /// </summary>
    public class AddCommand : ICommand {
        public decimal Execute(decimal a, decimal b) {
            return a + b;
        }
        public string GetCommandString() {
            return "+";
        }
        public CommandType GetCommandType() {
            return CommandType.Add;
        }
    }
}
