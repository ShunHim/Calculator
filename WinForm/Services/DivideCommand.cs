namespace WinForm.Services {
    /// <summary>
    /// 除算
    /// </summary>
    public class DivideCommand : ICommand {
        public decimal Execute(decimal a, decimal b) {
            if (b == 0) {
                throw new DivideByZeroException("Error");
            }
            return a / b;
        }
        public string GetCommandString() {
            return "÷";
        }
        public CommandType GetCommandType() {
            return CommandType.Divide;
        }
    }
}
