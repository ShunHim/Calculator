using Microsoft.Extensions.DependencyInjection;

namespace WinForm.Services {
    public class CalcInvoker(IServiceProvider _serviceProvider) {
        public decimal ExecuteCommand<TCommand>(decimal a, decimal b) where TCommand : ICommand {
            var command = _serviceProvider.GetRequiredService<TCommand>();
            return command.Execute(a, b);
        }
        public string GetCommandString<TCommand>() where TCommand : ICommand {
            var command = _serviceProvider.GetRequiredService<TCommand>();
            return command.GetCommandString();
        }
        public CommandType GetCommandType<TCommand>() where TCommand : ICommand {
            var command = _serviceProvider.GetRequiredService<TCommand>();
            return command.GetCommandType();
        }
    }
}
