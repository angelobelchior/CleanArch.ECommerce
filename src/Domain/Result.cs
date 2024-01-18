namespace ECommerce.Domain;
/// <summary>
/// Result Status
/// </summary>
public enum ResultStatus
{
    /// <summary>
    /// Indicates that the command was executed successfully
    /// </summary>
    Success,
    /// <summary>
    /// Indicates that the command contains validations to be done
    /// </summary>
    HasValidation,
    /// <summary>
    /// Indicates that the command encountered an error on execution
    /// </summary>
    HasError,
    /// <summary>
    /// Indicates that the command did not find a specific entity
    /// </summary>
    EntityNotFound,
    /// <summary>
    /// Indicates that the command is trying to create an entity that already exists
    /// </summary>
    EntityAlreadyExists,
    /// <summary>
    /// Indicates that the command was executed successfully but does not contain any content to be returned
    /// </summary>
    NoContent
}

/// <summary>
/// IResult Interface
/// </summary>
public interface IResult
{
    /// <summary>
    /// Result Status
    /// </summary>
    ResultStatus Status { get; }
}

/// <summary>
/// IResult Interface
/// </summary>
/// <typeparam name="T">Data Type</typeparam>
public interface IResult<out T> : IResult
{
    /// <summary>
    /// Data
    /// </summary>
    T? Data { get; }
}

/// <summary>
/// IRequest Validations Interface
/// </summary>
public interface IResultValidations : IResult
{
    /// <summary>
    /// Validations
    /// </summary>
    IEnumerable<Validation> Validations { get; }
}

/// <summary>
/// IRequest Error Interface
/// </summary>
public interface IResultError : IResult
{
    /// <summary>
    /// Error
    /// </summary>
    Error? Error { get; }
}

/// <summary>
/// IRequest Entity Warning Interface
/// </summary>
public interface IRequestEntityWarning : IResult
{
    /// <summary>
    /// Entity Warning
    /// </summary>
    EntityWarning? EntityWarning { get; }
}

/// <summary>
/// Result
/// </summary>
public class Result : IResultValidations, IResultError, IRequestEntityWarning
{
    /// <summary>
    /// Create a Success Result
    /// </summary>
    /// <returns>Success Result</returns>
    public static Result Success() 
        => new Result { Status = ResultStatus.Success };
    /// <summary>
    /// Create a No Content Result
    /// </summary>
    /// <returns>No Content Result</returns>
    public static Result WithNoContent() 
        => new Result { Status = ResultStatus.NoContent };
    /// <summary>
    /// Create a Entity Not Found Result
    /// </summary>
    /// <param name="entity">Entity Name</param>
    /// <param name="id">Entity Id</param>
    /// <param name="description">Description</param>
    /// <returns>Not Found Result</returns>
    public static Result EntityNotFound(string entity, object id, string description)
        => new()
        {
            Status = ResultStatus.EntityNotFound,
            EntityWarning = new EntityWarning(entity, id, description)
        };
    /// <summary>
    /// Create a Entity Already Exists Result
    /// </summary>
    /// <param name="entity">Entity Name</param>
    /// <param name="id">Entity Id</param>
    /// <param name="description">Description</param>
    /// <returns>Already Exists Result</returns>
    public static Result EntityAlreadyExists(string entity, object id, string description)
        => new()
        {
            Status = ResultStatus.EntityAlreadyExists,
            EntityWarning = new EntityWarning(entity, id, description)
        };
    /// <summary>
    /// Create an Error Result
    /// </summary>
    /// <param name="message">Error message</param>
    /// <returns>Error Result</returns>
    public static Result WithError(string message)
        => new()
        {
            Status = ResultStatus.HasError,
            Error = new Error(message)
        };
    /// <summary>
    /// Create an Error Result
    /// </summary>
    /// <param name="exception">Exception</param>
    /// <returns>Error Result</returns>
    public static Result WithError(Exception exception) 
        => WithError(exception.Message);
    /// <summary>
    /// Create a Validation Result
    /// </summary>
    /// <param name="validations">Validations List</param>
    /// <returns>Validation Result</returns>
    public static Result WithValidations(params Validation[] validations)
        => new()
        {
            Status = ResultStatus.HasValidation,
            Validations = validations
        };
    /// <summary>
    /// Create a Validation Result
    /// </summary>
    /// <param name="validations">Validations List</param>
    /// <returns>Validation Result</returns>
    public static Result WithValidations(IEnumerable<Validation> validations)
        => WithValidations(validations.ToArray());
    /// <summary>
    /// Create a Validation Result
    /// </summary>
    /// <param name="propertyName">Property Name</param>
    /// <param name="description">Validation Description</param>
    /// <returns>Validation Result</returns>
    public static Result WithValidations(string propertyName, string description)
        => WithValidations(new Validation(propertyName, description));

    /// <summary>
    /// Result Status
    /// </summary>
    public ResultStatus Status { get; protected init; }

    /// <summary>
    /// Validations List
    /// </summary>
    public IEnumerable<Validation> Validations { get; protected init; } = Enumerable.Empty<Validation>();

    /// <summary>
    /// Error Object
    /// </summary>
    public Error? Error { get; protected init; }

    /// <summary>
    /// Entity Warning Object
    /// </summary>
    public EntityWarning? EntityWarning { get; protected init; }
}

/// <summary>
/// Result Model
/// </summary>
/// <typeparam name="T">Data Type</typeparam>
public class Result<T> : Result, IResult<T>
{
    /// <summary>
    /// Create a Success Result
    /// </summary>
    /// <param name="data">Data</param>
    /// <returns>Success Result</returns>
    public static Result<T> Success(T data) 
        => new()
        {
            Data = data, 
            Status = ResultStatus.Success
        };
    /// <summary>
    /// Create a No Content Result
    /// </summary>
    /// <returns>No Content Result</returns>
    public new static Result<T> WithNoContent() 
        => new()
        {
            Status = ResultStatus.NoContent
        };
    /// <summary>
    /// Create a Entity Not Found Result
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="id">Entity Id</param>
    /// <param name="description">Description</param>
    /// <returns>Entity Not Found Result</returns>
    public new static Result<T> EntityNotFound(string entity, object id, string description)
        => new()
        {
            Status = ResultStatus.EntityNotFound,
            EntityWarning = new EntityWarning(entity, id, description)
        };
    /// <summary>
    /// Create a Entity Already Exists Result
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="id">Entity Id</param>
    /// <param name="description">Description</param>
    /// <returns>Entity Already Exists Result</returns>
    public new static Result<T> EntityAlreadyExists(string entity, object id, string description)
        => new()
        {
            Status = ResultStatus.EntityAlreadyExists,
            EntityWarning = new EntityWarning(entity, id, description)
        };
    /// <summary>
    /// Create an Error Result
    /// </summary>
    /// <param name="message">Error Message</param>
    /// <returns>Error Result</returns>
    public new static Result<T> WithError(string message)
        => new()
        {
            Status = ResultStatus.HasError,
            Error = new Error(message)
        };
    /// <summary>
    /// Create an Error Result
    /// </summary>
    /// <param name="exception">Exception</param>
    /// <returns>Error Result</returns>
    public new static Result<T> WithError(Exception exception) 
        => WithError(exception.Message);
    /// <summary>
    /// Create a Validation Result
    /// </summary>
    /// <param name="validations">Validations List</param>
    /// <returns>Validation Result</returns>
    public new static Result<T> WithValidations(params Validation[] validations)
        => new()
        {
            Status = ResultStatus.HasValidation,
            Validations = validations
        };
    /// <summary>
    /// Create a Validation Result
    /// </summary>
    /// <param name="propertyName">Property Name</param>
    /// <param name="description">Description</param>
    /// <returns></returns>
    public new static Result<T> WithValidations(string propertyName, string description)
        => WithValidations(new Validation(propertyName, description));

    /// <summary>
    /// Data
    /// </summary>
    public T? Data { get; private init; }

    /// <summary>
    /// Create a Success Result with Data
    /// </summary>
    /// <param name="data">Data</param>
    /// <returns>Success Result</returns>
    public static implicit operator Result<T>(T data) => Success(data);
    /// <summary>
    /// Create a Error Result with Exception
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <returns>Error Result</returns>
    public static implicit operator Result<T>(Exception ex) => WithError(ex);
    /// <summary>
    /// Create a Validation Result with Validations List
    /// </summary>
    /// <param name="validations">Validations List</param>
    /// <returns>Validation Result</returns>
    public static implicit operator Result<T>(Validation[] validations) => WithValidations(validations);
    /// <summary>
    /// Create a Validation Result with Validation
    /// </summary>
    /// <param name="validation">Validation</param>
    /// <returns>Validation Result</returns>
    public static implicit operator Result<T>(Validation validation) => WithValidations(validation);
}

/// <summary>
/// Validation
/// </summary>
/// <param name="PropertyName">Property Name</param>
/// <param name="Description">Description</param>
public record Validation(string PropertyName, string Description);

/// <summary>
/// Error
/// </summary>
/// <param name="Description">Description</param>
public record Error(string Description);

/// <summary>
/// Entity Warning
/// </summary>
/// <param name="Name">Entity Name</param>
/// <param name="Id">Entity Id</param>
/// <param name="Message">Message</param>
public record EntityWarning(string Name, object Id, string Message);