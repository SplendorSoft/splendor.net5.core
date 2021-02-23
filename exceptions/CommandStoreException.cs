using System;
using System.Text.Json;
using System.Threading.Tasks;
using splendor.net5.core.contracts;
using splendor.net5.core.enums;

namespace splendor.net5.core.exceptions
{
    public class CommandStoreException : Exception
    {
        public CommandStoreException(CommandStore command) :
            base($"Error in command store {command}")
        {
        }

        public CommandStoreException(Exception innerException, 
        CommandStore command) :
            base($"Error in command store {command}", innerException)
        {
        }
        public CommandStoreException(object data, CommandStore command) :
            base($"Error in command store {command}, info: {JsonSerializer.Serialize(data)}")
        {
        }

        public CommandStoreException(object data, Exception innerException,
        CommandStore command) :
           base($"Error in command store {command}, info: {JsonSerializer.Serialize(data)}", innerException)
        {
        }

        public async static Task Handle<E, K>(Func<Task> action, 
        IRepository<E, K> repository, CommandStore command,  object id = null, object data = null)
        where E: class, new()
        {
            try
            {
                await action();
            }
            catch (Exception e)
            {
                object obj;
                if(id != null || data != null){
                    obj = new {repository = repository.GetType().Name, id, data};
                }
                else{
                    obj = new {repository = repository.GetType().Name};
                }
                if (obj is null)
                {
                    throw new CommandStoreException(e, command);
                }
                else
                {
                    throw new CommandStoreException(obj, e, command);
                }
            }
        }
    }
}