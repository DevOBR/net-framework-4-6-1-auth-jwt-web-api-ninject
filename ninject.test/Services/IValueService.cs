using System.Collections.Generic;
using System.Threading.Tasks;

namespace ninject.test.Services
{
    /// <summary>
    /// Get test values
    /// </summary>
    public interface IValuesService
    {
        /// <summary>
        /// Create a list of strings    
        /// </summary>
        /// <returns>{"string 1", "string 2"}</returns>
        Task<List<string>> GetValuesAsync();

        /// <summary>
        /// Create new item in string list
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Task</returns>
        Task CreateNewItemInStringListAsync(string val);


    }
}