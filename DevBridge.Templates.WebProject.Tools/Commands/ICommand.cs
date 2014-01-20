using BetterCms.Core.Mvc.Commands;

namespace DevBridge.Templates.WebProject.Tools.Commands
{
    public interface ICommandBase
    {
        ICommandContext Context { get; set; }
    }

    /// <summary>
    /// Defines contract of the parameter less command.
    /// </summary>
    public interface ICommand : ICommandBase
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Defines contract of the command with input and no output. 
    /// </summary>
    /// <typeparam name="TRequest">The type of the viewModel.</typeparam>
    public interface ICommand<in TRequest> : ICommandBase
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <param name="viewModel">The viewModel.</param>
        void Execute(TRequest viewModel);
    }

    /// <summary>
    /// Defines contract of the command with input and output.
    /// </summary>
    /// <typeparam name="TRequest">The type of the viewModel.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface ICommand<in TRequest, out TResponse> : ICommandBase
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <param name="request">The viewModel.</param>
        /// <returns>Executed command result.</returns>
         TResponse Execute(TRequest request);
    }
}